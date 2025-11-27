/*
Course: C210
Activity: Mindfulness Program - Program.cs
C# Console Application implementing Week 05 Mindfulness Program
Author: Emerson Ronald Pereira
Features: Breathing, Reflection, and Listing activities
Design: Base Activity class with derived activities (BreathingActivity, ReflectionActivity, ListingActivity)
Exceeded requirements: 
  - Ensures no prompt/question repeats in a session until all have been used (shuffled queue)
  - Simple session log saved to "mindfulness_log.txt" with timestamp and activity/duration
  - Clean animations (spinner and numeric countdown)
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ListingActivity(); break;
                case "3": activity = new ReflectingActivity(); break;
                case "4": return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
        }
    }
}
