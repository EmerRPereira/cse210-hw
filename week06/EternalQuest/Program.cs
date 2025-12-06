//W06 Project: Eternal Quest Program
//CSE210 - Eternal Quest
//Author: Emerson Ronald Pereira (06/122025)

using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new GoalManager();
            Console.WriteLine("Welcome to Eternal Quest!");
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. List goal names");
                Console.WriteLine("3. List goal details");
                Console.WriteLine("4. Record event for a goal");
                Console.WriteLine("5. Show score");
                Console.WriteLine("6. Save goals to file");
                Console.WriteLine("7. Load goals from file");
                Console.WriteLine("8. Quit");
                Console.Write("Choose an option (1-8): ");
                var input = Console.ReadLine()?.Trim();

                switch (input)
                {
                    case "1":
                        CreateGoalFlow(manager);
                        break;
                    case "2":
                        manager.ListGoalNames();
                        break;
                    case "3":
                        manager.ListGoalDetails();
                        break;
                    case "4":
                        RecordEventFlow(manager);
                        break;
                    case "5":
                        manager.DisplayPlayerInfo();
                        break;
                    case "6":
                        Console.Write("Enter filename to save to: ");
                        var saveFile = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(saveFile))
                            manager.SaveGoals(saveFile);
                        break;
                    case "7":
                        Console.Write("Enter filename to load from: ");
                        var loadFile = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(loadFile))
                            manager.LoadGoals(loadFile);
                        break;
                    case "8":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }

        static void CreateGoalFlow(GoalManager manager)
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("A. Simple Goal");
            Console.WriteLine("B. Eternal Goal");
            Console.WriteLine("C. Checklist Goal");
            Console.Write("Choice (A/B/C): ");
            string choice = Console.ReadLine()?.Trim().ToUpperInvariant();

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Description: ");
            string desc = Console.ReadLine();
            Console.Write("Points (integer): ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points. Aborting creation.");
                return;
            }

            switch (choice)
            {
                case "A":
                    manager.AddGoal(new SimpleGoal(name, desc, points));
                    Console.WriteLine("Simple goal created.");
                    break;
                case "B":
                    manager.AddGoal(new EternalGoal(name, desc, points));
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "C":
                    Console.Write("Target number of times (integer): ");
                    if (!int.TryParse(Console.ReadLine(), out int target))
                    {
                        Console.WriteLine("Invalid target. Aborting.");
                        return;
                    }
                    Console.Write("Bonus points on completion (integer): ");
                    if (!int.TryParse(Console.ReadLine(), out int bonus))
                    {
                        Console.WriteLine("Invalid bonus. Aborting.");
                        return;
                    }
                    manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    Console.WriteLine("Checklist goal created.");
                    break;
                default:
                    Console.WriteLine("Unknown type; aborting.");
                    break;
            }
        }

        static void RecordEventFlow(GoalManager manager)
        {
            if (manager.GoalsCount() == 0)
            {
                Console.WriteLine("No goals to record.");
                return;
            }

            manager.ListGoalNames();
            Console.Write("Enter goal number to record (integer): ");
            if (!int.TryParse(Console.ReadLine(), out int idx))
            {
                Console.WriteLine("Invalid number.");
                return;
            }
            manager.RecordEvent(idx - 1);
        }
    }
}
