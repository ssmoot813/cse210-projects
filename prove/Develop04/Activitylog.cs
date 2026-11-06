using System;
using System.Collections.Generic;
using System.IO;

public class ActivityLog
{
    private string _fileName;
    private List<string> _entries;

    public ActivityLog(string fileName)
    {
        _fileName = fileName;
        _entries = new List<string>();
    }

    public void LoadFromFile()
    {
        _entries.Clear();

        if (File.Exists(_fileName))
        {
            string[] lines = File.ReadAllLines(_fileName);

            foreach (string line in lines)
            {
                if (line.Split('|').Length == 3)
                {
                    _entries.Add(line);
                }
            }
        }
    }

    public void AddEntry(string activityName, int seconds)
    {
        string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm}|{activityName}|{seconds}";
        _entries.Add(entry);
        File.AppendAllText(_fileName, entry + Environment.NewLine);
    }

    public int GetTimesCompleted(string activityName)
    {
        int count = 0;

        foreach (string entry in _entries)
        {
            if (entry.Split('|')[1] == activityName)
            {
                count++;
            }
        }

        return count;
    }

    public int GetTotalSeconds(string activityName)
    {
        int total = 0;

        foreach (string entry in _entries)
        {
            string[] parts = entry.Split('|');
            int seconds;

            if (parts[1] == activityName && int.TryParse(parts[2], out seconds))
            {
                total += seconds;
            }
        }

        return total;
    }

    public void DisplaySummary(List<string> activityNames)
    {
        Console.WriteLine("All-time totals (saved in " + _fileName + "):");

        foreach (string name in activityNames)
        {
            int times = GetTimesCompleted(name);
            string timesWord = times == 1 ? "time" : "times";
            Console.WriteLine($"  {name,-11} {times} {timesWord}, {GetTotalSeconds(name)} seconds");
        }
    }
}