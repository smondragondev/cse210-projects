using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<Video> videos = new List<Video>();
        Video video1 = new Video("title 1", "author 1", 40);
        Comment video1Comment1 = new Comment("name1", "Comment 1");
        Comment video1Comment2 = new Comment("name2", "Comment 2");
        Comment video1Comment3 = new Comment("name3", "Comment 3");
        Comment video1Comment4 = new Comment("name3", "Comment 4");
        video1.AddComment(video1Comment1);
        video1.AddComment(video1Comment2);
        video1.AddComment(video1Comment3);
        video1.AddComment(video1Comment4);
        videos.Add(video1);

        Video video2 = new Video("title 2", "author 2", 50);
        Comment video2Comment1 = new Comment("name21", "Comment 21");
        Comment video2Comment2 = new Comment("name22", "Comment 22");
        Comment video2Comment3 = new Comment("name23", "Comment 23");
        Comment video2Comment4 = new Comment("name23", "Comment 24");
        video2.AddComment(video2Comment1);
        video2.AddComment(video2Comment2);
        video2.AddComment(video2Comment3);
        video2.AddComment(video2Comment4);
        videos.Add(video2);

        Video video3 = new Video("title 3", "author 3", 1200);
        Comment video3Comment1 = new Comment("name31", "Comment 31");
        Comment video3Comment2 = new Comment("name32", "Comment 32");
        Comment video3Comment3 = new Comment("name33", "Comment 33");
        Comment video3Comment4 = new Comment("name33", "Comment 34");
        video3.AddComment(video3Comment1);
        video3.AddComment(video3Comment2);
        video3.AddComment(video3Comment3);
        video3.AddComment(video3Comment4);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
        }

    }
}