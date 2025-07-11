public class PromptGenerator
{
    public List<string> _prompts = new List<string>([
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    ]);

    public string PickPrompt()
    {
        // I used this https://stackoverflow.com/questions/2019417/how-to-access-random-item-in-list
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string randomPrompt = _prompts[index];
        return randomPrompt;
    }
}