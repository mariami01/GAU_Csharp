using System;
using MidTerm;

namespace MidTerm
// parent class SoftwareEngineering
{
    public abstract class SoftwareEngineering
    {
        protected string name { get; set; }
        protected string company { get; set; }
        protected DateTime releaseDate { get; set; }

        public SoftwareEngineering(string name, string company, DateTime releaseDate)
        {
            this.name = name;
            this.company = company;
            this.releaseDate = releaseDate;
        }
        // ინფორმაცია პროგრამული უზრუნველყოფის შესახებ
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Manufacturer: " + company);
            Console.WriteLine("Release Date: " + releaseDate.ToShortDateString());
        }

        public virtual bool checkUsage(DateTime currentDate)
        {
            return true;
        }
}
}

// Child class Free
public class Free : SoftwareEngineering
{
    public Free(string name, string company, DateTime releaseDate)
     : base(name, company, releaseDate){}

    // ინფორმაცია პროგრამული უზრუნველყოფის შესახებ
    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}, company: {company}, Release Date: {releaseDate}");
    }


    public override bool checkUsage(DateTime currentDate)
    {
        return true; 
    }
}


// Child class Trial
public class Trial : SoftwareEngineering
{
    private DateTime installDate { get; set; }
    private int freePeriod { get; set; }

    public Trial(string name, string company, DateTime releaseDate, DateTime installDate, int freePeriod)
        : base(name, company, releaseDate)
    {
        this.installDate = installDate;
        this.freePeriod = freePeriod;
    }

    // ინფორმაცია პროგრამული უზრუნველყოფის შესახებ
    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}, Company: {company}, Release Date: {releaseDate}, Install Date: {installDate}, Free Period (months): {freePeriod}");
    }

    // თუ 30დრეზე მეტი გავიდა, მაშინ უფასო დღეები მორჩა
    public override bool checkUsage(DateTime currentDate)
    {
        return (currentDate - installDate).TotalDays < (freePeriod * 30);
    }
}

// Child class Commercial
public class Commercial : SoftwareEngineering
{
    private decimal price { get; set; }
    private DateTime installDate { get; set; }
    private int termOfUse { get; set; }

    public Commercial(string name, string company, DateTime releaseDate, decimal price, DateTime installDate, int termOfUse)
        : base(name, company, releaseDate)
    {
        this.price = price;
        this.installDate = installDate;
    }
    // ინფორმაცია პროგრამული უზრუნველყოფის შესახებ
    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}, Company: {company}, Release Date: {releaseDate}, Price: {price}, Installation Date: {installDate}, Expiration Months: {termOfUse}");
    }

    // კომერციული თუ ჯერ კიდევარის
    public override bool checkUsage(DateTime currentDate)
    {
        return (currentDate - installDate).TotalDays < (termOfUse * 30); 
    }
}
