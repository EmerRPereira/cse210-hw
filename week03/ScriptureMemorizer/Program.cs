using System;

class Program
{
    static void Main(string[] args)
    {
        // Cria a referência e o texto
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, 
            "Trust in the Lord with all thine heart and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths.");

        // Loop principal
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press ENTER to hide more words or type 'quit' to end.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            // Oculta 3 palavras por vez
            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden! Great job!");
                break;
            }
        }
    }
}
