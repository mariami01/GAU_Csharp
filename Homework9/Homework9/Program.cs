using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
}

class Program
{
    static void Main()
    {
        // Create a collection of students
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Age = 20, Major = "Computer Science" },
            new Student { Id = 2, Name = "Jane Smith", Age = 22, Major = "Mathematics" },
            new Student { Id = 3, Name = "Mark Johnson", Age = 21, Major = "Physics" },
            new Student { Id = 4, Name = "Sarah Williams", Age = 19, Major = "English Literature" },
            new Student { Id = 5, Name = "David Lee", Age = 20, Major = "History" }
        };

        // Save the students collection to an XML file
        SaveStudentsToXml(students, "students.xml");

        // Read the XML file and process queries using LINQ
        var studentsFromXml = ReadStudentsFromXml("students.xml");

        // Query 1: Get all students
        var allStudents = studentsFromXml;
        Console.WriteLine("All Students:");
        foreach (var student in allStudents)
        {
            Console.WriteLine($"ID: {student.Id} - Name: {student.Name} - Age: {student.Age} - Major: {student.Major}");
        }

        Console.WriteLine();

        // Query 2: Get students majoring in Computer Science
        var computerScienceStudents = studentsFromXml.Where(s => s.Major == "Computer Science");
        Console.WriteLine("Computer Science Students:");
        foreach (var student in computerScienceStudents)
        {
            Console.WriteLine($"ID: {student.Id} - Name: {student.Name}");
        }

        Console.WriteLine();

        // Query 3: Get the youngest student
        var youngestStudent = studentsFromXml.OrderBy(s => s.Age).FirstOrDefault();
        Console.WriteLine($"Youngest Student: ID: {youngestStudent?.Id} - Name: {youngestStudent?.Name}");

        Console.WriteLine();

        // Query 4: Get the average age of all students
        var averageAge = studentsFromXml.Average(s => s.Age);
        Console.WriteLine($"Average Age: {averageAge}");

        Console.WriteLine();

        // Query 5: Get students whose names start with "J"
        var studentsWithJNames = studentsFromXml.Where(s => s.Name.StartsWith("J"));
        Console.WriteLine("Students with Names Starting with 'J':");
        foreach (var student in studentsWithJNames)
        {
            Console.WriteLine($"ID: {student.Id} - Name: {student.Name}");
        }

        Console.ReadLine();
    }
    static List<Student> ReadStudentsFromXml(string filename)
    {
        var students = new List<Student>();
        var xml = XDocument.Load(filename);

        foreach (var studentElement in xml.Root.Elements("Student"))
        {
            var student = new Student
            {
                Id = int.Parse(studentElement.Attribute("Id").Value),
                Name = studentElement.Element("Name").Value,
                Age = int.Parse(studentElement.Element("Age").Value),
                Major = studentElement.Element("Major").Value
            };

            students.Add(student);
        }

        return students;
    }


    static void SaveStudentsToXml(List<Student> students, string filename)
    {
        var xml = new XElement("Students",
            students.Select(s =>
                new XElement("Student",
                    new XAttribute("Id", s.Id),
                    new XElement("Name", s.Name),
                    new XElement("Age", s.Age),
                    new XElement("Major", s.Major)
                )
            )
        );

        xml.Save(filename);
        Console.WriteLine("Students saved to XML file.");
    }

}