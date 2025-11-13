using System;
using System.Collections.Generic;

public class Scripture
{
    // Atributos privados
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    // Construtor
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

    // Oculta palavras aleatórias
    public void HideRandomWords(int numberToHide)
    {
        // Lógica será implementada depois
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
