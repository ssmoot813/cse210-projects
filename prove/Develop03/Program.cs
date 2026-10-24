using System;
using System.Collections.Generic;
using System.IO;

/*
 * Exceeding requirements:
 * 1. Scripture library: the program loads scriptures from scriptures.txt
 *    (one per line: Book|Chapter|StartVerse|EndVerse|Text) and picks one at
 *    random each time it runs. If the file is missing, it falls back to a
 *    small built-in library so the program still works.
 * 2. Stretch challenge: HideRandomWords only chooses words that are not
 *    already hidden, so every round hides new words.
 * 3. Hint feature: typing "hint" reveals one hidden word, for when the
 *    user gets stuck partway through memorizing.
 * 4. Progress: the percent of the scripture hidden is shown each round.
 */

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = LoadScriptures("Scriptures.txt");
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine($"{scripture.GetPercentHidden()}% hidden");

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Every word is hidden. Great work!");
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to continue, type 'hint' for help, or type 'quit' to finish: ");
            string input = (Console.ReadLine() ?? "").Trim().ToLower();

            if (input == "quit")
            {
                break;
            }
            else if (input == "hint")
            {
                scripture.ShowRandomWord();
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }
    }

    static List<Scripture> LoadScriptures(string fileName)
    {
        List<Scripture> library = new List<Scripture>();

        if (File.Exists(fileName))
        {
            foreach (string line in File.ReadAllLines(fileName))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');
                if (parts.Length != 5)
                {
                    continue;
                }

                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                int startVerse = int.Parse(parts[2]);
                string endVerseText = parts[3];
                string text = parts[4];

                Reference reference;
                if (string.IsNullOrWhiteSpace(endVerseText))
                {
                    reference = new Reference(book, chapter, startVerse);
                }
                else
                {
                    reference = new Reference(book, chapter, startVerse, int.Parse(endVerseText));
                }

                library.Add(new Scripture(reference, text));
            }
        }

        if (library.Count == 0)
        {
            library.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
            library.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        }

        return library;
    }
}