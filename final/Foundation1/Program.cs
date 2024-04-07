// I am working on the Foundation 4 version of the final project. Up to now, I have completed the following steps:

// 1. **Foundation Program #1 (Abstraction):**
//    - Created classes `Comment` and `Video` to represent YouTube comments and videos, respectively.
//    - Implemented methods to add comments to videos, count the number of comments, and display detailed video information including comments.

// In the `Main` program, I instantiated these classes to simulate customer orders with different products and addresses. For each order, I calculated and displayed details such as packing labels, shipping labels, and total costs.

// These steps represent the progress so far in implementing the Foundation 4 project. The code is structured using principles of abstraction and encapsulation to model and manipulate entities related to YouTube videos and online product orders.

using System;
using System.Collections.Generic;

// Class to represent a comment on a video
public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

// Class to represent a YouTube video
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // Method to display video information and comments
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length (seconds): {LengthInSeconds}");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        
        if (GetNumberOfComments() > 0)
        {
            Console.WriteLine("Comments:");
            foreach (var comment in Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }
        }

        Console.WriteLine(); // Add blank line for separation
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create some video objects
        Video video1 = new Video("Introduction to C#", "John Doe", 300);
        Video video2 = new Video("Object-Oriented Programming Basics", "Jane Smith", 450);
        Video video3 = new Video("Working with Collections in C#", "Mike Johnson", 600);

        // Add comments to the videos
        video1.AddComment(new Comment("Alice", "Great video, very informative!"));
        video1.AddComment(new Comment("Bob", "Could you cover more advanced topics in future videos?"));
        video1.AddComment(new Comment("Charlie", "I liked the clear explanations."));

        video2.AddComment(new Comment("Eve", "This helped me understand classes better."));
        video2.AddComment(new Comment("Frank", "Nice presentation style!"));

        video3.AddComment(new Comment("Grace", "Could you do a tutorial on LINQ next?"));
        video3.AddComment(new Comment("Hank", "Looking forward to more videos from you!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
