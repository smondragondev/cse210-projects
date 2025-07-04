using System;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber, guessedNumber, attemptCount = 0;
        bool stopGuessing = false;

        Random randomGenerator = new Random();
        magicNumber = randomGenerator.Next(1, 100);

        while (!stopGuessing)
        {
            attemptCount++;
            Console.Write("What is your guess? ");
            guessedNumber = int.Parse(Console.ReadLine());

            if (guessedNumber == magicNumber)
            {
                Console.WriteLine("You guessed it!");
                Console.Write("Do you want to continue? (Yes/No) ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")
                {
                    stopGuessing = false;
                }
                else
                {
                    stopGuessing = true;
                    Console.WriteLine($"You did it in {attemptCount} attempts!");
                }
            }
            else if (guessedNumber > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }

            
        }

    }
}