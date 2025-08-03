using System;
using Spectre.Console;

/*
Exceeding Requirements

1. I added a library to enhance the menu options: https://spectreconsole.net/prompts/selection.
2. For the Reflecting and Listing activities, only one prompt is selected randomly each time; prompts do not repeat during the session.
3. For the Reflecting activity, the questions are picked randomly and cannot be repeated for each prompt. When the Reflecting activity ends, the questions list is reset.
*/

class Program
{
    static void Main(string[] args)
    {
        bool showMenu = true;
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        while (showMenu)
        {
            int option = DisplayMenu();
            showMenu = ExecuteTheOption(option, breathingActivity, reflectingActivity, listingActivity);
        }
    }

    static int DisplayMenu()
    {
        Console.Clear();
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Menu Options:")
            .PageSize(4)
            .AddChoices(new[] {
                "1. Start breathing activity",
                "2. Start reflecting activity",
                "3. Start listing activity",
                "4. Quit"
            }));
        return int.Parse(choice.Split(".")[0]);
    }


    static bool ExecuteTheOption(int option, BreathingActivity breathingActivity, ReflectingActivity reflectingActivity, ListingActivity listingActivity)
    {
        bool showMenu = true;
        switch (option)
        {
            case 1:
                breathingActivity.Run();
                break;
            case 2:
                reflectingActivity.Run();
                break;
            case 3:
                listingActivity.Run();
                break;
            case 4:
                showMenu = false;
                break;
            default:
                Console.WriteLine("It's not a valid option, try again.");
                Thread.Sleep(1000);
                break;
        }
        return showMenu;
    }

}