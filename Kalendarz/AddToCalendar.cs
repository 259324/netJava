using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Kalendarz
{
  
    public class AddToCalendar
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string Data { get; set; }
    }

}
