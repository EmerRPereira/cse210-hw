using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", "This activity helps you reflect on the good things by listing items.")
    {
        _prompts = new List<string>
        {
            "Who are people you appreciate?",
            "What are personal strengths of yours?",
            "Who are people you have helped?",
            "When have you felt joy recently?"
        };
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("→ ");
            items.Add(Console.ReadLine());
            _count++;
        }

        return items;
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine("Start listing items!");
        ShowSpinner(3);

        List<string> userList = GetListFromUser();

        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }
}
