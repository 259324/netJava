using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Kalendarz
{

    /// <summary>
    /// Class which contains parameters to database. Database is based on Entity Framework.
    /// </summary>
    public class Event
    {
        public int ID { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime Date { get; set; }
    }

}

