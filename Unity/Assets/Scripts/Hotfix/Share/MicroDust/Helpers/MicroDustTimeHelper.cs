using System;

namespace ET
{
    public static class MicroDustTimeHelper
    {
        public static string FormatUtcTimeNow()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static bool IsTheSameDayOfYear(string time)
        {
            return DateTime.Parse(time).DayOfYear == DateTime.UtcNow.DayOfYear;
        }
    }
}
