using System;
using System.Collections.Generic;
using System.IO;

public static class ScriptureLoader
{
    public static List<Scripture> LoadFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: scriptures.txt not found.");
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Formato:
            // Book|Chapter|Verse(-EndVerse)|Text
            string[] parts = line.Split('|');

            string book = parts[0];
            int chapter = int.Parse(parts[1]);
            string verseInfo = parts[2];
            string text = parts[3];

            Reference reference;

            if (verseInfo.Contains("-"))
            {
                string[] verses = verseInfo.Split('-');
                reference = new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
            }
            else
            {
                reference = new Reference(book, chapter, int.Parse(verseInfo));
            }

            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}
