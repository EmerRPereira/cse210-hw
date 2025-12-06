using System;

namespace EternalQuest
{
    // Base class for all goals
    public abstract class Goal
    {
        // member variables (encapsulated)
        protected string _shortName;
        protected string _description;
        protected int _points;

        // constructor
        protected Goal(string name, string description, int points)
        {
            _shortName = name ?? "";
            _description = description ?? "";
            _points = points;
        }

        // When a goal is achieved/recorded. Returns the points earned by this record (could be 0).
        public abstract int RecordEvent();

        // Whether this goal is complete (for EternalGoal this is always false).
        public abstract bool IsComplete();

        // Human readable details for UI
        public abstract string GetDetailsString();

        // A compact string representation for saving/loading. Format determined by derived classes.
        public abstract string GetStringRepresentation();

        // Helper: basic info line used when listing goals
        public virtual string GetListDisplay()
        {
            string status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {_shortName} ({_description})";
        }
    }
}
