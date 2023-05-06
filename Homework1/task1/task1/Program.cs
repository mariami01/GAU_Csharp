using System;

// 7.2.1  ამოცანა
namespace task1
{

    class Figura{
        protected double width;
        protected double height;

        public Figura(double w, double h)
        {
            width = w;
            height = h;
        }

        public virtual double Area()
        {
            return width * height;
        }


        public Figura(double s)
        {
            width = s;
            height = s;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return height;
        }
    }

    class Samkutxedi : Figura
    {
        private double a, b, c;
        public Samkutxedi(double a, double b, double c) : base(0, 0)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            double p = (a + b + c) / 2;
            height = 2 / a * Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            width = b;
        }
    }
    class Kvadrati : Figura
    {
        public Kvadrati(double s) : base(s)
        {
            width = s;
            height = s;
        }

        public override double Area()
        {
            return base.Area();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Figura f1 = new Figura(5, 10);
            Console.WriteLine("f1 width: " + f1.GetWidth() + ", f1 height: " + f1.GetHeight() + ", f1 area: " + f1.Area());

            //Kvadrati k1 = new Kvadrati(7);
            //Console.WriteLine("k1 width: " + k1.width + ", k1 height: " + k1.height + ", k1 area: " + k1.Area());

            //Samkutxedi s1 = new Samkutxedi(3, 4, 5);
            //Console.WriteLine("s1 width: " + s1.width + ", s1 height: " + s1.height + ", s1 area: " + s1.Area());

        }
    }
}
