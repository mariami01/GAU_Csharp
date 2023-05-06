using System;

namespace Task2
{
    abstract class Train
    {
        public abstract double Gamotvla();
    }

    class DistanceTrain : Train
    {
        public double Speed { get; set; }
        public double Hours { get; set; }

        public DistanceTrain(double speed, double hours)
        {
            Speed = speed;
            Hours = hours;
        }

        public override double Gamotvla()
        {
            return Speed * Hours;
        }
    }

    class ElectricityTrain : Train
    {
        public double EnergyPerKm { get; set; }
        public double Distance { get; set; }

        public ElectricityTrain(double energyPerKm, double distance)
        {
            EnergyPerKm = energyPerKm;
            Distance = distance;
        }

        public override double Gamotvla()
        {
            return EnergyPerKm * Distance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DistanceTrain distanceTrain = new DistanceTrain(60, 3);
            double distance = distanceTrain.Gamotvla();
            Console.WriteLine($"Distance: {distance} km");

            ElectricityTrain electricityTrain = new ElectricityTrain(0.1, 50);
            double electricity = electricityTrain.Gamotvla();
            Console.WriteLine($"Electricity: {electricity} kWh");

        }
    }
}
