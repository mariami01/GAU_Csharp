using System;
using System.Collections;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            for (int i = 1; i <= 10; i++)
            {
                stack.Push($"Element {i}");
            }

            if (stack.Count > 0)
            {
                string lastElement = stack.Peek().ToString();
                Console.WriteLine("Last Element: " + lastElement);
            }
            else
            {
                Console.WriteLine("Stack is empty");
            }

            Console.WriteLine("Number of Elements: " + stack.Count);

            // Displaying all the elements in the stack
            Console.WriteLine("Elements in the Stack:");
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }

            stack.Clear();

            Console.ReadLine();
        }
    }
}
