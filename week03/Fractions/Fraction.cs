using System;

public class Fraction
{
    // Atributos privados
    private int _top;
    private int _bottom;

    // Construtor padrão: 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Construtor com 1 parâmetro (ex: 5 → 5/1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Construtor com 2 parâmetros (ex: 3, 4 → 3/4)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter e Setter para o numerador
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter e Setter para o denominador
    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Método que retorna a fração como string (ex: "3/4")
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Método que retorna o valor decimal da fração (ex: 0.75)
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
