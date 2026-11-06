using System;
using System.Collections.Generic;

public class GroundingActivity : Activity
{
    private List<string> _steps;

    public GroundingActivity()
        : base("Grounding", "This activity will help you calm a busy mind by bringing your attention back to the present moment. You will slowly notice things around you using each of your five senses.")
    {
        _steps = new List<string>
        {
            "Look around and notice 5 things you can SEE.",
            "Notice 4 things you can FEEL, like your feet on the floor.",
            "Listen for 3 things you can HEAR.",
            "Notice 2 things you can SMELL.",
            "Notice 1 thing you can TASTE."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        int secondsPerStep = Math.Max(GetDuration() / _steps.Count, 3);

        foreach (string step in _steps)
        {
            Console.WriteLine();
            Console.Write($"> {step} ");
            ShowSpinner(secondsPerStep);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Take one more slow breath. You are here, right now.");

        DisplayEndingMessage();
    }
}