using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentTracker.Core
{
    public static class DateTimeExtension
    {
        public static DateTime GetIndianDateTime(this DateTime datetime)
        {
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
        }

        public static bool IsSaturdayOrSunday(this DateTime datetime)
        {
            DateTime indiaDate = datetime.GetIndianDateTime();
            return indiaDate.DayOfWeek == DayOfWeek.Saturday ||
                indiaDate.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
