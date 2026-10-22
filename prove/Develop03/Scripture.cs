using System;
using System.Collections.Generic;

// Holds a scripture's reference and its list of words, and controls hiding them.
public class Scripture
{
    private List<Word> _scripture = new List<Word>();
    private Reference _scriptureReference;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _scriptureReference = reference;

        string[] pieces = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string piece in pieces)
        {
            _scripture.Add(new Word(piece));
        }
    }

    // Stretch challenge: only picks from words that are still visible,
    // so every press of Enter makes real progress.
    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _scripture)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].HideWord();
            visibleWords.RemoveAt(index);
        }
    }

    // Brings back one random hidden word as a hint.
    public void ShowRandomWord()
    {
        List<Word> hiddenWords = new List<Word>();
        foreach (Word word in _scripture)
        {
            if (word.IsHidden())
            {
                hiddenWords.Add(word);
            }
        }

        if (hiddenWords.Count > 0)
        {
            hiddenWords[_random.Next(hiddenWords.Count)].Show();
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _scripture)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

    public int GetPercentHidden()
    {
        int hidden = 0;
        foreach (Word word in _scripture)
        {
            if (word.IsHidden())
            {
                hidden++;
            }
        }

        return hidden * 100 / _scripture.Count;
    }

    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();
        foreach (Word word in _scripture)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return $"{_scriptureReference.GetReference()} {string.Join(" ", displayWords)}";
    }
}