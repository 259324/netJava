using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalendarz
{
    public class SystemCalendar
    {
        string[] yearNames = {"dwa"};
        public int currYear()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.Year;
        }
    }
}
