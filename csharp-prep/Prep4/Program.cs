using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<double> numbers = new List<double>();
        double num;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            num = Convert.ToDouble(Console.ReadLine());
            numbers.Add(num);
        }
        while (num != 0);

        // Remove the terminating 0
        numbers.RemoveAt(numbers.Count - 1);

        double sum = numbers.Sum();
        double average = sum / numbers.Count;
        double max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge
        List<double> positiveNumbers = numbers.Where(n => n > 0).ToList();
        double minPositive = positiveNumbers.Any() ? positiveNumbers.Min() : double.NaN;

        Console.WriteLine($"The smallest positive number is: {minPositive}");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        numbers.ForEach(Console.WriteLine);
    }
}
