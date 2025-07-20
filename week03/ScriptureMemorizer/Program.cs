using System;

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