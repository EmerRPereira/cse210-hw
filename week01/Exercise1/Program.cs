// CSE210 - Programming with Classes
// C# Programming Exercise 1: Input and Output
// Author: Emerson Ronald Pereira

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        Console.WriteLine($"\nYour name is {last}, {first} {last}.");
    }
}
