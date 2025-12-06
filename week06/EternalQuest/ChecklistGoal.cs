using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus; // bonus when target reached

        public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }

        // Return points for each record; add bonus when reaching target.
        public override int RecordEvent()
        {
            if (IsComplete())
                return 0;

            _amountCompleted++;
            int earned = _points;
            if (_amountCompleted >= _target)
            {
                earned += _bonus;
            }
            return earned;
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target;
        }

        public override string GetDetailsString()
        {
            string status = $"Completed {_amountCompleted}/{_target}";
            if (IsComplete()) status += " (Finished)";
            return $"{_shortName} - {_description} | {status} | Each: {_points} pts | Bonus: {_bonus} pts";
        }

        public override string GetStringRepresentation()
        {
            // Format: ChecklistGoal:shortName|description|points|amountCompleted|target|bonus
            return $"ChecklistGoal:{Escape(_shortName)}|{Escape(_description)}|{_points}|{_amountCompleted}|{_target}|{_bonus}";
        }

        private string Escape(string s) => s.Replace("|", "&#124;");

        public static ChecklistGoal FromString(string data)
        {
            var parts = data.Split('|');
            if (parts.Length < 6) throw new FormatException("Invalid ChecklistGoal data");
            var name = parts[0].Replace("&#124;", "|");
            var desc = parts[1].Replace("&#124;", "|");
            int points = int.Parse(parts[2]);
            int amountCompleted = int.Parse(parts[3]);
            int target = int.Parse(parts[4]);
            int bonus = int.Parse(parts[5]);

            var g = new ChecklistGoal(name, desc, points, target, bonus);
            g._amountCompleted = amountCompleted;
            return g;
        }
    }
}
