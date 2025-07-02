using System;

class Program
{
    static void Main(string[] args)
    {
        string letter;
        Console.Write("What is your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = gradePercentage % 10;
        string appendedSymbol = "";
        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                appendedSymbol = "+";
            }
            else
            {
                appendedSymbol = "-";
            }
        }
        Console.WriteLine($"Your grade is {letter}{appendedSymbol}");
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, You passed!");
        }
        else
        {
            Console.WriteLine("Sorry, This time you don't pass. Keep praciticing!");
        }
    }
}