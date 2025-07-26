public class Comment
{
    private string _personName;
    private string _textContent;

    public Comment(string personName, string textContent)
    {
        _personName = personName;
        _textContent = textContent;
    }

    public string GetDisplayText()
    {
        return $"{_personName} : {_textContent}";
    }
}