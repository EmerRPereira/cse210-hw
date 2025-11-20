/*
Course: CSE 210: Programming with Classes
W04 Team Activity: Foundation Programs Design - Video Project
Author: Emerson Ronald Pereira
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video()
        {
            Title = "How to Cook Pasta",
            Author = "Chef Master",
            LengthSeconds = 480
        };
        v1.AddComment(new Comment("Maria", "Great recipe!"));
        v1.AddComment(new Comment("João", "I tried this and loved it!"));
        v1.AddComment(new Comment("Carlos", "Very easy to follow."));
        videos.Add(v1);

        // Video 2
        Video v2 = new Video()
        {
            Title = "Learning C# in 10 Minutes",
            Author = "CodeTeacher",
            LengthSeconds = 600
        };
        v2.AddComment(new Comment("Ana", "This helped me so much!"));
        v2.AddComment(new Comment("Luiz", "Clear explanation."));
        v2.AddComment(new Comment("Pedro", "Thanks for the lesson!"));
        videos.Add(v2);

        // Video 3
        Video v3 = new Video()
        {
            Title = "Travel Vlog: Rio de Janeiro",
            Author = "World Explorer",
            LengthSeconds = 720
        };
        v3.AddComment(new Comment("Fernanda", "Beautiful footage!"));
        v3.AddComment(new Comment("Bruno", "I want to visit Rio now!"));
        v3.AddComment(new Comment("Clara", "Amazing video."));
        videos.Add(v3);

        // Display information for each video
        foreach (Video vid in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {vid.Title}");
            Console.WriteLine($"Author: {vid.Author}");
            Console.WriteLine($"Length: {vid.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {vid.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment c in vid.GetComments())
            {
                Console.WriteLine($" - {c.CommenterName}: {c.Text}");
            }

            Console.WriteLine();
        }
    }
}
