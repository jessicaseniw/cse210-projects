using System;
using System.Collections.Generic;
using System.IO;

// Class to represent an entry in the journal
class Entry
{
    // Properties for prompt, response, and date
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    // Constructor to initialize the entry with prompt, response, and date
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Method to display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }
}

// Class to represent the journal
class Journal
{
    private List<Entry> _entries = new List<Entry>(); // List to store journal entries

    // Method to add an entry to the journal
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Method to display all entries in the journal
    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    // Method to save the journal to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
    }

    // Method to load the journal from a file
    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            string[] parts = line.Split(',');
            string date = parts[0];
            string prompt = parts[1];
            string response = parts[2];
            _entries.Add(new Entry(prompt, response, date));
        }
    }

    // Method to get a random prompt from predefined prompts
    public string GetRandomPrompt()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        Random rnd = new Random();
        int index = rnd.Next(prompts.Length);
        return prompts[index];
    }
}

// Main program class
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal(); // Create a new journal object
        string filename = ""; // Variable to store filename for saving/loading

        bool exit = false; // Variable to control program exit

        // Main program loop
        while (!exit)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            // Switch case for user options
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Writing a new entry...");
                    string response = GetUserResponse(journal.GetRandomPrompt());
                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    Console.WriteLine("Describe the rest of your day:");
                    string restOfDay = Console.ReadLine();
                    journal.AddEntry(new Entry(response, restOfDay, date));
                    break;
                case "2":
                    Console.WriteLine("Displaying the journal...\n");
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.WriteLine("Saving the journal to a file...");
                    if (!string.IsNullOrEmpty(filename))
                        journal.SaveToFile(filename);
                    else
                    {
                        Console.Write("Enter filename to save: ");
                        filename = Console.ReadLine();
                        journal.SaveToFile(filename);
                    }
                    break;
                case "4":
                    Console.WriteLine("Loading the journal from a file...");
                    Console.Write("Enter filename to load: ");
                    filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
                    break;
                case "5":
                    Console.WriteLine("Exiting the program...");
                    exit = true; // Set exit flag to true to exit the loop
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Method to get user response for a given prompt
    static string GetUserResponse(string prompt)
    {
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        return Console.ReadLine();
    }
}