using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Kalendarz
{
    /// <summary>
    /// Logika interakcji dla klasy ViewEvents.xaml
    /// </summary>
    public partial class ViewEvents : Window
    {
        IList<Event> ListEvents;

        public ViewEvents()
        {
            InitializeComponent();


            using (var context = new EventContext())
            {
                ListEvents = context.Events.ToList();
            }

            events_list.ItemsSource = ListEvents;
        }

        public void Delete(object sender, RoutedEventArgs e)
        {
            Event obj = ((FrameworkElement)sender).DataContext as Event;
            using (var context = new EventContext())
            {
                var element = context.Events.Find(obj.ID);
                if (element != null)
                {
                    context.Events.Remove(element);
                    context.SaveChanges();
                    ListEvents = context.Events.ToList();
                    events_list.ItemsSource = null;
                    events_list.ItemsSource = ListEvents;
                }
            }
        }
    }
}
