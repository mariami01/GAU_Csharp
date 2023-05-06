using System;
namespace Presentation
{
    public class Person
    {
            public string Name { get; set; }
            public Person ChildOne { get; set; }
            public Person ChildTwo { get; set; }

            // to keep track what's goin here. items that are grabbed by GC
            ~Person()
            {
                Console.WriteLine($"   Collecting {Name}.");
            }
    }
}
