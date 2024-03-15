using System;

namespace FractionExample
{
    public class Fraction
    {
        // Private attributes for numerator and denominator
        private int numerator;
        private int denominator;

        // Constructors
        public Fraction()
        {
            numerator = 1;
            denominator = 1;
        }

        public Fraction(int num)
        {
            numerator = num;
            denominator = 1;
        }

        public Fraction(int num, int denom)
        {
            numerator = num;
            if (denom != 0)
                denominator = denom;
            else
                throw new ArgumentException("Denominator cannot be zero.");
        }

        // Getters and setters for numerator and denominator
        public int GetNumerator()
        {
            return numerator;
        }

        public void SetNumerator(int num)
        {
            numerator = num;
        }

        public int GetDenominator()
        {
            return denominator;
        }

        public void SetDenominator(int denom)
        {
            if (denom != 0)
                denominator = denom;
            else
                throw new ArgumentException("Denominator cannot be zero.");
        }

        // Method to return the fraction representation as a string
        public string GetFractionString()
        {
            return $"{numerator}/{denominator}";
        }

        // Method to return the decimal value of the fraction
        public double GetDecimalValue()
        {
            return (double)numerator / denominator;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Testing the Fraction class

            // Using the first constructor
            Fraction fraction1 = new Fraction();
            Console.WriteLine(fraction1.GetFractionString());
            Console.WriteLine(fraction1.GetDecimalValue());

            // Using the second constructor
            Fraction fraction2 = new Fraction(5);
            Console.WriteLine(fraction2.GetFractionString());
            Console.WriteLine(fraction2.GetDecimalValue());

            // Using the third constructor
            Fraction fraction3 = new Fraction(3, 4);
            Console.WriteLine(fraction3.GetFractionString());
            Console.WriteLine(fraction3.GetDecimalValue());

            // Using the third constructor
            Fraction fraction4 = new Fraction(1, 3);
            Console.WriteLine(fraction4.GetFractionString());
            Console.WriteLine(fraction4.GetDecimalValue());
        }
    }
}
