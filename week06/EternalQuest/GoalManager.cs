using System.Diagnostics;
using System.IO;
using Spectre.Console;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    private int _level = 1;

    public GoalManager()
    {

    }

    public void Start()
    {
        bool showMenu = true;
        while (showMenu)
        {
            Console.Clear();
            DisplayPlayerInfo();
            int option = DisplayMenu();
            switch (option)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    LoadGoals();
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    showMenu = false;
                    break;
                default:
                    Console.WriteLine("It's not a valid option, try again.");
                    Thread.Sleep(1000);
                    break;
            }
        }

    }

    private int DisplayMenu()
    {
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Menu Options: :books:")
            .PageSize(6)
            .AddChoices(new[] {
                "1. Create New Goal",
                "2. List Goals",
                "3. Save Goals",
                "4. Load Goals",
                "5. Record Event",
                "6. Quit"
            }));
        return int.Parse(choice.Split(".")[0]);
    }

    public void DisplayPlayerInfo()
    {        
        AnsiConsole.Write(
            new FigletText($"Level: {_level}")
                .LeftJustified()
                .Color(Color.BlueViolet));
        AnsiConsole.Write(
            new FigletText($"Score: {_score} points")
                .LeftJustified()
                .Color(Color.Red));
        Console.WriteLine("");
    }

    public int PromptForGoalTypeSelection()
    {
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("The types of Goals are:")
            .PageSize(6)
            .AddChoices(new[] {
                "1.- Simple Goal",
                "2.- Eternal Goal",
                "3.- Checklist Goal"
        }));
        return int.Parse(choice.Split(".")[0]);
    }

    public int PromptForGoalSelectionToRecord()
    {
        List<string> goals = new List<string>();
        int count = 1;
        foreach (Goal goal in _goals)
        {
            goals.Add($"{count}. {goal.GetName()}");
            count++;
        }

        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title(":bullseye: The goals are:")
            .PageSize(6)
            .AddChoices(goals));
        return int.Parse(choice.Split(".")[0]);
    }

    public void ListGoalDetails()
    {
        Console.Clear();
        Console.WriteLine("The goals are: ");
        int listNumber = 1;
        foreach (Goal goal in _goals)
        {
            string detailString = goal.GetDetailsString();
            Console.WriteLine($"{listNumber}. {detailString}");
            listNumber++;
        }
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        int selectedGoal = PromptForGoalTypeSelection();
        Console.WriteLine("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.WriteLine("What is a short description of it? ");
        string goalDescription = Console.ReadLine();
        Console.WriteLine("What is the amount of points associated with this goal? ");
        int goalPoints = int.Parse(Console.ReadLine());
        // Check that the amount of points is more than 0
        while (goalPoints <= 0)
        {
            Console.WriteLine("Please enter an amount of points greater than 0.");
            Console.WriteLine("What is the amount of points associated with this goal? ");
            goalPoints = int.Parse(Console.ReadLine());
        }
        switch (selectedGoal)
        {
            case 1:
                SimpleGoal simpleGoal = new SimpleGoal(goalName, goalDescription, goalPoints);
                _goals.Add(simpleGoal);
                break;
            case 2:
                EternalGoal eternalGoal = new EternalGoal(goalName, goalDescription, goalPoints);
                _goals.Add(eternalGoal);
                break;
            case 3:
                Console.WriteLine("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the bouns for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                ChecklistGoal checklistGoal = new ChecklistGoal(goalName, goalDescription, goalPoints, target, bonus);
                _goals.Add(checklistGoal);
                break;
            default:
                break;
        }
    }

    public void RecordEvent()
    {
        Console.Clear();
        int index = PromptForGoalSelectionToRecord() - 1;
        Goal goal = _goals[index];
        int pointsEarned = goal.RecordEvent();
        if (pointsEarned == 0)
        {
            AnsiConsole.Write(
                new FigletText($"Ups!")
                    .Centered()
                    .Color(Color.Red));
            AnsiConsole.MarkupLine(":anxious_face_with_sweat: The goal was already completed; you can't earn more points!");
        }
        else
        {
            _score += pointsEarned;
            AnsiConsole.Write(
                new FigletText($"Congratulations!")
                    .Centered()
                    .Color(Color.Blue));
            AnsiConsole.Write(
                new FigletText($"You have earned {pointsEarned} points!")
                    .Centered()
                    .Color(Color.Green));
            Console.WriteLine($"You now have {_score} points.");
        }
        CheckLevel();
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.WriteLine("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{_score}");
            foreach (Goal goal in _goals)
            {
                string stringRepresentation = goal.GetStringRepresentation();
                outputFile.WriteLine(stringRepresentation);
            }
        }

    }

    public void LoadGoals()
    {
        Console.WriteLine("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        // Clear the list of entries
        _goals.Clear();
        _score = int.Parse(lines[0]);
        foreach (string line in lines[1..])
        {
            string goalType = line.Split(":")[0];
            string objectInfo = line.Replace($"{goalType}:", "");
            string[] attributes = objectInfo.Split("|");
            string shortName = attributes[0];
            string description = attributes[1];
            int points = int.Parse(attributes[2]);
            switch (goalType)
            {
                case "SimpleGoal":
                    bool isComplete = bool.Parse(attributes[3]);
                    SimpleGoal simpleGoal = new SimpleGoal(shortName, description, points);
                    simpleGoal.SetIsComplete(isComplete);
                    _goals.Add(simpleGoal);
                    break;
                case "EternalGoal":
                    EternalGoal eternalGoal = new EternalGoal(shortName, description, points);
                    _goals.Add(eternalGoal);
                    break;
                case "ChecklistGoal":
                    int amountCompleted = int.Parse(attributes[3]);
                    int target = int.Parse(attributes[4]);
                    int bonus = int.Parse(attributes[5]);
                    ChecklistGoal checklistGoal = new ChecklistGoal(shortName, description, points, target, bonus);
                    checklistGoal.SetAmountCompleted(amountCompleted);
                    _goals.Add(checklistGoal);
                    break;
                default:
                    break;

            }
        }
        CheckLevel();
    }

    // Each 1000 points is 1 level
    public void CheckLevel()
    {
        _level = _score / 1000 + 1;
    }
}