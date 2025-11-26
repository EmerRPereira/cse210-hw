/*
Course: CSE 210
Project: Homework - Inheritance and Polymorphism
Purpose: This program demonstrates the use of inheritance and polymorphism
         through a base class 'Assignment' and its derived classes 'MathAssignment'
         and 'WritingAssignment'.
Author: Emerson Ronald Pereira
Date: December 2025
*/
class Program
{
    static void Main(string[] args)
    {
        // Testando Assignment (base)
        Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(a1.GetSummary());
        Console.WriteLine();

        // Testando MathAssignment
        MathAssignment m1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(m1.GetSummary());
        Console.WriteLine(m1.GetHomeworkList());
        Console.WriteLine();

        // Testando WritingAssignment
        WritingAssignment w1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(w1.GetSummary());
        Console.WriteLine(w1.GetWritingInformation());
    }
}
