using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(
            new DateTime(2025, 12, 3), 30, 4.8));

        activities.Add(new Cycling(
            new DateTime(2025, 12, 3), 50, 16.0));

        activities.Add(new Swimming(
            new DateTime(2025, 12, 3), 40, 20));

        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
