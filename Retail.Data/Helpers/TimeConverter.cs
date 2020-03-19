using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Data.Helpers
{
    public static class TimeConverter
    {
        public static async Task<DateTime> ConvertToLocalTime(DateTime timeUtc)
        {
            TimeZoneInfo eatZone = TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time");
            DateTime eaTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, eatZone);
            return eaTime;
        }
    }
}
