/*
Course: CSE210
W03 Project: Scripture Memorizer Program
Author: Emerson Ronald Pereira
Date: November 2025
EXCEED REQUIREMENTS (CREATIVITY):
    * 1. Scriptures are loaded dynamically from an external file (scriptures.txt).
    * 2. A random scripture is selected each time the program runs.
    * 3. Words are hidden only once (stretch requirement).
    * 4. The user can practice multiple scriptures without editing code.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        List<Scripture> scriptures = ScriptureLoader.LoadFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures loaded. Program terminated.");
            return;
        }

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press ENTER to hide more words or type 'quit' to end.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden! Great job!");
                break;
            }
        }
    }
}
