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
    /// </summary>
    public partial class Komorka : Page
    {
        private List<string> events = new List<string>();

        private SolidColorBrush  dark = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF240B27"));
         
        public Komorka(int day)
        {
            InitializeComponent();
            dayLabel.Content = day.ToString();
        }

        public void SetDark(int day)
        {
            dayLabel.Content = day.ToString();
            Values.Background = dark;
            dayLabel.Foreground = Brushes.White;

        }

        public void SetLight(int day)
        {
            dayLabel.Content = day.ToString();
            Values.Background = Brushes.White;
            dayLabel.Foreground = Brushes.Gray;
        }

        public void AddEvent(string name)
        {
            Label label = new Label{Content = name};
            eventsPanel.Children.Add(label);
        }
    }

}
