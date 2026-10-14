using System;

class Program
{
    static void Main(string[] args)
    {
        // Test all three constructors
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Test getters and setters
        Fraction f5 = new Fraction(6, 7);
        f5.SetTop(2);
        f5.SetBottom(9);
        Console.WriteLine($"Top: {f5.GetTop()}, Bottom: {f5.GetBottom()}");

        Console.WriteLine();

        // Practice: random fractions using the default constructor + setters
        Fraction randomFraction = new Fraction();
        Random random = new Random();

        for (int i = 1; i <= 20; i++)
        {
            int top = random.Next(1, 11);     // 1 through 10
            int bottom = random.Next(1, 11);  // 1 through 10 (never 0)

            randomFraction.SetTop(top);
            randomFraction.SetBottom(bottom);

            Console.WriteLine($"Fraction {i}: string: {randomFraction.GetFractionString()} Number: {randomFraction.GetDecimalValue()}");
        }
    }
}