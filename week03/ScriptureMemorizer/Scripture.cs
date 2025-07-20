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
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide=3)
    {
        Random random = new Random();
        int hiddenWords = 0;
        int availableWords = _words.Count(word => !word.IsHidden());
        numberToHide = Math.Min(availableWords, numberToHide);
        
        while (hiddenWords != numberToHide)
        {
            int index = random.Next(_words.Count);
            Word randomWord = _words[index];
            if (!randomWord.IsHidden())
            {
                hiddenWords++;
            }
            randomWord.Hide();
        }

    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string wordsText = "";
        foreach (Word word in _words)
        {
            wordsText += word.GetDisplayText() + " ";
        }
        wordsText = wordsText.Trim();
        return $"{referenceText} {wordsText}";
    }

    public bool isCompletelyHidden()
    {
        Word visibleWord = _words.Find(word => !word.IsHidden());
        return visibleWord == null ? true : false;
    }
}