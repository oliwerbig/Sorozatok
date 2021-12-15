using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorozatok
{
    class Time
    {
        public int TimeInMinutes { get; set; } = 0;

        public Time()
        {

        }

        public Time(int hour, int minute)
        {
            SetTimeByHourAndMinute(hour, minute);
        }

        public Time(int timeInMinutes)
        {
            TimeInMinutes = timeInMinutes;
        }

        public void SetTimeByHourAndMinute(int hour, int minute)
        {
            TimeInMinutes = hour * minute;
        }

        public int GetHour()
        {
            return TimeInMinutes / 60;
        }

        public int GetMinute()
        {
            return TimeInMinutes % 60;
        }

        public string GetTimeAsString()
        {
            return GetHour().ToString() + ":" + GetMinute().ToString();
        }
    }
}