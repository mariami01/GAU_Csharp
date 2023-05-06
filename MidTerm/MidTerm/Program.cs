using System;

namespace MidTerm
{
    class Program
    {
        static void Main(string[] args)
        {

            //n ელემენტებიანი მიმდევრობა

            int n = 4;
            SoftwareEngineering[] softwares = new SoftwareEngineering[n];

            softwares[0] = new Free("Free soft", "Company01", new DateTime(2022, 1, 1));
            softwares[1] = new Trial("Trial Software", "Company02", new DateTime(2021, 5, 1), new DateTime(2021, 5, 1), 3);
            softwares[2] = new Commercial("Commercial Software", "Company03", new DateTime(2022, 10, 1), 99.99m, new DateTime(2022, 10, 1), 12);
            softwares[3] = new Commercial("FreeComrp", "CompanyRand", new DateTime(2022, 11, 5), 99.99m, new DateTime(2022, 12, 3), 9);

            // ყველა სოფთის ინფორმაცია
            Console.WriteLine("\nSoftware Info: ");
            Console.WriteLine("\n_________________");
            foreach (SoftwareEngineering software in softwares)
            {
                software.DisplayInfo();
                
            }
            Console.WriteLine("\n_________________");


            // ინფორმაცია მათზე, რომლებსაც ვადა გაუვიდა
            DateTime currentDate = DateTime.Now;
            Console.WriteLine("\nSoftware that has not expired:");
            foreach (SoftwareEngineering software in softwares)
            {
                if (software.checkUsage(currentDate))
                {
                    software.DisplayInfo();
                }
            }
            Console.WriteLine("\n_________________");
        }
    }
}
