using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirements
        Console.Write("Enter your grade percentage: ");
        double gradePercentage = double.Parse(Console.ReadLine());

        char letter;

        if (gradePercentage >= 90)
            letter = 'A';
        else if (gradePercentage >= 80)
            letter = 'B';
        else if (gradePercentage >= 70)
            letter = 'C';
        else if (gradePercentage >= 60)
            letter = 'D';
        else
            letter = 'F';

        bool passed = gradePercentage >= 70;

        if (passed)
            Console.WriteLine($"Congratulations! You passed the course with a {letter}.");
        else
            Console.WriteLine($"Keep up the good work! You received a {letter}.");

        // Stretch Challenge
        char sign = ' '; // Initialize sign with a space character

        if (letter == 'A' || letter == 'B' || letter == 'C')
        {
            int lastDigit = (int)(gradePercentage % 10);
            if (lastDigit >= 7)
                sign = '+';
            else if (lastDigit < 3 && letter != 'F') // Skip assigning '-' for 'F'
                sign = '-';
        }
    }
}