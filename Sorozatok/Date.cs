using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorozatok
{
    class Date
    {
        public int Year { get; set; } = 0;
        public int Month { get; set; } = 0;
        public int Day { get; set; } = 0;

        public Date()
        {

        }

        public Date(int year, int month, int day)
        {
            SetDate(year, month, day);
        }

        public Date(string payload)
        {
            SetDateByString(payload);
        }

        public void SetDateByString(string payload)
        {
            string[] split = payload.Split(".");
            int year = int.Parse(split[0]);
            int month = int.Parse(split[1]);
            int day = int.Parse(split[2]);
            SetDate(year, month, day);
        }

        public void SetDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public string GetDateAsString()
        {
            string DateAsString = "";
            DateAsString += Year.ToString("0000");
            DateAsString += ".";
            DateAsString += Month.ToString("00");
            DateAsString += ".";
            DateAsString += Day.ToString("00");

            return DateAsString;
        }

        public int GetDateAsInt()
        {
            int DateAsInt = int.Parse(GetDateAsString().Replace(".", ""));

            return DateAsInt;
        }
    }
}
