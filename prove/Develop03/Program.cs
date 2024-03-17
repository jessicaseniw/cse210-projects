using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a scripture object
            var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

            // Initialize a variable to track if all words are hidden
            bool allWordsHidden = false;

            // Loop until all words are hidden or user quits
            while (!allWordsHidden)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                // Hide a few random words
                allWordsHidden = scripture.HideRandomWords(2);
            }
        }
    }

    class Scripture
    {
        private readonly string _reference;
        private readonly List<Word> _words;

        public Scripture(string reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public bool HideRandomWords(int numberToHide)
        {
            // Randomly select words to hide
            var random = new Random();
            var visibleWords = _words.Where(word => !word.IsHidden()).ToList();
            if (visibleWords.Count <= numberToHide)
            {
                foreach (var word in visibleWords)
                {
                    word.Hide();
                }
                return true;
            }

            for (int i = 0; i < numberToHide; i++)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }

            return visibleWords.Count == 0;
        }

        public string GetDisplayText()
        {
            return $"{_reference}\n{_words.Select(word => word.GetDisplayText()).Aggregate((current, next) => current + " " + next)}";
        }
    }

    class Word
    {
        private readonly string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public void Show()
        {
            _isHidden = false;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            return _isHidden ? new string('_', _text.Length) : _text;
        }
    }
}