using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points) 
            : base(name, description, points)
        {
        }

        // Every time it's recorded, return points. Never completes.
        public override int RecordEvent()
        {
            return _points;
        }

        public override bool IsComplete()
        {
            return false;
        }

        public override string GetDetailsString()
        {
            return $"{_shortName} - {_description} | Eternal (every record gives {_points} pts)";
        }

        public override string GetStringRepresentation()
        {
            // Format: EternalGoal:shortName|description|points
            return $"EternalGoal:{Escape(_shortName)}|{Escape(_description)}|{_points}";
        }

        private string Escape(string s) => s.Replace("|", "&#124;");

        public static EternalGoal FromString(string data)
        {
            var parts = data.Split('|');
            if (parts.Length < 3) throw new FormatException("Invalid EternalGoal data");
            var name = parts[0].Replace("&#124;", "|");
            var desc = parts[1].Replace("&#124;", "|");
            int points = int.Parse(parts[2]);
            return new EternalGoal(name, desc, points);
        }
    }
}
