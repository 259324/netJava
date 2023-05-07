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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalendarz
{
    /// <summary>
    /// Interaction logic for Komorka.xaml
    /// Class presents cell of the day 
    /// </summary>
    public partial class Komorka : Page
    {

        private SolidColorBrush dark = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF240B27"));

        public DateTime date;

        private bool isDark = false;
        public Komorka()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Changes colour of cell to dark
        /// </summary>
        /// <param name="day">Number of day</param>
        public void SetDark()
        {
            dayLabel.Content = date.Day.ToString();
            Values.Background = dark;
            dayLabel.Foreground = Brushes.White;
            isDark=true;
        }
        /// <summary>
        /// Changes colour of cell to white
        /// </summary>
        /// <param name="day">Number of day</param>
        public void SetLight()
        {
            dayLabel.Content = date.Day.ToString();
            Values.Background = Brushes.White;
            dayLabel.Foreground = Brushes.Gray;
            isDark=false;
        }
        /// <summary>
        /// Adds new event to cell
        /// </summary>
        /// <param name="name">name of the event</param>
        public void AddEvent(Event ev)
        {
            Label label = new Label{Content = ev.EventName, Height = Double.NaN};
            if(isDark)
            {
                label.Foreground = Brushes.White;
            }
            else
            {
                label.Foreground = Brushes.Gray;
            }
            //Label label = new Label { Content = "dwad", Foreground=Brushes.Red};
            eventsPanel.Children.Add(label);
        }

        public void ClearEvents()
        {
            eventsPanel.Children.Clear();
        }
    }
}
