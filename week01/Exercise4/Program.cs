using System;

class Program
{
    static void Main(string[] args)
    {
        bool stopAdding = false;
        int numberToAdd;
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list o f numbers, type 0 when finished.");
        while (!stopAdding)
        {
            Console.Write("Enter a number: ");
            numberToAdd = int.Parse(Console.ReadLine());
            if (numberToAdd == 0)
            {
                stopAdding = true;
            }
            else
            {
                numbers.Add(numberToAdd);
            }
        }

        // Sum the numbers and the largest number

        int largestNumber = 0;
        int lowestNumber = numbers[0];
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
            if (largestNumber < number)
            {
                largestNumber = number;
            }
            if (number > 0 && lowestNumber > number)
            {
                lowestNumber = number;
            }
        }
        // Avg of the numbers
        double avg = (double)sum / numbers.Count;

        // Sort numbers

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {lowestNumber}");
        foreach (int number in numbers) {
            Console.WriteLine(number);
        }
    }
}