using System;
using System.Collections;
using System.Collections.Generic;

class Employee : IEnumerable, IEnumerator, IComparable<Employee>, IComparer<Employee>, IEquatable<Employee>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PersonalNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
    public decimal Salary { get; set; }
    public int EmployeeRating { get; set; }

    private int index = -1;
    private List<Employee> employees;

    public Employee()
    {
        employees = new List<Employee>();
    }

    public Employee(string firstName, string lastName, string personalNumber, DateTime dateOfBirth, decimal salary, int employeeRating)
    {
        FirstName = firstName;
        LastName = lastName;
        PersonalNumber = personalNumber;
        DateOfBirth = dateOfBirth;
        Salary = salary;
        EmployeeRating = employeeRating;
    }

    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)this;
    }

    public bool MoveNext()
    {
        index++;
        return (index < employees.Count);
    }

    public void Reset()
    {
        index = -1;
    }

    public object Current
    {
        get { return employees[index]; }
    }

    public int Compare(Employee x, Employee y)
    {
        return x.EmployeeRating.CompareTo(y.EmployeeRating);
    }

    public int CompareTo(Employee other)
    {
        return this.Salary.CompareTo(other.Salary);
    }

    public bool Equals(Employee other)
    {
        if (other == null) return false;
        return (this.FirstName.Equals(other.FirstName) &&
                this.LastName.Equals(other.LastName) &&
                this.PersonalNumber.Equals(other.PersonalNumber) &&
                this.DateOfBirth.Equals(other.DateOfBirth) &&
                this.Salary.Equals(other.Salary) &&
                this.EmployeeRating.Equals(other.EmployeeRating));
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Employee objAsEmployee = obj as Employee;
        if (objAsEmployee == null) return false;
        else return Equals(objAsEmployee);
    }

    public override int GetHashCode()
    {
        return (FirstName + LastName + PersonalNumber + DateOfBirth.ToString() + Salary.ToString() + EmployeeRating.ToString()).GetHashCode();
    }

    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee("Nino", "Lomidze", "123456789", new DateTime(1980, 1, 1), 50000, 5),
            new Employee("Gela", "Chkhaidze", "234567890", new DateTime(1985, 1, 1), 60000, 4),
            new Employee("Giorgi", "Lomidze", "345678901", new DateTime(1990, 1, 1), 70000, 3),
            new Employee("Salome", "Chkhaidze", "456789012", new DateTime(1995, 1, 1), 40000, 2),
            new Employee("Elene", "Kavsadze", "567890123", new DateTime(2000, 1, 1), 90000, 1)
        };

        // Sort by descending employee rating
        employees.Sort(new Employee());

        Console.WriteLine("Sorted by descending employee rating:");
        Console.WriteLine("\n----------------------------");

        foreach (Employee e in employees)
        {
            Console.WriteLine("{0} {1} ({2}) - Rating: {3}, Salary: {4:C}, Age: {5}",
                              e.FirstName, e.LastName, e.PersonalNumber, e.EmployeeRating, e.Salary, e.Age);
        }

        // Sort by increasing salary
        employees.Sort();

        Console.WriteLine("\nSorted by increasing salary:");
        Console.WriteLine("\n----------------------------");

        foreach (Employee e in employees)
        {
            Console.WriteLine("{0} {1} ({2}) - Salary: {3:C}, Rating: {4}, Age: {5}",
                              e.FirstName, e.LastName, e.PersonalNumber, e.Salary, e.EmployeeRating, e.Age);
        }

        // Sort by increasing age
        employees.Sort((x, y) => x.Age.CompareTo(y.Age));

        Console.WriteLine("\nSorted by increasing age:");
        Console.WriteLine("\n----------------------------");

        foreach (Employee e in employees)
        {
            Console.WriteLine("{0} {1} ({2}) - Age: {3}, Salary: {4:C}, Rating: {5}",
                              e.FirstName, e.LastName, e.PersonalNumber, e.Age, e.Salary, e.EmployeeRating);
        }
    }
}
