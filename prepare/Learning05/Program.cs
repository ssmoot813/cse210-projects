using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test each class on its own first
        Square testSquare = new Square("Red", 3);
        Console.WriteLine($"Test square: {testSquare.GetColor()}, area {testSquare.GetArea()}");
        Console.WriteLine();

        // Polymorphism: different shapes stored in one List<Shape>
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 3));
        shapes.Add(new Rectangle("Blue", 4, 5));
        shapes.Add(new Circle("Green", 6));

        foreach (Shape shape in shapes)
        {
            // The same line calls a different GetArea() depending on the actual shape
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area:F2}.");
        }
    }
}