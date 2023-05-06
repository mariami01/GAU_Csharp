using System;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nLeaving 'Run'...");

            // Forces an immediate garbage collection of all generations
            GC.Collect();

            // method to suspend the current thread until finalization of all the collected objects is complete
            GC.WaitForPendingFinalizers();
        }

        static void Run()
        {
            Person person1 = new Person
            {
                Name = "person1",
                ChildOne = new Person { Name = "child1" }
            };

            ShortLives(person1);

            Console.WriteLine("Leaving 'ShortLives'...");


            // Forces an immediate garbage collection of all generations

            GC.Collect();

            // method to suspend the current thread until finalization
            // of all the collected objects is complete
            GC.WaitForPendingFinalizers();
        }

        static void ShortLives(Person parent)
        {
            Person person2 = new Person
            {
                Name = "person2",
                ChildOne = new Person { Name = "child2" }
            };

            parent.ChildTwo = person2.ChildOne;
        }

    }
}
