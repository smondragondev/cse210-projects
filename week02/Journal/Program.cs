using System;
using System.IO;
using System.Threading.Tasks;

/*
Exceeding Requirements:
    I added a database connection to save and load entries from a PostgreSQL database.
    I followed this tutorial: "https://neon.com/postgresql/postgresql-csharp/postgresql-csharp-connect", but I adapted it
    to this assignment. I didn't use async, so I changed some functions from the tutorial.
    The connection string is in the "appsettings.json" file, and the class to manage loading the configuration
    is "ConfigurationHelper".
Simplifications:
    - The database name is 'journal' and the table is 'entry', so when someone chooses option 5 or 6,
      they don't need to specify the database or table; they are predefined.
*/
class Program
{
    static void Main(string[] args)
    {

        bool showMenu = true;
        Journal journal = new Journal();
        Console.WriteLine("***************************************************");
        Console.WriteLine("Welcome to the Journal Program!");
        while (showMenu)
        {
            DisplayMenu();
            int option = PromptUserAnOption();
            showMenu = ExecuteTheOption(option, journal);
        }
    }
    static void DisplayMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load From File");
        Console.WriteLine("4. Save To File");
        Console.WriteLine("5. Load From Data Base");
        Console.WriteLine("6. Save To Data Base");
        Console.WriteLine("7. Quit");
    }

    static int PromptUserAnOption()
    {
        Console.Write("What would you like to do? ");
        int option = int.Parse(Console.ReadLine());
        return option;
    }

    static bool ExecuteTheOption(int option, Journal journal)
    {
        bool showMenu = true;
        switch (option)
        {
            case 1:
                Write(journal);
                break;
            case 2:
                Display(journal);
                break;
            case 3:
                LoadFromFile(journal);
                break;
            case 4:
                SaveToFile(journal);
                break;
            case 5:
                LoadFromDB(journal);
                break;
            case 6:
                SaveToDB(journal);
                break;
            case 7:
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
        Console.Write("> ");
        string entryContent = Console.ReadLine();
        Entry newEntry = new Entry(promptText: randomPrompt, entryText: entryContent);
        journal.AddEntry(newEntry);
    }

    static void Display(Journal journal)
    {
        journal.Display();
    }

    static void LoadFromFile(Journal journal)
    {
        journal.LoadFromFile();
    }

    static void SaveToFile(Journal journal)
    {
        journal.SaveToFile();
    }

    static void LoadFromDB(Journal journal)
    {
        journal.LoadFromDB();
    }
    static void SaveToDB(Journal journal)
    {
        journal.SaveToDB();
    }

}