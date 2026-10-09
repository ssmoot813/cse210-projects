using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// Holds the list of entries and handles displaying, saving, and loading them.
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            Console.WriteLine();
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves the journal as a CSV file that can be opened in Excel.
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Date,Prompt,Entry");

            foreach (Entry entry in _entries)
            {
                string line = ToCsvField(entry._date) + ","
                            + ToCsvField(entry._promptText) + ","
                            + ToCsvField(entry._entryText);
                outputFile.WriteLine(line);
            }
        }
    }

    // Loads the journal from a CSV file, replacing any current entries.
    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        _entries.Clear();

        // Start at 1 to skip the header row.
        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Trim() == "")
            {
                continue;
            }

            List<string> parts = ParseCsvLine(lines[i]);
            if (parts.Count < 3)
            {
                continue;
            }

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];
            _entries.Add(entry);
        }
    }

    // Wraps a value in quotes and doubles any quotes inside it,
    // so commas and quotation marks in the content are stored safely.
    private string ToCsvField(string value)
    {
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }

    // Splits one CSV line into its fields, respecting quoted values.
    private List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        StringBuilder current = new StringBuilder();
        bool insideQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (insideQuotes)
            {
                if (c == '"')
                {
                    // Two quotes in a row mean a literal quote character.
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current.Append('"');
                        i++;
                    }
                    else
                    {
                        insideQuotes = false;
                    }
                }
                else
                {
                    current.Append(c);
                }
            }
            else
            {
                if (c == '"')
                {
                    insideQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(current.ToString());
                    current.Clear();
                }
                else
                {
                    current.Append(c);
                }
            }
        }

        fields.Add(current.ToString());
        return fields;
    }
}