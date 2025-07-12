public class PromptGenerator
{
    public List<string> _prompts = new List<string>([
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What scriptures did I read today?",
        "How did I feel the love of our Lord today?",
        "What blessings did I count in my life today?",
        "Did I learn something new today?",
        "Did I help someone today? Who?",
        "Did I do something to improve and magnify my calling?",
        "Did I have any impressions from the Holy Ghost today?",
        "Did I exercise today?",
        "How was my life as a dad today?",
        "How was work today?",
    ]);

    public string PickPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string randomPrompt = _prompts[index];
        return randomPrompt;
    }
}
