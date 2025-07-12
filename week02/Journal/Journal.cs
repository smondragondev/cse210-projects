using Npgsql;
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

    public void SaveToFile()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                entry.SaveToFile(outputFile);
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

    public void SaveToDB()
    {
        string connectionString = ConfigurationHelper.GetConnectionString("DefaultConnection");
        using (NpgsqlDataSource dataSource = NpgsqlDataSource.Create(connectionString))
        {
            foreach (Entry entry in _entries)
            {
                entry.SaveToDB(dataSource);
            }
        }
    }

    public void LoadFromDB()
    {
        string connectionString = ConfigurationHelper.GetConnectionString("DefaultConnection");
        _entries.Clear();
        try
        {
            using (NpgsqlDataSource dataSource = NpgsqlDataSource.Create(connectionString))
            {
                string sql = @"SELECT date,prompt,text FROM entry";

                using var cmd = dataSource.CreateCommand(sql);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string date = reader.GetString(0);
                    string prompt = reader.GetString(1);
                    string entryText = reader.GetString(2);
                    Entry newEntry = new Entry(date: date, promptText: prompt, entryText: entryText);
                    AddEntry(newEntry);
                }
            }
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error loading from DB: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error not db: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
        }
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

}