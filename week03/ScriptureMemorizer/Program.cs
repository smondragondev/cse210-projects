using System;
/*
Exceeding Requirements:
    - I added validation to the HideRandomWords method of the Scripture class to avoid hiding a word that is already hidden.
    - I created a "ScriptureGenerator" class to store all the scriptures from a JSON file 
    I found at: https://github.com/beandog/lds-scriptures. For reading the JSON file, I referred to the documentation at: 
    https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/use-dom.
    Additionally, each time the user runs the program, a random scripture is selected for practice.
*/
class Program
{
    static void Main(string[] args)
    {
        ScriptureGenerator scriptureGenerator = new ScriptureGenerator();
        Scripture scripture = scriptureGenerator.PickRandomScripture();
        bool runProgram = true;

        while (runProgram)
        {
            string displayedText = scripture.GetDisplayText();
            Console.Clear();
            Console.WriteLine(displayedText);
            if (scripture.isCompletelyHidden())
            {
                runProgram = false;
            }
            else
            {
                string answer = PromptUser();
                if (answer == "quit")
                {
                    runProgram = false;
                }
                else if (answer == "")
                {
                    scripture.HideRandomWords();
                }
            }


        }

    }

    static string PromptUser()
    {
        Console.WriteLine("Press enter to continue or type 'quit' to finish:");
        string answer = Console.ReadLine();
        return answer;
    }
}