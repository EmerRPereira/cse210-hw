/*
======================================================
Course: CSE210
Journal Program - Week 02 Project
Author: Emerson Ronald Pereira
Date: November 2025

EXCEEDING REQUIREMENTS:
- Saved as CSV with custom separator (|) for easy Excel compatibility
- Includes time (HH:mm:ss) with date
- Error handling for file operations
- Added additional prompts for variety
======================================================
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        Random random = new Random();

        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something I learned today?",
            "What am I grateful for today?",
            "What challenge did I face today and how did I handle it?"
        };

        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Please select one option (1-5): ");

            string input = Console.ReadLine();
            Console.WriteLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.\n");
                continue;
            }

            switch (choice)
            {
                case 1:
                    string prompt = prompts[random.Next(prompts.Count)];
                    Console.WriteLine(prompt);
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    myJournal.AddEntry(new Entry(prompt, response));
                    Console.WriteLine("Entry added successfully!\n");
                    break;

                case 2:
                    myJournal.DisplayEntries();
                    break;

                case 3:
                    Console.Write("Enter filename to save (e.g., journal.csv): ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;

                case 4:
                    Console.Write("Enter filename to load (e.g., journal.csv): ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;

                case 5:
                    Console.WriteLine("Goodbye! Have a great day journaling!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select between 1 and 5.\n");
                    break;
            }
        }
    }
}

