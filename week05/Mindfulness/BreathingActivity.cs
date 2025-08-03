public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner();
        Breathe();
        DisplayEndingMessage();
    }

    private void Breathe()
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        while (DateTime.Now < futureTime)
        {
            BreatheIn();
            BreatheOut();
        }
    }

    private void BreatheIn()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.Write($"Breathe in... ");
        ShowCountDown(4);
        
    }

    private void BreatheOut()
    {
        Console.WriteLine();
        Console.Write($"Now breathe out... ");
        ShowCountDown(6);
    }


}