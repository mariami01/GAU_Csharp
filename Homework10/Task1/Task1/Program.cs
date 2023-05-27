using System;
using System.Collections;

namespace HashTableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 14.1.5
            Hashtable hashTable = new Hashtable(10); 

            // fruits and amounts of them 
            hashTable.Add("Apple", "9");
            hashTable.Add("Orange", "3");

            // Displaying the number of elements in the hash table
            Console.WriteLine("Number of Elements: " + hashTable.Count);
            Console.WriteLine();

            // Displaying all keys and values in the hash table
            Console.WriteLine("Keys: ");
            foreach (var key in hashTable.Keys)
            {
                Console.WriteLine(key);
            }
            Console.WriteLine();

            Console.WriteLine("Values: ");
            foreach (var value in hashTable.Values)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
