using System;
using System.Collections.Generic;

public class Shape
{
    private string color;

    public Shape(string color)
    {
        this.color = color;
    }

    public string GetColor()
    {
        return color;
    }

    public virtual float GetArea()
    {
        return 0f; // Base implementation, to be overridden by derived classes
    }
}

public class Square : Shape
{
    private float side;

    public Square(string color, float side) : base(color)
    {
        this.side = side;
    }

    public override float GetArea()
    {
        return side * side;
    }
}

public class Rectangle : Shape
{
    private float length;
    private float width;

    public Rectangle(string color, float length, float width) : base(color)
    {
        this.length = length;
        this.width = width;
    }

    public override float GetArea()
    {
        return length * width;
    }
}

public class Circle : Shape
{
    private float radius;

    public Circle(string color, float radius) : base(color)
    {
        this.radius = radius;
    }

    public override float GetArea()
    {
        return (float)Math.PI * radius * radius;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        // Create instances of different shapes
        shapes.Add(new Square("Red", 4f));
        shapes.Add(new Rectangle("Blue", 3f, 5f));
        shapes.Add(new Circle("Green", 2.5f));

        // Display color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}