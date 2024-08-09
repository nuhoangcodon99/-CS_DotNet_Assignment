using System.Globalization;

namespace NPL.M.A005.Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a date string:");
            string? input = Console.ReadLine();

            DateTime date;
            if (TryParseDate(input, out date))
            {
                Console.WriteLine($"Parsed to Date: {date}");
                Console.WriteLine($"Last Day of the Month: {GetLastDayOfMonth(date):dd/MM/yyyy}");
                Console.WriteLine($"Number of Working Days: {CountWorkingDays(date)}");
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }

        private static bool TryParseDate(string? input, out DateTime date)
        {
            string[] formats = {
                "MM/dd/yyyy", "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
                "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt", "M/d/yyyy h:mm",
                "M/d/yyyy h:mm"
            };
            return DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        static DateTime GetLastDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        static int CountWorkingDays(DateTime date)
        {
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var workingDays = 0;

            for (int i = 0; i < daysInMonth; i++)
            {
                DateTime currentDay = firstDayOfMonth.AddDays(i);
                if (currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday)
                
                {
                    workingDays++;
                }
            }

            return workingDays;
        }
    }
}