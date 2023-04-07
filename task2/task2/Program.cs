using System;

namespace task2
{
    // 7.1.4. ამოცანა
    class Person
    {
        protected string name;
        protected string lastname;
        protected float age;

        public Person(string Name, string Lastname, float Age)
        {
            name = Name;
            lastname = Lastname;
            age = Age;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine("Name: {0}\nLastname: {1}\nAge: {2}\n", name, lastname, age);

        }
    }

    class Doctor : Person
    {
        public string department;
        public string position;
        public string hospitalName;
        public float yearsOfExperience;


        public Doctor(string name, string lastname, float age, string Department, string Position, string HospitalName, float YearsOfExperience) : base(name, lastname, age)
        {
            department = Department;
            position = Position;
            hospitalName = HospitalName;
            yearsOfExperience = YearsOfExperience;
        }


        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("Department: {0}\nPosition: {1}\nHospital: {2}\nYears of Experience: {3}", department, position, hospitalName, yearsOfExperience);

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

           
        }
    }
}
