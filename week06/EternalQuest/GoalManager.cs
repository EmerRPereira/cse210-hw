using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public int Score => _score;

        public void AddGoal(Goal goal)
        {
            if (goal != null) _goals.Add(goal);
        }

        public void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                var g = _goals[i];
                Console.WriteLine($"{i + 1}. {g.GetListDisplay()}");
            }
        }

        public void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                var g = _goals[i];
                Console.WriteLine($"{i + 1}. {g.GetDetailsString()}");
            }
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Your current score is: {_score}");
        }

        // user chooses a goal number to record event
        public void RecordEvent(int goalIndex)
        {
            if (goalIndex < 0 || goalIndex >= _goals.Count)
            {
                Console.WriteLine("Invalid goal index.");
                return;
            }

            var g = _goals[goalIndex];
            int gained = g.RecordEvent();
            _score += gained;
            Console.WriteLine($"Recorded event for: {g.GetListDisplay()}");
            Console.WriteLine($"Points gained: {gained}. New score: {_score}");
        }

        // Save to file: first line score, then each goal's GetStringRepresentation on subsequent lines
        public void SaveGoals(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (var g in _goals)
                {
                    writer.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Saved { _goals.Count } goals to {filename}");
        }

        // Load from file: replace current goals and score
        public void LoadGoals(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("File empty.");
                return;
            }

            _goals.Clear();
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                // Each line starts with TypeName:rest
                var splitIndex = line.IndexOf(':');
                if (splitIndex < 0) continue;
                var typeName = line.Substring(0, splitIndex);
                var rest = line.Substring(splitIndex + 1);

                try
                {
                    switch (typeName)
                    {
                        case "SimpleGoal":
                            _goals.Add(SimpleGoal.FromString(rest));
                            break;
                        case "EternalGoal":
                            _goals.Add(EternalGoal.FromString(rest));
                            break;
                        case "ChecklistGoal":
                            _goals.Add(ChecklistGoal.FromString(rest));
                            break;
                        default:
                            Console.WriteLine($"Unknown goal type: {typeName}");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to parse line {i + 1}: {ex.Message}");
                }
            }

            Console.WriteLine($"Loaded {_goals.Count} goals. Score: {_score}");
        }

        public int GoalsCount() => _goals.Count;
    }
}
