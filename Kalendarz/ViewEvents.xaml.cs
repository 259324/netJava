using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Kalendarz
{
    /// <summary>
    /// Logika interakcji dla klasy ViewEvents.xaml
    /// </summary>
    public partial class ViewEvents : Window
    {
        public ViewEvents()
        {
            InitializeComponent();

            IList<Event> ListEvents;

            using (var context = new EventContext())
            {
                ListEvents = context.Events.ToList();
            }

            foreach(var ev in ListEvents)
            {
                Grid grid = new Grid
                {


            };
                RowDefinition eventRow = new RowDefinition { };
                grid.RowDefinitions.Add(eventRow);

                ColumnDefinition labelColumn = new ColumnDefinition();
                grid.ColumnDefinitions.Add(labelColumn);

                ColumnDefinition dateColumn = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) };
                grid.ColumnDefinitions.Add(dateColumn);


                Label eventLabel = new Label { Content = ev.EventName, HorizontalAlignment= HorizontalAlignment.Left};
                grid.Children.Add(eventLabel);
                Grid.SetRow(eventLabel, 0);
                Grid.SetColumn(eventLabel, 0);

                Label eventDate = new Label { Content = ev.Date.ToString("dd.MM.yyyy") , HorizontalAlignment = HorizontalAlignment.Right};
                grid.Children.Add(eventDate);
                Grid.SetRow(eventDate, 0);
                Grid.SetColumn(eventDate, 1);

                events_list.Children.Add(grid);
            }
        }
    }
}
