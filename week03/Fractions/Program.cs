using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        Fraction wholeNumber = new Fraction(5);
        Fraction realFraction1 = new Fraction(3, 4);
        Fraction realFraction2 = new Fraction(1, 3);


        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
        Console.WriteLine(wholeNumber.GetFractionString());
        Console.WriteLine(wholeNumber.GetDecimalValue());
        Console.WriteLine(realFraction1.GetFractionString());
        Console.WriteLine(realFraction1.GetDecimalValue());
        Console.WriteLine(realFraction2.GetFractionString());
        Console.WriteLine(realFraction2.GetDecimalValue());
    }
}