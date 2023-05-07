using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;

namespace Kalendarz
{
    /// <summary>
    /// Context which connects database with application
    /// </summary>
    public class EventContext : DbContext
    {
        public EventContext()
            : base("AddToCalendar")
        {
            //Database.SetInitializer(new CalendarDbInitializer());
            Database.SetInitializer<EventContext>(null);
        }

        public DbSet<Event> Events { get; set; }
        /// <summary>
        /// Function adds new event to database
        /// </summary>
        /// <param name="event_">event name</param>
        public void NewAddToCalendar(Event event_)
        {
            this.Events.Add(event_);    
            this.SaveChanges();
            //using (var context = new EventContext())
            //{
            //    context.Events.Add(event_);
            //    context.SaveChanges();
            //}
        }
    }
    /// <summary>
    /// Class adds two events to database to fill up calendar 
    /// </summary>
    public class CalendarDbInitializer : DropCreateDatabaseAlways<EventContext>
    {
        protected override void Seed(EventContext context)
        {

            //var defaultEvents = new List<Event>
            //    {
            //    new Event() {ID = 1, EventName = "Urodziny", EventDescription = "Urodziny Asi", Date = DateTime.Now},
            //    new Event() {ID = 2, EventName = "Zakupy", EventDescription = "Kup Marchewkę", Date = DateTime.Now}
            //    };
            //defaultEvents.ForEach(c  => context.Events.Add(c));
            //context.SaveChanges();
        }
    }

   
}
