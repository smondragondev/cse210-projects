public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>([
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ]);
    private List<string> _questions = new List<string>([
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    ]);

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void Run()
    {
        RestartQuestions();
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner();

        if (_prompts.Count == 0)
        {
            Console.WriteLine("There are no prompts remaining for this session. Please choose another activity.");
            ShowSpinner();
        }
        else
        {
            DisplayPrompt();
            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            ShowCountDown(5);

            DisplayQuestions();

            DisplayEndingMessage();

        }
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        string prompt = _prompts[randomIndex];
        _prompts.Remove(prompt);
        return $"--- {prompt} ---";
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int randomIndex = random.Next(_questions.Count);
        string question = _questions[randomIndex];
        _questions.Remove(question);
        return $"> {question} ";
    }

    public void DisplayPrompt()
    {

        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("\nWhen you have something in mind, press enter to continue");
        string continueText = Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < futureTime)
        {
            if (_questions.Count > 0)
            {
                Console.Write(GetRandomQuestion());
                ShowSpinner(10);
                Console.WriteLine();
            }
            else
            {
                break;
            }
        }
    }

    private void RestartQuestions()
    {
        _questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?",
        ];
    }
}