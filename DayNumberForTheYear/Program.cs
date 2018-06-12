using System;

namespace DayNumberForTheYear
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Today;

            DateTime dateToDisplay = date.Date;
            Console.WriteLine("{0:d}: Day {1} of {2} {3}", dateToDisplay,
                dateToDisplay.DayOfYear,
                dateToDisplay.Year,
                DateTime.IsLeapYear(dateToDisplay.Year) ? "(Leap Year)" : "");

            Console.ReadLine();
        }
    }
}
