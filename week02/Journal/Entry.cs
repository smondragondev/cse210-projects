using Npgsql;
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

    public void SaveToFile(StreamWriter outputFile)
    {
        outputFile.WriteLine($"{_date}|{_promptText}|{_entryText}");
    }

    public void SaveToDB(NpgsqlDataSource dataSource)
    {
        string sql = @"INSERT INTO entry(date,prompt,text)" +
                    " values(@date,@prompt,@text)";
        try
        {
            using var cmd = dataSource.CreateCommand(sql);
            cmd.Parameters.AddWithValue("@date", _date);
            cmd.Parameters.AddWithValue("@prompt", _promptText);
            cmd.Parameters.AddWithValue("@text", _entryText);
            cmd.ExecuteNonQuery();
        }
        catch (NpgsqlException ex)
        {
            Console.WriteLine($"Error inserting into DB: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error not db: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
        }
    }

    
}