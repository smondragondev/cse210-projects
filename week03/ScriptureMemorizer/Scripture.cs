public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        foreach (string wordText in text.Split(" "))
        {
            Word word = new Word(wordText);
            _words.Append(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {

    }

    public string GetDisplayText()
    {
        return "";
    }

    public bool isCompletelyHidden()
    {
        return false;
    }
}