using System;
using System.Text.RegularExpressions;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user to fill in the fields
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Enter your Personal Number (10 digits): ");
            string personalNumber = Console.ReadLine();

            Console.Write("Enter your Date of Birth (YYYY-MM-DD): ");
            string dob = Console.ReadLine();

            Console.Write("Enter your Email ID: ");
            string email = Console.ReadLine();

            Console.Write("Enter your Phone Number (10 digits): ");
            string phone = Console.ReadLine();

            Console.Write("Enter your postal code (6 digits): ");
            string postalCode = Console.ReadLine();

            Console.Write("Enter your website address: ");
            string website = Console.ReadLine();

            // Validate the fields using regular expressions
            Regex nameRegex = new Regex(@"^[a-zA-Z\s]+$");
            if (!nameRegex.IsMatch(name))
            {
                Console.WriteLine("Invalid Name");
                return;
            }

            if (!nameRegex.IsMatch(surname))
            {
                Console.WriteLine("Invalid Surname");
                return;
            }

            Regex personalNumberRegex = new Regex(@"^\d{10}$");
            if (!personalNumberRegex.IsMatch(personalNumber))
            {
                Console.WriteLine("Invalid Personal Number");
                return;
            }

            Regex dobRegex = new Regex(@"^\d{4}-\d{2}-\d{2}$");
            if (!dobRegex.IsMatch(dob))
            {
                Console.WriteLine("Invalid Date of Birth");
                return;
            }

            Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(email))
            {
                Console.WriteLine("Invalid Email ID");
                return;
            }

            Regex phoneRegex = new Regex(@"^\d{10}$");
            if (!phoneRegex.IsMatch(phone))
            {
                Console.WriteLine("Invalid Phone Number");
                return;
            }

            Regex postalCodeRegex = new Regex(@"^\d{6}$");
            if (!postalCodeRegex.IsMatch(postalCode))
            {
                Console.WriteLine("Invalid Postal Code");
                return;
            }

            Regex websiteRegex = new Regex(@"^(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?$");
            if (!websiteRegex.IsMatch(website))
            {
                Console.WriteLine("Invalid Website Address");
                return;
            }

            // Handle special/exceptional situations
            if (personalNumber == "1234567890")
            {
                Console.WriteLine("Warning: Using the default Personal Number");
            }

            if (email.EndsWith(".biz"))
            {
                Console.WriteLine("Warning: Using a business email");
            }

            // Output the validated fields
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Surname: " + surname);
            Console.WriteLine("Personal Number: " + personalNumber);
            Console.WriteLine("Date of Birth: " + dob);
            Console.WriteLine("Email ID: " + email);
            Console.WriteLine("Phone Number: " + phone);
            Console.WriteLine("Postal Code: " + postalCode);
            Console.WriteLine("Website Address: " + website);
        }
    }
}