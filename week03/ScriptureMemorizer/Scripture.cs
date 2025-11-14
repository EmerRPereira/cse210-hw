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

        // Divide o texto corretamente, sem entradas vazias
        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> availableIndexes = new List<int>();

        // Lista apenas palavras visíveis
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                availableIndexes.Add(i);
            }
        }

        // Não tentar ocultar mais do que o disponível
        int wordsToHide = Math.Min(numberToHide, availableIndexes.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = _random.Next(availableIndexes.Count);
            int index = availableIndexes[randomIndex];

            _words[index].Hide();
            availableIndexes.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = "";

        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()} - {scriptureText.Trim()}";
    }

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
