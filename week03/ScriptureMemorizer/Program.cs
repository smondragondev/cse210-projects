using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Matthew", 16, 25);
        string scriptureText = "For whosoever will save his life shall lose it: and whosoever will lose his life for my sake shall find it.";
        Scripture scripture = new Scripture(reference, scriptureText);
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