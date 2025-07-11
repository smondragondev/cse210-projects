public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
    public Entry(string promptText, string entryText)
    {
        DateTime theCurrentTime = DateTime.Now;
        _date = theCurrentTime.ToShortDateString();
        _promptText = promptText;
        _entryText = entryText;
    }

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }


    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
    }

    public void SaveInFile(StreamWriter outputFile)
    {
        outputFile.WriteLine($"{_date}|{_promptText}|{_entryText}");
    }
}