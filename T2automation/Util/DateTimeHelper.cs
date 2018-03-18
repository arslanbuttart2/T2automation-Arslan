using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2automation.Util
{
    class DateTimeHelper
    {
        public DateTimeHelper() {
        }

        public string GetDate(string option) {
            if (option.Equals("now")) {
                return DateTime.Today.ToString("d");
            }
            if (option.Equals("yesterday"))
            {
                return DateTime.Today.AddDays(-1).ToString("d");
            }
            return "";
        }

        public int GetDay(string option)
        {
            if (option.Equals("now"))
            {
                return DateTime.Today.Day;
            }
            if (option.Equals("yesterday"))
            {
                int day = DateTime.Today.Day;
                day--;
                return day;
            }
            return -1;
        }

        public string GetDateHijri(string option)
        {
            if (option.Equals("now"))
            {
                DateTime utc = DateTime.UtcNow;
                Calendar cal = new HijriCalendar();
                int y = cal.GetYear(utc);
                int m = cal.GetMonth(utc);
                int d = cal.GetDayOfMonth(utc) - 1;

                string temp = DateTime.Today.ToString("d");
                string hijri_date = y + "/" + m + "/" + d;



                return hijri_date;
            }
            if (option.Equals("yesterday"))
            {
                return DateTime.Today.AddDays(-1).ToString("d");
            }
            return "";
        }

        public int GetDayHijri(string option)
        {
            if (option.Equals("now"))
            {
                DateTime utc = DateTime.UtcNow;
                Calendar cal = new HijriCalendar();
                int d = cal.GetDayOfMonth(utc) - 1;

                return d;
            }
            if (option.Equals("yesterday"))
            {
                int day = DateTime.Today.Day;
                day--;
                return day;
            }
            return -1;
        }
    }
}
