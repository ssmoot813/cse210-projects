using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    private List<string> _questions;

    private List<string> _unusedPrompts = new List<string>();
    private List<string> _unusedQuestions = new List<string>();

    public ReflectingActivity()
        : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _count = 0;

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        _count = 0;

        DisplayPrompt();
        DisplayQuestions();
        DisplayCount();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return GetRandomItem(_prompts, _unusedPrompts);
    }

    public string GetRandomQuestion()
    {
        return GetRandomItem(_questions, _unusedQuestions);
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($" --- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        ClearScreen();
    }

    public void DisplayQuestions()
    {
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(10);
            Console.WriteLine();
            _count++;
        }
    }

    public void DisplayCount()
    {
        Console.WriteLine();
        string word = _count == 1 ? "question" : "questions";
        Console.WriteLine($"You reflected on {_count} {word}!");
    }
}