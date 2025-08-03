public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>([
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    ]);

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner();

        if (_prompts.Count == 0)
        {
            Console.WriteLine("There are no prompts remaining for this session. Please choose another activity.");
            ShowSpinner();
        }
        else
        {
            Console.WriteLine("\nList as many response you can to the following prompt:\n");
            Console.WriteLine(GetRandomPrompt());
            Console.Write("You may begin in: ");
            ShowCountDown(5);
            List<string> answers = GetListFromUser();
            _count = answers.Count;
            Console.WriteLine($"You listed {_count} items");
            DisplayEndingMessage();
        }
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        string prompt = _prompts[randomIndex];
        _prompts.Remove(prompt);
        return $"--- {prompt} ---";
    }

    public List<string> GetListFromUser()
    {
        List<string> answers = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        Console.WriteLine();
        while (DateTime.Now < futureTime)
        {

            Console.Write(">");
            string answer = Console.ReadLine();
            answers.Add(answer);
        }
        return answers;
    }
}