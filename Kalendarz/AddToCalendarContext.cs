using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace Kalendarz
{
    public class AddToCalendarContext : DbContext
    {
        public AddToCalendarContext()
            : base("AddToCalendar")
        {
            Database.SetInitializer(new CalendarDbInitializer());
        }

        public DbSet<AddToCalendar> Events { get; set; }

        public void NewAddToCalendar(AddToCalendar addToCalendar)
        {
            using (var context = new AddToCalendarContext())
            {
                context.Events.Add(addToCalendar);
                context.SaveChanges();
            }
        }
    }

    public class CalendarDbInitializer : DropCreateDatabaseAlways<AddToCalendarContext>
    {
        protected override void Seed(AddToCalendarContext context)
        {
            var MainEvents = new List<AddToCalendar>
                {
                new AddToCalendar() {ID = 1, EventName = "Urodziny", EventDescription = "Urodziny Asi"},
                new AddToCalendar() {ID = 2, EventName = "Zakupy", EventDescription = "Kup Marchewkę"}
                };
            MainEvents.ForEach(c  => context.Events.Add(c));
            context.SaveChanges();
        }
    }

   
}
