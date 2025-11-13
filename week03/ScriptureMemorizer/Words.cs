using System;

public class Word
{
    // Atributos privados
    private string _text;
    private bool _isHidden;

    // Construtor
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Oculta a palavra
    public void Hide()
    {
        _isHidden = true;
    }

    // Revela a palavra
    public void Show()
    {
        _isHidden = false;
    }

    // Verifica se está oculta
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Retorna o texto ou underscores se estiver oculta
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return "_____";
        }
        else
        {
            return _text;
        }
    }
}
