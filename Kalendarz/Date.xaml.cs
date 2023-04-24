using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Date.xaml
    /// </summary>
    public partial class Date : Page
    {
        public DateTime ViewedDate { get; set; }
        private readonly MainWindow Main;
        readonly string[] months = { "Styczeń", "Luty", "Marzec", "Kwiecień", "Maj", "Czerwiec", "Lipiec", "Sierpień", "Wrzesień", "Październik", "Listopad", "Grudzień" };
        public int TotalDays;
        public Date(MainWindow main)
        {
            InitializeComponent();
            ViewedDate = DateTime.Now;
            yearLabel.Content = ViewedDate.Year;
            monthLabel.Content = months[ViewedDate.Month - 1];
            Main = main;
            TotalDays = DateTime.DaysInMonth(ViewedDate.Year, ViewedDate.Month);
        }
        public void PrevYear(object sender, RoutedEventArgs e)
        {
            ViewedDate = ViewedDate.AddMonths(-12);
            Reload();
            

        }
        public void NextYear(object sender, RoutedEventArgs e)
        {
            ViewedDate = ViewedDate.AddMonths(12);
            Reload();

        }
        public void PrevMonth(object sender, RoutedEventArgs e)
        {
            ViewedDate = ViewedDate.AddMonths(-1);
            Reload();

        }
        public void NextMonth(object sender, RoutedEventArgs e)
        {
            ViewedDate = ViewedDate.AddMonths(1);
            Reload();
        }

        public void Reload()
        {
            yearLabel.Content = ViewedDate.Year;
            monthLabel.Content = months[ViewedDate.Month - 1];
            TotalDays = DateTime.DaysInMonth(ViewedDate.Year, ViewedDate.Month);
            Main.ReloadCells();
        }

        public int FirstDayOfTheMonth()
        {
            DateTime tmp = ViewedDate;
            tmp = tmp.AddDays(-(tmp.Day-1));
            // 1 - pon, 7 - nd
            return ((int)tmp.DayOfWeek);
        }


    }
}
