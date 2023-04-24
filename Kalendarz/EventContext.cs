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
    public class EventContext : DbContext
    {
        public EventContext()
            : base("AddToCalendar")
        {
            Database.SetInitializer(new CalendarDbInitializer());

        }

        public DbSet<Event> Events { get; set; }

        public void NewAddToCalendar(Event event_)
        {
            using (var context = new EventContext())
            {
                context.Events.Add(event_);
                context.SaveChanges();
            }
        }
    }

    public class CalendarDbInitializer : DropCreateDatabaseAlways<EventContext>
    {
        protected override void Seed(EventContext context)
        {

            var MainEvents = new List<Event>
                {
                new Event() {ID = 1, EventName = "Urodziny", EventDescription = "Urodziny Asi", Date = DateTime.Now},
                new Event() {ID = 2, EventName = "Zakupy", EventDescription = "Kup Marchewkę", Date = DateTime.Now}
                };
            MainEvents.ForEach(c  => context.Events.Add(c));
            context.SaveChanges();
        }
    }

   
}
