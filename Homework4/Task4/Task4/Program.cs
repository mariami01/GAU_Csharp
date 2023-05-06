using System;

namespace Task4
{
    abstract class Employee
    {
        public abstract void Method();
    }

    class YearlySalaryEmployee : Employee
    {
        public double MonthlySalary { get; set; }

        public YearlySalaryEmployee(double monthlySalary)
        {
            MonthlySalary = monthlySalary;
        }

        public override void Method()
        {
            double yearlySalary = MonthlySalary * 12;
            Console.WriteLine($"Total salary received by the employee in 1 year: {yearlySalary} USD");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            YearlySalaryEmployee yearlySalaryEmployee = new YearlySalaryEmployee(5000);
            yearlySalaryEmployee.Method();
        }
    }
}
