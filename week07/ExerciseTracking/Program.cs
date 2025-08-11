using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running("09 Nov 2025", 30, 4.8);
        activities.Add(running);

        Cycling cycling = new Cycling("10 nov 2025", 30, 10.5);
        activities.Add(cycling);

        Swimming swimming = new Swimming("11 nov 2025", 30, 4);
        activities.Add(swimming);

        Console.Clear();
        foreach (Activity activity in activities)
        {
            string summary = activity.GetSummary();
            Console.WriteLine(summary);
        }
    }
}