using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base("Reflecting Activity", "This activity helps you reflect on meaningful experiences.")
    {
        _prompts = new List<string>
        {
            "Think of a time you were strong.",
            "Think of a time you helped someone.",
            "Think of a time you overcame difficulty."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful?",
            "How did you feel during this moment?",
            "What did you learn from it?",
            "How can you apply this today?"
        };
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        ShowSpinner(4);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}
