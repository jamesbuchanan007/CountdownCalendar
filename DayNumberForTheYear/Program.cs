using System;
using System.Collections.Generic;
using System.Linq;

namespace DayNumberForTheYear
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = DateTime.Today;

            var birthdays = GetBirthdays();
            var holidays = GetHolidays();
            var anniversaries = GetAnniversaries();

            var birthdaysDescending = birthdays.OrderByDescending(q => q.Value.MONTH);
            var holidaysDescending = holidays.OrderByDescending(q => q.Value.MONTH);
            var anniversariesDescending = anniversaries.OrderByDescending(q => q.Value.MONTH);


            DateTime dateToDisplay = date.Date;
            Console.WriteLine("{0:d}: Day {1} of {2} {3}",
                dateToDisplay,
                dateToDisplay.DayOfYear,
                dateToDisplay.Year,
                DateTime.IsLeapYear(dateToDisplay.Year) ? "(Leap Year)" : "");

            Console.WriteLine("\nBirthdays ***********");
            foreach (var person in birthdaysDescending)
            {
                var nextBirthday = formatDate(person.Value.DAY, person.Value.MONTH);
                var diff = nextBirthday - DateTime.Today;
                var age = nextBirthday.Year - person.Value.FULLBIRTHDAY.Year;

                Console.WriteLine("\t{0} more days\t{1} - Will be {2} y/o", diff.Days, person.Value.NAME, age);
            }

            Console.WriteLine("\nAnniversaries ***********");
            foreach (var item in anniversariesDescending)
            {
                var nextAnniversary = formatDate(item.Value.DAY, item.Value.MONTH);
                var diff = nextAnniversary - DateTime.Today;
                var timeDiff = nextAnniversary.Year - item.Value.FULLANNIVERSARYDATE.Year;

                Console.WriteLine("\t{0} more days\t{1} - {2} year(s)", diff.Days, item.Value.DESCRIPTION, timeDiff);
            }

            Console.WriteLine("\nHolidays ***********");
            foreach (var holiday in holidaysDescending)
            {
                var nextHoliday = formatDate(holiday.Value.DAY, holiday.Value.MONTH);
                var diff = nextHoliday - DateTime.Today;

                Console.WriteLine("\t{0} more days\t{1}", diff.Days, holiday.Value.NAME);
            }

            Console.ReadLine();
        }

        private static DateTime formatDate(int dayInput, int monthInput)
        {
            var year = DateTime.Today.Year;
            var nextYear = DateTime.Today.AddYears(1).Year;
            var month = DateTime.Today.Month;
            var day = DateTime.Today.Day;

            //CHECKS TO SEE IF MONTH HAS PAST ALREADY
            if (month < monthInput)
            {
                return new DateTime(year, monthInput, dayInput);
            }

            //CHECKS TO SEE IF HOLIDAY IS IN CURRENT MONTH
            if (month == monthInput)
            {
                //CHECKS IF DAY HAS PAST YET
                if (day < dayInput)
                {
                    return new DateTime(year, monthInput, dayInput);
                }

                return new DateTime(nextYear, monthInput, dayInput);
            }

            return new DateTime(nextYear, monthInput, dayInput);
        }



        //BIRTHDAY DICTIONARY
        private static Dictionary<int, Birthdays> GetBirthdays()
        {
            var birthdays = new Dictionary<int, Birthdays>
            {
                {
                    1, new Birthdays
                    {
                        NAME = "Enter Person's Name",
                        DAY = 1,
                        MONTH = 1,
                        FULLBIRTHDAY = new DateTime(2000,1,1)
                    }
                },

            };

            return birthdays;
        }

        //HOLIDAYS DICTIONARY
        private static Dictionary<int, Holidays> GetHolidays()
        {
            var holidays = new Dictionary<int, Holidays>
            {
                {
                    1, new Holidays
                    {
                        NAME = "New Year's Day",
                        DAY = 1,
                        MONTH = 1
                    }
                },

            };

            return holidays;
        }

        //ANNIVERSARY DICTIONARY
        private static Dictionary<int, Anniversary> GetAnniversaries()
        {
            var holidays = new Dictionary<int, Anniversary>
            {
                {
                    1, new Anniversary
                    {
                        DESCRIPTION = "Who's Anniversary",
                        DAY = 1,
                        MONTH = 1,
                        FULLANNIVERSARYDATE = new DateTime(2000,1,1)
                    }
                },

            };

            return holidays;
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
            public int DAY { get; set; }
            public int MONTH { get; set; }
        }

        public class Anniversary
        {
            public string DESCRIPTION { get; set; }
            public int DAY { get; set; }
            public int MONTH { get; set; }
            public DateTime FULLANNIVERSARYDATE { get; set; }
        }
    }
}
