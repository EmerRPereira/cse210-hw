/*
======================================================
Course: CSE210
Journal Program - Week 02 Project
Author: Emerson Ronald Pereira
Date: November 2025
======================================================
*/

using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> Entries { get; set; } = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayEntries()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }

        foreach (Entry e in Entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry e in Entries)
                {
                    writer.WriteLine(e.ToFileFormat());
                }
            }
            Console.WriteLine($"Journal saved successfully to '{filename}'\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found. Please check the name and try again.\n");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            Entries.Clear();

            foreach (string line in lines)
            {
                Entry e = Entry.FromFileFormat(line);
                if (e != null)
                {
                    Entries.Add(e);
                }
            }

            Console.WriteLine($"Journal loaded successfully from '{filename}'\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}
