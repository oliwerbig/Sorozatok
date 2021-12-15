using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorozatok
{
    class TimeSpan : Time
    {
        public TimeSpan()
        {

        }

        public TimeSpan(int timeInMinutes) : base(timeInMinutes)
        {

        }

        public (int days, int hours, int minutes) GetTimeSpan()
        {

            return (days: GetHour() / 24, hours: GetHour() % 24, minutes: GetMinute());
        }
    }
}