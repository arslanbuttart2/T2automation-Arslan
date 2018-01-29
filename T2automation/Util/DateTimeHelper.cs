using System;
using System.Collections.Generic;
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
            return "";
        }

        public int GetDay(string option)
        {
            if (option.Equals("now"))
            {
                return DateTime.Today.Day;
            }
            return -1;
        }
    }
}
