using System;
using System.Collections.Generic;

/*
 * Exceeding requirements:
 * 1. A fourth activity. GroundingActivity is a new class derived from Activity that
 *    walks the user through the 5-4-3-2-1 grounding exercise (see, feel, hear,
 *    smell, taste). It reuses the inherited starting/ending messages and spinner.
 * 2. Animated breathing. Each breath shows a bar that grows quickly at first and
 *    slows near the end of the breath in, then shrinks the same way on the breath
 *    out, with the seconds counting down beside it.
 * 3. Saving and loading a log file. ActivityLog appends every completed activity
 *    (date, name, seconds) to mindfulness_log.txt and loads it when the program
 *    starts. The menu shows how many times each activity has been done across all
 *    sessions, and quitting shows all-time totals of times and seconds.
 * 4. No repeated prompts or questions. ReflectingActivity and ListingActivity keep
 *    a list of the prompts/questions not yet shown this session. The shared
 *    GetRandomItem() method in the Activity base class picks one from that list and
 *    removes it, so nothing repeats until all have been used, then the list refills.
 * 5. Input checking. The duration must be a whole number greater than 0, and an
 *    invalid menu choice shows a message instead of crashing.
 * 6. The Reflecting Activity reports how many questions the user reflected on.
 */
class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathing = new BreathingActivity();
        ReflectingActivity reflecting = new ReflectingActivity();
        ListingActivity listing = new ListingActivity();
        GroundingActivity grounding = new GroundingActivity();

        List<string> activityNames = new List<string>
        {
            breathing.GetName(),
            reflecting.GetName(),
            listing.GetName(),
            grounding.GetName()
        };

        ActivityLog log = new ActivityLog("mindfulness_log.txt");
        log.LoadFromFile();

        string choice = "";

        while (choice != "5")
        {
            Activity.ClearScreen();
            Console.WriteLine("Menu Options:");
            Console.WriteLine($"  1. Start breathing activity   (done {log.GetTimesCompleted(breathing.GetName())}x)");
            Console.WriteLine($"  2. Start reflecting activity  (done {log.GetTimesCompleted(reflecting.GetName())}x)");
            Console.WriteLine($"  3. Start listing activity     (done {log.GetTimesCompleted(listing.GetName())}x)");
            Console.WriteLine($"  4. Start grounding activity   (done {log.GetTimesCompleted(grounding.GetName())}x)");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == null)
            {
                choice = "5";
            }

            if (choice == "1")
            {
                breathing.Run();
                log.AddEntry(breathing.GetName(), breathing.GetDuration());
            }
            else if (choice == "2")
            {
                reflecting.Run();
                log.AddEntry(reflecting.GetName(), reflecting.GetDuration());
            }
            else if (choice == "3")
            {
                listing.Run();
                log.AddEntry(listing.GetName(), listing.GetDuration());
            }
            else if (choice == "4")
            {
                grounding.Run();
                log.AddEntry(grounding.GetName(), grounding.GetDuration());
            }
            else if (choice != "5")
            {
                Console.WriteLine("Please choose 1, 2, 3, 4, or 5.");
                breathing.ShowSpinner(2);
            }
        }

        Console.WriteLine();
        log.DisplaySummary(activityNames);
        Console.WriteLine("Thanks for taking time to be mindful. Goodbye!");
    }
}