using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        Prompt = prompt;
        Response = response;
    }

    // Constructor used when loading from file
    public Entry(string date, string prompt, string response, bool fromFile)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine("----------------------------");
    }

    public string ToFileFormat()
    {
        // CSV format with a safe separator
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length >= 3)
        {
            return new Entry(parts[0], parts[1], parts[2], true);
        }
        return null;
    }
}
