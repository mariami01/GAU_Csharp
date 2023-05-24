using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Create a collection of Student objects
        List<Student> students = new List<Student>
        {

            new Student { Id = 1, Name = "Jujuna Ninidze", Age = 20, Major = "Computer Science" },
            new Student { Id = 2, Name = "Barbare Kapanadze", Age = 22, Major = "Mathematics" },
            new Student { Id = 3, Name = "Sandro Jajanidze", Age = 21, Major = "Physics" },
            new Student { Id = 4, Name = "Mariam Kapanadze", Age = 19, Major = "Civil Engineering" },
            new Student { Id = 5, Name = "David Leonidze", Age = 20, Major = "Computer Science" }

        };

        // Generate XML file based on the collection
        XElement studentsXml = new XElement("Students",
            from student in students
            select new XElement("Student",
                new XElement("Id", student.Id),
                new XElement("Name", student.Name),
                new XElement("Age", student.Age),
                new XElement("Major", student.Major)
            )
        );

        string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.xml");

        // Save the XML file
        studentsXml.Save(xmlFilePath);
        Console.WriteLine("XML file saved.");

        // Read and process the XML file using LINQ queries
        XElement loadedXml = XElement.Load(xmlFilePath);

        // Query #1: Get all students
        var allStudents = from student in loadedXml.Elements("Student")
                          select new Student
                          {
                              Id = int.Parse(student.Element("Id").Value),
                              Name = student.Element("Name").Value,
                              Age = int.Parse(student.Element("Age").Value),
                              Major = student.Element("Major").Value
                          };

        Console.WriteLine("All students:");
        foreach (var student in allStudents)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Major: {student.Major}");
        }


        // Query 2: Get students majoring in Computer Science
        var gradeAStudents = from student in loadedXml.Elements("Student")
                             where student.Element("Major").Value == "Computer Science"
                             select new Student
                             {
                                 Name = student.Element("Name").Value,
                                 Age = int.Parse(student.Element("Age").Value),
                                 Major = student.Element("Major").Value
                             };

        Console.WriteLine("\nStudents who study Computer Science:");
        foreach (var student in gradeAStudents)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.Major}");
        }

        // Query 3: Get the youngest student
        var youngestStudent = loadedXml.Elements("Student").OrderBy(s => int.Parse(s.Element("Age").Value)).FirstOrDefault();
        Console.WriteLine($"\nYoungest Student: ID: {youngestStudent?.Element("Id").Value} - Name: {youngestStudent?.Element("Name").Value}");


        // Query 4: Get students with age greater than 20
        var studentsAboveTwenty = from student in loadedXml.Elements("Student")
                                  where int.Parse(student.Element("Age").Value) > 20
                                  select new Student
                                  {
                                      Name = student.Element("Name").Value,
                                      Age = int.Parse(student.Element("Age").Value),
                                      Major = student.Element("Major").Value
                                  };

        Console.WriteLine("\nStudents above 20 years old:");
        foreach (var student in studentsAboveTwenty)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Major: {student.Major}");
        }

        // Query 5: Get the number of students
        var studentCount = loadedXml.Elements("Student").Count();
        Console.WriteLine($"\nTotal number of students: {studentCount}");

        // Query 6: Get students with names starting with 'J'
        var studentsWithJ = from student in loadedXml.Elements("Student")
                            where student.Element("Name").Value.StartsWith("J")
                            select new Student
                            {
                                Name = student.Element("Name").Value,
                                Age = int.Parse(student.Element("Age").Value),
                                Major = student.Element("Major").Value
                            };

        Console.WriteLine("\nStudents with names starting with 'J':");
        foreach (var student in studentsWithJ)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Major: {student.Major}");
        }

        // Query 7: Get the average age of students
        var averageAge = loadedXml.Elements("Student").Average(s => int.Parse(s.Element("Age").Value));
        Console.WriteLine($"\nAverage age of students: {averageAge}");

        // Query 8: Get the oldest student
        var oldestStudent = loadedXml.Elements("Student").OrderByDescending(s => int.Parse(s.Element("Age").Value)).FirstOrDefault();
        Console.WriteLine($"\nOldest Student: ID: {oldestStudent?.Element("Id").Value} - Name: {oldestStudent?.Element("Name").Value}");

        // Query 9: Get students with names containing 'an'
        var studentsWithNameAn = from student in loadedXml.Elements("Student")
                                 where student.Element("Name").Value.Contains("an")
                                 select new Student
                                 {
                                     Name = student.Element("Name").Value,
                                     Age = int.Parse(student.Element("Age").Value),
                                     Major = student.Element("Major").Value
                                 };

        Console.WriteLine("\nStudents with names containing 'an':");
        foreach (var student in studentsWithNameAn)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Major: {student.Major}");
        }

        // Query 10: Get students grouped by major
        var studentsByMajor = from student in loadedXml.Elements("Student")
                              group student by student.Element("Major").Value into majorGroup
                              select new
                              {
                                  Major = majorGroup.Key,
                                  Students = from s in majorGroup
                                             select new Student
                                             {
                                                 Name = s.Element("Name").Value,
                                                 Age = int.Parse(s.Element("Age").Value),
                                                 Major = s.Element("Major").Value
                                             }
                              };

        Console.WriteLine("\nStudents grouped by major:");
        foreach (var group in studentsByMajor)
        {
            Console.WriteLine($"Major: {group.Major}");
            foreach (var student in group.Students)
            {
                Console.WriteLine($"Name: {student.Name}, Age: {student.Age}");
            }
            Console.WriteLine();
        }
    }
}
