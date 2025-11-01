// CSE210 - Programming with Classes
// C# Programming Exercise 5: Functions
// Author: Emerson Ronald Pereira

using System;

class Program
{
    static void Main(string[] args)
    {
        // 1️⃣ Displays a welcome message
        DisplayWelcome();

        // 2️⃣ It asks for the username and saves the returned value
        string userName = PromptUserName();

        // 3️⃣ Ask for your favorite number and save the returned value
        int userNumber = PromptUserNumber();

        // 4️⃣ Calculate the square of your favorite number
        int squaredNumber = SquareNumber(userNumber);

        // 5️⃣ Displays the final result
        DisplayResult(userName, squaredNumber);
    }

    // Function 1: Displays a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function 2: It asks for the username and returns it as string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function 3: It asks for the favorite number and returns it as int
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function 4: It takes a number and returns its square
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // Function 5: It receives the name and the squared number and displays the result
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}
