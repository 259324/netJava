using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Input.StylusWisp;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalendarz
{
    /// <summary>
    /// Logika interakcji dla klasy new_event.xaml
    /// </summary>
    public partial class NewEventWindow : Window
    {
        public NewEventWindow()
        {
            InitializeComponent();
            date_picker.SelectedDate = DateTime.Now;
        }

        private void AddEvent(object sender, RoutedEventArgs e)
        {
            if(date_picker.SelectedDate==null)
            {
                label.Content = "Wybierz datę!";
            }
            if(nazwa_TB.Text=="")
            {
                label.Content = "Wprowadź nazwę!";
            }
            else
            {
                using (var context = new EventContext())
                {
                    var temp = new Event
                    {
                        ID = context.Events.Count() + 1,
                        EventName = nazwa_TB.Text,
                        EventDescription = opis_TB.Text,
                        Date = (DateTime)date_picker.SelectedDate
                    };

                    context.Events.Add(temp);
                    context.SaveChanges();

                }
                this.Close();
            }

        }
    }
}
