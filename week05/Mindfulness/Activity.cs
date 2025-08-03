public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    public Activity()
    {

    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner();
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}");
        ShowSpinner();
    }

    public void ShowSpinner(int seconds = 4)
    {
        List<string> animationString = new List<string>(["|", "/", "-", "\\"]);
        int i = 0;
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write(animationString[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            i++;
            if (i >= animationString.Count)
            {
                i = 0;
            }
        }

    }

    public void ShowCountDown(int seconds)
    {

        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}