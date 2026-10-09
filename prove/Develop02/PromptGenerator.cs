using System;
using System.Collections.Generic;

// Supplies random journal prompts. A prompt is not repeated until
// every prompt in the list has been used once.
public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something I learned today?",
        "What is one thing I am grateful for today?",
        "What did I do today to help someone else?",
        "What is something I am looking forward to tomorrow?"
    };

    private List<string> _unusedPrompts = new List<string>();
    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        // Refill the unused list once every prompt has been shown.
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }

        int index = _random.Next(_unusedPrompts.Count);
        string prompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);

        return prompt;
    }
}