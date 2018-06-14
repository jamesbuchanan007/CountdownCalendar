using System;
using System.Collections.Generic;

namespace DayNumberForTheYear
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Today;

            Dictionary<int, Birthdays> birthdays = GetBirthdays();

            DateTime dateToDisplay = date.Date;
            Console.WriteLine("{0:d}: Day {1} of {2} {3}",
                dateToDisplay,
                dateToDisplay.DayOfYear,
                dateToDisplay.Year,
                DateTime.IsLeapYear(dateToDisplay.Year) ? "(Leap Year)" : "");

            Console.WriteLine("\nBirthdays***********");
            foreach (var person in birthdays)
            {
                var nextBirthday = formatBirthday(person.Value.DAY, person.Value.MONTH);
                var diff = nextBirthday - DateTime.Today;

                Console.WriteLine("{0} more days\t{1}", diff.Days, person.Value.NAME);
            }

            Console.ReadLine();
        }

        private static DateTime formatBirthday(int dayInput, int monthInput)
        {
            var year = DateTime.Today.Year;
            var nextYear = DateTime.Today.AddYears(1).Year;
            var month = DateTime.Today.Month;
            var day = DateTime.Today.Day;

            if (month < monthInput)
            {
                return new DateTime(year, monthInput, dayInput);
            }

            if (month == monthInput)
            {
                if (day < dayInput)
                {
                    return new DateTime(year, monthInput, dayInput);
                }

                return new DateTime(nextYear, monthInput, dayInput);
            }

            return new DateTime(nextYear, monthInput, dayInput);
        }

        private static Dictionary<int, Birthdays> GetBirthdays()
        {
            var birthdays = new Dictionary<int, Birthdays>
            {
                {
                    1, new Birthdays
                    {
                        NAME = "Me",
                        DAY = 31,
                        MONTH = 3,
                        FULLBIRTHDAY = new DateTime(1973,3,31)
                    }

                },
                {
                    2, new Birthdays
                    {
                        NAME = "James Patrick Buchanan (Jimmy)",
                        DAY = 24,
                        MONTH = 3,
                        FULLBIRTHDAY = new DateTime(2013,3,24)
                    }
                },
                {
                    3, new Birthdays
                    {
                        NAME = "Trevor James Buchanan (Trev)",
                        DAY = 20,
                        MONTH = 2,
                        FULLBIRTHDAY = new DateTime(1996,2,20)
                    }
                },
                {
                    4, new Birthdays
                    {
                        NAME = "Madison Jayne Graham",
                        DAY = 2,
                        MONTH = 8,
                        FULLBIRTHDAY = new DateTime(2000,8,2)
                    }
            }
            };

            return birthdays;
        }

        public class Birthdays
        {
            public string NAME { get; set; }
            public int DAY { get; set; }
            public int MONTH { get; set; }
            public DateTime FULLBIRTHDAY { get; set; }

        }

        public class Holidays
        {
            public string NAME { get; set; }
            public DateTime DAY { get; set; }
        }
    }
}
