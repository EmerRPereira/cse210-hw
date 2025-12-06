using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points) 
            : base(name, description, points)
        {
            _isComplete = false;
        }

        // Marked complete once and returns points only the first time.
        public override int RecordEvent()
        {
            if (_isComplete)
                return 0;
            _isComplete = true;
            return _points;
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetDetailsString()
        {
            string status = _isComplete ? "Completed" : "Not completed";
            return $"{_shortName} - {_description} | {status} | Points: {_points}";
        }

        public override string GetStringRepresentation()
        {
            // Format: SimpleGoal:shortName|description|points|isComplete
            return $"SimpleGoal:{Escape(_shortName)}|{Escape(_description)}|{_points}|{_isComplete}";
        }

        private string Escape(string s) => s.Replace("|", "&#124;");

        // Factory method for loading
        public static SimpleGoal FromString(string data)
        {
            // data expected: shortName|description|points|isComplete
            var parts = data.Split('|');
            if (parts.Length < 4) throw new FormatException("Invalid SimpleGoal data");
            var name = parts[0].Replace("&#124;", "|");
            var desc = parts[1].Replace("&#124;", "|");
            int points = int.Parse(parts[2]);
            bool isComplete = bool.Parse(parts[3]);

            var g = new SimpleGoal(name, desc, points);
            if (isComplete) g._isComplete = true;
            return g;
        }
    }
}
