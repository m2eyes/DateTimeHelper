using System.Globalization;

namespace DateTimeHelper
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Convert Gregorian date to Hijri date
        /// </summary>
        /// <param name="gregorianDate">Gregorian date</param>
        /// <returns>Hijri date</returns>
        /// <remarks>
        /// This method converts Gregorian date to Hijri date
        /// </remarks>
        public static string ToHijriDate(this DateTime gregorianDate)
        {
            Calendar umAlQura = new UmAlQuraCalendar();
            var hijriYear = umAlQura.GetYear(gregorianDate);
            var hijriMonth = umAlQura.GetMonth(gregorianDate);
            var hijriDay = umAlQura.GetDayOfMonth(gregorianDate);

            return $"{hijriDay}/{hijriMonth}/{hijriYear} {gregorianDate:hh:mm:ss tt}";
        }

        /// <summary>
        /// Get the difference between two dates
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <returns>The Difference in Years, Months, Days, Hours, Minutes, Seconds</returns>
        /// <remarks>
        /// This method returns the difference between two dates in years, months, days, hours, minutes, and seconds
        /// </remarks>
        public static (int years, int months, int days, int hours, int minutes, int seconds) DateDiff(this DateTime firstDate, DateTime secondDate)
        {
            var result = DateTime.Compare(firstDate, secondDate);
            if (result == 0)
            {
                return (0, 0, 0, 0, 0, 0);
            }
            else if (result > 0)
            {
                return GetDateDifference(secondDate, firstDate);
            }
            return GetDateDifference(firstDate, secondDate);
        }

        private static (int years, int months, int days, int hours, int minutes, int seconds) GetDateDifference(DateTime startDate, DateTime endDate)
        {
            int years = 0, months = 0, days = 0, hours = 0, minutes = 0, seconds = 0;
            while (startDate < endDate)
            {
                if (startDate.AddYears(1) <= endDate)
                {
                    startDate = startDate.AddYears(1);
                    years++;
                }
                else if (startDate.AddMonths(1) <= endDate)
                {
                    startDate = startDate.AddMonths(1);
                    months++;
                }
                else
                {
                    days = (endDate - startDate).Days;
                    startDate = startDate.AddDays(days);
                    hours = (endDate - startDate).Hours;
                    startDate = startDate.AddHours(hours);
                    minutes = (endDate - startDate).Minutes;
                    startDate = startDate.AddMinutes(minutes);
                    seconds = (endDate - startDate).Seconds;
                    startDate = startDate.AddSeconds(seconds);
                }
            }
            return (years, months, days, hours, minutes, seconds);
        }
    }
}
