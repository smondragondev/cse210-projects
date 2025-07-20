public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string hiddenText = "";
            foreach (char c in _text)
            {
                hiddenText += "_";
            }
            return hiddenText;
        }
        return _text;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
}