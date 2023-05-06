using System;

namespace Task1
{
    abstract class GeometricFigure
    {
        public abstract double Perimetri();
    }

    class Rectangle : GeometricFigure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Perimetri()
        {
            return 2 * (Width + Height);
        }
    }

    class Circle : GeometricFigure
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double Perimetri()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(5, 10);
            double rectanglePerimeter = rectangle.Perimetri();
            Console.WriteLine($"Rectangle perimeter: {rectanglePerimeter}");

            Circle circle = new Circle(7);
            double circlePerimeter = circle.Perimetri();
            Console.WriteLine($"Circle perimeter: {circlePerimeter}");
        }
    }
}
