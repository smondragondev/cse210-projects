using System;

class Program
{
    static void Main(string[] args)
    {
        bool showMenu = true;
        while (showMenu)
        {
            DisplayMenu();
            int option = PromptUserAnOption();
            showMenu = ExecuteTheOption(option);
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("***************************************************");
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
    }

    static int PromptUserAnOption()
    {
        Console.Write("What would you like to do? ");
        int option = int.Parse(Console.ReadLine());
        return option;
    }

    static bool ExecuteTheOption(int option)
    {
        bool showMenu = true;
        Journal journal = new Journal();
        switch (option)
        {
            case 1:
                Write(journal);
                break;
            case 2:
                Display(journal);
                break;
            case 3:
                Load();
                break;
            case 4:
                Save();
                break;
            case 5:
                showMenu = false;
                break;
            default:
                Console.WriteLine("It's not a valid option, try again.");
                break;
        }
        return showMenu;
    }

    static void Write(Journal journal)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        string randomPrompt = promptGenerator.PickPrompt();
        Console.WriteLine(randomPrompt);
        string entryContent = Console.ReadLine();
        Entry newEntry = new Entry();
        newEntry._entryText = entryContent;
        newEntry._promptText = randomPrompt;
        journal.AddEntry(newEntry);
    }

    static void Display(Journal journal)
    {
        journal.Display();
    }

    static void Load()
    {
        Console.WriteLine("Load");
    }
    
    static void Save()
    {
        Console.WriteLine("Save");      
    }
}