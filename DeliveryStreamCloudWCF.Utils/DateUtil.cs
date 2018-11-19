using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeliveryStreamCloudWCF.Utils
{
    public class DateUtil
    {
        public static double CalculateTimeSpanHours(DateTime dtStart, DateTime dtEnd, int StartingHour, int EndingHour)
        {
            // initialze our return value
            double OverAllMinutes = 0.0;

            // start time must be less than end time
            if (dtStart > dtEnd)
            {
                return OverAllMinutes;
            }
            DateTime ctTempEnd = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, 0, 0, 0);
            DateTime ctTempStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day, 0, 0, 0);

            // check if startdate and enddate are the same day
            bool bSameDay = (ctTempStart == ctTempEnd);

            // calculate the business days between the dates
            TimeSpan ctp = dtEnd - dtStart;

           
           // int iBusinessDays = (Int32)System.Math.Ceiling(ctp.TotalHours / 24.0); // +1;

            int iBusinessDays = Int32.MinValue;
            if (dtEnd.Month - dtStart.Month == 0)
            {
                iBusinessDays = (dtEnd.Day - dtStart.Day) + 1;
            }
            else
            {
                iBusinessDays = (Int32)System.Math.Ceiling(ctp.TotalHours / 24.0);
            }
            //For date difference more than one month
            if (dtEnd.Month - dtStart.Month>0)
            {
                iBusinessDays = iBusinessDays + 1;
            }

            // now add the time values to our temp times
            TimeSpan CTimeSpan = new TimeSpan(0, dtStart.Hour, dtStart.Minute, 0);
            ctTempStart += CTimeSpan;
            CTimeSpan = new TimeSpan(0, dtEnd.Hour, dtEnd.Minute, 0);
            ctTempEnd += CTimeSpan;

            // set our workingday time range and correct the first day
            DateTime ctMaxTime = new DateTime(ctTempStart.Year, ctTempStart.Month, ctTempStart.Day, EndingHour, 0, 0);
            DateTime ctMinTime = new DateTime(ctTempStart.Year, ctTempStart.Month, ctTempStart.Day, StartingHour, 0, 0);
            Int32 FirstDaySec = CorrectFirstDayTime(ctTempStart, ctMaxTime, ctMinTime);

            // set our workingday time range and correct the last day
            DateTime ctMaxTime1 = new DateTime(ctTempEnd.Year, ctTempEnd.Month, ctTempEnd.Day, EndingHour, 0, 0);
            DateTime ctMinTime1 = new DateTime(ctTempEnd.Year, ctTempEnd.Month, ctTempEnd.Day, StartingHour, 0, 0);
            Int32 LastDaySec = CorrectLastDayTime(ctTempEnd, ctMaxTime1, ctMinTime1);
            Int32 OverAllSec = 0;

            // now sum-up all values
            if (bSameDay)
            {
                if (iBusinessDays != 0)
                {
                    TimeSpan cts = ctMaxTime - ctMinTime;
                    Int32 dwBusinessDaySeconds = (cts.Days * 24 * 60 * 60) + (cts.Hours * 60 * 60) + (cts.Minutes * 60) + cts.Seconds;
                    OverAllSec = FirstDaySec + LastDaySec - dwBusinessDaySeconds;
                }
            }
            else
            {
                if (iBusinessDays >= 1)
                {
                    OverAllSec =
                    ((iBusinessDays - 2) * (EndingHour - StartingHour) * 60 * 60) + FirstDaySec + LastDaySec;
                }
                //if (iBusinessDays >= 2)
                //{
                //    OverAllSec =
                //    ((iBusinessDays - 1) * (EndingHour - StartingHour) * 60 * 60) + FirstDaySec + LastDaySec;
                //}

            }
            OverAllMinutes = OverAllSec / 60;

            return OverAllMinutes ;


        }

        private static Int32 CorrectFirstDayTime(DateTime ctStart, DateTime ctMaxTime, DateTime ctMinTime)
        {
            Int32 daysec = 0;

            if (ctMaxTime < ctStart) // start time is after max time
            {
                return 0; // zero seconds for the first day
            }
            //int iStartDay = (Int32)Enum.Parse(typeof(DayOfWeek), ctStart.DayOfWeek.ToString());

            if (ctStart < ctMinTime) // start time is befor min time
            {
                ctStart = ctMinTime; // set start time to min time
            }
            TimeSpan ctSpan = ctMaxTime - ctStart;
            daysec = (ctSpan.Days * 24 * 60 * 60) + (ctSpan.Hours * 60 * 60) + (ctSpan.Minutes * 60) + ctSpan.Seconds;
            return daysec;
        }

        private static Int32 CorrectLastDayTime(DateTime ctEnd, DateTime ctMaxTime, DateTime ctMinTime)
        {
            Int32 daysec = 0;

            if (ctMinTime > ctEnd) // start time is after max time
            {
                return 0; // zero seconds for the first day
            }
            //int iEndDay = (Int32)Enum.Parse(typeof(DayOfWeek), ctEnd.DayOfWeek.ToString());

            //if (iEndDay >= 3)
            //{
            //    ctEnd =ctEnd.AddDays(1); 
            //}

            if (ctEnd > ctMaxTime) // start time is befor min time
            {
                ctEnd = ctMaxTime; // set start time to min time
            }
            TimeSpan ctSpan = ctEnd - ctMinTime;
            daysec = (ctSpan.Days * 24 * 60 * 60) + (ctSpan.Hours * 60 * 60) + (ctSpan.Minutes * 60) + ctSpan.Seconds;
          
            ////if 4 hours
           // if (daysec == 14400)
           // {
           //     daysec = daysec - 3600;
           // }

            return daysec;
        }
    }
}
