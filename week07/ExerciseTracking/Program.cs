/*
Course: C210
Activity: W07 Assignment: Exercise Tracking Program (Foundation #3) - Program.cs
Author: Emerson Ronald Pereira
Features: Running, Cycling, and Swimming activities
This program is an exercise tracking system developed for a fitness center. 
It records physical activities performed by users—running, cycling, and swimming—using object-oriented programming 
with a focus on inheritance and polymorphism.
The system includes a base class (Activity) that stores information common to all exercises, 
such as the date and duration in minutes. It also declares methods for calculating distance, 
speed, and pace, which are then implemented differently in each derived class. Each type of exercise is represented 
by a derived class (Running, Cycling, and Swimming) that provides its own calculation logic based 
on its specific attributes—such as distance for running, speed for cycling, and lap count for swimming.
The program creates objects for all three activities, places them in a list, 
and displays a formatted summary for each one, including the date, type of exercise, 
duration, distance covered, average speed, and pace. In this way, the system demonstrates correct use of abstraction, 
encapsulation, inheritance, and polymorphism, without requiring any user interaction.
*/


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
