using System;
using System.Collections.Generic;

namespace Classwork1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter student names (separated by commas):");
            string[] students = Console.ReadLine().Split(',');

            Console.WriteLine("Enter topics (separated by commas):");
            string[] topics = Console.ReadLine().Split(',');

            Dictionary<string, List<string>> topicAssignments = new Dictionary<string, List<string>>();

            Random random = new Random();
            for (int i = students.Length - 1; i > 0; i--) //reverse looping
            {
                int j = random.Next(i + 1);
                string temp = students[i];
                students[i] = students[j];
                students[j] = temp;
            }

            int studentIndex = 0;
            foreach (string topic in topics)
            {
                topicAssignments[topic] = new List<string>(); // store students assigned to current topic

                // ensure that the loop continues as long as there are remaining students to be assigned to topics
                for (int i = 0; i < 3 && studentIndex < students.Length; i++)
                {
                    topicAssignments[topic].Add(students[studentIndex]);
                    studentIndex++;
                }
            }

            Console.WriteLine("\nAssigned groups:");
            foreach (string topic in topicAssignments.Keys)
            {
                List<string> assignedStudents = topicAssignments[topic];

                Console.WriteLine($"Topic: {topic}");
                Console.WriteLine($"Group 1: {string.Join(", ", assignedStudents)}");
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}


