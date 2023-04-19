using System;
using System.Collections.Generic;
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
    public partial class new_event : Window
    {
        public new_event()
        {
            InitializeComponent();
        }

        private void Dodaj_BT_Click(object sender, RoutedEventArgs e)
        {
            var context = new AddToCalendarContext();
            var temp = new AddToCalendar
            {
                //ID = 1,
                EventName = nazwa_TB.Text,
                EventDescription = opis_TB.Text
            };
            context.NewAddToCalendar(temp);
            Console.WriteLine("Test1");
            this.Close();
            //string TB_new_event = nazwa_TB.Text;

        }
    }
}
