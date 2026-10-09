using System;
using System.IO;

// EXCEEDING REQUIREMENTS:
// 1. The journal is saved and loaded as a real .csv file that opens in Excel.
//    Each field is wrapped in quotes and any quotation marks in the content
//    are escaped, so commas and quotes in an entry are handled correctly.
// 2. The PromptGenerator does not repeat a prompt until every prompt in the
//    list has been used, so the user is not asked the same question twice
//    in a row. This helps with the problem of not knowing what to write.
// 3. Loading a file that does not exist shows a message instead of crashing.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);
                Console.WriteLine();
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                if (File.Exists(filename))
                {
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded.");
                }
                else
                {
                    Console.WriteLine("That file was not found.");
                }
                Console.WriteLine();
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
                Console.WriteLine("Journal saved.");
                Console.WriteLine();
            }
            else if (choice != "5")
            {
                Console.WriteLine("Please enter a number from 1 to 5.");
                Console.WriteLine();
            }
        }
    }
}