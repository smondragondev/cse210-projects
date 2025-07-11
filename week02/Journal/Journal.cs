public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine("*********************  JOURNAL *********************");
        Console.WriteLine();
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveFromFile()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                entry.SaveInFile(outputFile);
            }
        }
    }

    public void LoadFromFile()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(filename);
        // Clear the list of entries
        _entries.Clear();
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            string date = parts[0];
            string prompt = parts[1];
            string entryText = parts[2];
            Entry newEntry = new Entry(date: date, promptText: prompt, entryText: entryText);
            AddEntry(newEntry);
        }
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    
}