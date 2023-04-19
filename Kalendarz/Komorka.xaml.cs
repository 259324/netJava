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
        private int day;
        public Komorka(int day)
        {
            InitializeComponent();
            this.day = day;
            dayLabel.Content = day.ToString();
        }
        public void AddEvent(string name)
        {
            Label label = new Label();
            label.Content = name;
            eventsPanel.Children.Add(label);
        }
        public void clear(){
            events.Clear();
        }

    }

}
