using System;

public class Reference
{
    // Atributos privados
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Construtor para um único versículo
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    // Construtor para um intervalo de versículos
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Método que retorna o texto da referência
    public string GetDisplayText()
    {
        // Exemplo de saída: "Proverbs 3:5" ou "Proverbs 3:5–6"
        if (_endVerse > 0)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}";
        }
    }
}
