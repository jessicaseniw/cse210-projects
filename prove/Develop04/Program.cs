using System;
using System.Threading;

// Base class for activities
public abstract class MindfulnessActivity
{
    protected string activityName;
    protected string activityDescription;
    protected int durationInSeconds;

    public MindfulnessActivity(string name, string description)
    {
        activityName = name;
        activityDescription = description;
    }

    // Method to set duration
    public void SetDuration(int duration)
    {
        durationInSeconds = duration;
    }

    // Method to display starting message
    public virtual void Start()
    {
        Console.WriteLine($"Starting {activityName} activity...");
        Console.WriteLine(activityDescription);
        Console.WriteLine($"Duration: {durationInSeconds} seconds");
        Thread.Sleep(3000); // Pause for 3 seconds
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(2000); // Pause for 2 seconds
    }

    // Method to display ending message
    public virtual void End()
    {
        Console.WriteLine($"Congratulations! You have completed the {activityName} activity.");
        Console.WriteLine($"Total time: {durationInSeconds} seconds");
        Thread.Sleep(3000); // Pause for 3 seconds
        Console.WriteLine("Returning to main menu...");
        Thread.Sleep(2000); // Pause for 2 seconds
    }

    // Abstract method for activity execution
    public abstract void Execute();
}

// Breathing activity
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    public override void Execute()
    {
        Start();
        Console.WriteLine("Get ready to breathe...");
        Thread.Sleep(2000); // Pause for 2 seconds

        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000); // Pause for 1 second

            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }

        End();
    }
}

// Reflection activity
public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

    public override void Execute()
    {
        Start();
        Random random = new Random();

        Console.WriteLine("Get ready to reflect...");
        Thread.Sleep(2000); // Pause for 2 seconds

        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000); // Pause for 2 seconds

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(4000); // Pause for 4 seconds
            Console.WriteLine("Reflecting...");
            Thread.Sleep(3000); // Pause for 3 seconds
        }

        End();
    }
}

// Listing activity
public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public override void Execute()
    {
        Start();
        Random random = new Random();

        Console.WriteLine("Get ready to list...");
        Thread.Sleep(2000); // Pause for 2 seconds

        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000); // Pause for 2 seconds

        Console.WriteLine("Start listing...");
        Thread.Sleep(2000); // Pause for 2 seconds

        // Simulating user listing items
        int itemCount = 0;
        while (durationInSeconds > 0)
        {
            Console.WriteLine($"Item {++itemCount}");
            Thread.Sleep(1000); // Pause for 1 second
            durationInSeconds--;
        }

        Console.WriteLine($"You listed {itemCount} items.");
        End();
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Choose an activity (1-4): ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            Console.Write("Enter duration in seconds: ");
            int duration = int.Parse(Console.ReadLine());

            activity.SetDuration(duration);
            activity.Execute();
        }
    }
}