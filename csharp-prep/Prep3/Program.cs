using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            Console.WriteLine("Welcome to Guess My Number!");
            PlayGame();
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "yes";
        }

        Console.WriteLine("Thanks for playing!");
    }

    static void PlayGame()
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        int guessCount = 0;
        int guess = 0;

        Console.WriteLine("I've picked a magic number between 1 and 100. Try to guess it!");

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = Convert.ToInt32(Console.ReadLine());
            guessCount++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

        Console.WriteLine($"You guessed the magic number {magicNumber} in {guessCount} guesses!");
    }
}
