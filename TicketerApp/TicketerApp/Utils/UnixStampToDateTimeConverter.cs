using System;
using System.Collections.Generic;
using System.Text;

namespace TicketerApp.Utils
{
    public static class UnixStampToDateTimeConverter
    {
        public static DateTime ConvertUnixTimeStampIntoDateTime(double unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();

            return dateTime;
        }
        
        public static double GetCurrentUnixTimeStamp()
        {
            DateTimeOffset dto = new DateTimeOffset(DateTime.Now.AddDays(1));
            double unixTimeStamp = dto.ToUnixTimeSeconds();
            return unixTimeStamp;
        }
    }
}
