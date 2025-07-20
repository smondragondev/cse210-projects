using System.Text.Json;
using System.Text.Json.Nodes;
public class ScriptureGenerator
{
    List<Scripture> _scriptures = new List<Scripture>();

    public ScriptureGenerator()
    {
        this.ReadScripturesFromJson();
    }
    private void ReadScripturesFromJson()
    {
        string book = "";
        int chapter = 0;
        int verse = 0;
        string scriptureText = "";

        using (StreamReader r = new StreamReader("lds-scriptures-json.json"))
        {
            string json = r.ReadToEnd();
            // JsonNode scriptureNode = JsonNode.Parse(json);
            using (JsonDocument document = JsonDocument.Parse(json))
            {
                JsonElement root = document.RootElement;
                foreach (JsonElement scriptureElement in root.EnumerateArray())
                {
                    if (scriptureElement.TryGetProperty("book_title", out JsonElement bookElement))
                    {
                        book = bookElement.GetString();
                    }
                    if (scriptureElement.TryGetProperty("chapter_number", out JsonElement chapterElement))
                    {
                        chapter = chapterElement.GetInt16();
                    }
                    if (scriptureElement.TryGetProperty("verse_number", out JsonElement verseElement))
                    {
                        verse = verseElement.GetInt16();
                    }
                    if (scriptureElement.TryGetProperty("scripture_text", out JsonElement scriptureTextElement))
                    {
                        scriptureText = scriptureTextElement.GetString();
                    }
                    if (book != "" && chapter != 0 && verse != 0 && scriptureText != "")
                    {
                        Reference reference = new Reference(book, chapter, verse);
                        Scripture scripture = new Scripture(reference, scriptureText);
                        _scriptures.Add(scripture);
                    }
                }
            }
        }
    }

    public Scripture PickRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        Scripture randomScripture = _scriptures[index];
        return randomScripture;
    }
}