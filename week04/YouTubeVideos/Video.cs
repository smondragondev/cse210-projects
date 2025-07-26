using System.Data;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public int GetCommentsNumber()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}, Author: {_author}, Length: {_length}");
        Console.WriteLine($"Number of comments: {GetCommentsNumber()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in _comments)
        {
            string commentText = comment.GetDisplayText();
            Console.WriteLine(commentText);
        }
    }
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
}