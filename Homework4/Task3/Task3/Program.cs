using System;

namespace Task3
{
    abstract class TV
    {
        public abstract void Method();
    }

    class ElectricityTV : TV
    {
        public double EnergyPerHour { get; set; }
        public double Hours { get; set; }

        public ElectricityTV(double energyPerHour, double hours)
        {
            EnergyPerHour = energyPerHour;
            Hours = hours;
        }

        public override void Method()
        {
            double electricity = EnergyPerHour * Hours;
            Console.WriteLine($"Electricity spent by the TV: {electricity} kWh");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ElectricityTV electricityTV = new ElectricityTV(0.1, 5);
            electricityTV.Method();
        }
    }
}
