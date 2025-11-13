using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        // Divide o texto em palavras e cria objetos Word
        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    // Oculta palavras aleatórias (sem repetir)
    public void HideRandomWords(int numberToHide)
    {
        List<int> availableIndexes = new List<int>();

        // Cria lista com índices de palavras ainda visíveis
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                availableIndexes.Add(i);
            }
        }

        // Define o número máximo de palavras que podem ser ocultadas
        int wordsToHide = Math.Min(numberToHide, availableIndexes.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(availableIndexes.Count);
            int wordIndex = availableIndexes[randomIndex];

            _words[wordIndex].Hide();
            availableIndexes.RemoveAt(randomIndex);
        }
    }

    // Retorna o texto completo com palavras ocultas
    public string GetDisplayText()
    {
        string scriptureText = "";

        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()} - {scriptureText.Trim()}";
    }

    // Verifica se todas as palavras estão ocultas
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
