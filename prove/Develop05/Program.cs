using System;
using System.Collections.Generic;
using System.IO;

// Base class for all types of goals
abstract class Goal
{
    // Private member variables
    private string _name;
    private int _value;
    protected bool _isComplete;

    // Properties
    public string Name { get => _name; }
    public int Value { get => _value; }
    public bool IsComplete { get => _isComplete; }

    // Constructor
    public Goal(string name, int value)
    {
        _name = name;
        _value = value;
        _isComplete = false;
    }

    // Method to mark the goal as complete
    public virtual void MarkComplete()
    {
        _isComplete = true;
    }

    // Method to get the string representation of the goal
    public abstract string GetStringRepresentation();
}

// Simple goal that can be marked complete directly
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override string GetStringRepresentation()
    {
        return $"[ ] {Name}";
    }
}

// Eternal goal that can be completed multiple times
class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    // Override to prevent marking eternal goals as complete
    public override void MarkComplete()
    {
        throw new InvalidOperationException("Eternal goals cannot be marked as complete.");
    }

    public override string GetStringRepresentation()
    {
        return $"[ ] {Name}";
    }
}

// Checklist goal that must be accomplished a certain number of times
class ChecklistGoal : Goal
{
    private int _totalTimes;
    private int _timesCompleted;

    public ChecklistGoal(string name, int value, int totalTimes) : base(name, value)
    {
        _totalTimes = totalTimes;
        _timesCompleted = 0;
    }

    // Override to track progress and check for completion
    public override void MarkComplete()
    {
        _timesCompleted++;
        if (_timesCompleted >= _totalTimes)
        {
            base.MarkComplete();
        }
    }

    public override string GetStringRepresentation()
    {
        return $"[ ] {Name} (Completed {_timesCompleted}/{_totalTimes} times)";
    }
}

// Class to manage the list of goals and user's score
class GoalManager
{
    // Private member variables
    private List<Goal> _goals;
    private int _score;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Method to add a goal
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    // Method to record event and update score
    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            goal.MarkComplete();
            _score += goal.Value;
        }
    }

    // Method to display goals
    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()} {( _goals[i].IsComplete ? "[X]" : "")}");
        }
    }

    // Method to display current score
    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    // Method to save goals to a file
    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    // Method to load goals from a file
    public void LoadGoals(string filename)
    {
        _goals.Clear();
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                // Parse each line to create corresponding goal object
                string[] parts = line.Split(',');
                string goalType = parts[0];
                string name = parts[1];
                int value = int.Parse(parts[2]);
                Goal goal;
                if (goalType == "SimpleGoal")
                {
                    goal = new SimpleGoal(name, value);
                }
                else if (goalType == "EternalGoal")
                {
                    goal = new EternalGoal(name, value);
                }
                else if (goalType == "ChecklistGoal")
                {
                    int totalTimes = int.Parse(parts[3]);
                    goal = new ChecklistGoal(name, value, totalTimes);
                }
                else
                {
                    // Invalid goal type, skip
                    continue;
                }
                _goals.Add(goal);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        // Load goals from file (if available)
        string filename = "goals.txt";
        if (File.Exists(filename))
        {
            goalManager.LoadGoals(filename);
        }

        while (true)
        {
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal name: ");
                    string goalName = Console.ReadLine();
                    Console.Write("Enter goal type (Simple, Eternal, Checklist): ");
                    string goalType = Console.ReadLine();
                    Console.Write("Enter goal value: ");
                    int value = int.Parse(Console.ReadLine());
                    Goal goal;
                    if (goalType == "Simple")
                    {
                        goal = new SimpleGoal(goalName, value);
                    }
                    else if (goalType == "Eternal")
                    {
                        goal = new EternalGoal(goalName, value);
                    }
                    else if (goalType == "Checklist")
                    {
                        Console.Write("Enter total times for checklist goal: ");
                        int totalTimes = int.Parse(Console.ReadLine());
                        goal = new ChecklistGoal(goalName, value, totalTimes);
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal type.");
                        continue;
                    }
                    goalManager.AddGoal(goal);
                    break;
                case "2":
                    Console.Write("Enter the index of the goal to record event: ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    goalManager.RecordEvent(index);
                    break;
                case "3":
                    goalManager.DisplayGoals();
                    break;
                case "4":
                    goalManager.DisplayScore();
                    break;
                case "5":
                    goalManager.SaveGoals(filename);
                    Console.WriteLine("Goals saved successfully.");
                    break;
                case "6":
                    goalManager.SaveGoals(filename);
                    Console.WriteLine("Goals saved. Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
