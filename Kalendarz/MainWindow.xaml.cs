using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Kalendarz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Lista komorek (poszczegolnych dni wyswietlanych w miesiacu)
        public List<Komorka> komorki = new List<Komorka>();
        private readonly ViewedDate mViewedDate;



        public MainWindow()
        {
            InitializeComponent();

            mViewedDate = new ViewedDate(this);

            LoadDate();

            LoadCells();

            ReloadCells();

            LoadEvents();

            _ = LoadWeatherData();

        }

        public void LoadDate()
        {
            Frame f = new Frame { Content = mViewedDate };
            PanelKomorek.Children.Add(f);
            Grid.SetRow(f, 0);
            Grid.SetColumn(f, 0);
            Grid.SetColumnSpan(f, 7);
        }

        public void LoadEvents()
        {
            IList<Event> ListEvents;

            foreach (var k in komorki)
            {
                k.ClearEvents();
            }

            using (var context = new EventContext())
            {
                ListEvents = context.Events.ToList();
            }

            foreach (var k in ListEvents)
            {
                for(int i=0;i<komorki.Count;i++)
                {
                    if(komorki[i].date.Date == k.Date.Date)
                    {
                        komorki[i].AddEvent(k);
                    }
                }
            }
        }

        public void LoadCells()
        {
            //Iteracja po wierszach siatce (Grid), którą nazwałem PanelKomorek
            for (int row = 2; row < 8; row++)
            {
                // po kolumnach
                for (int col = 0; col < 7; col++)
                {
                    // Tworze nowa komorke do wstawienia z parametrem int, który wyswietli w rogu komorki
                    Komorka komorka = new Komorka();
                    //Tworzy frame ktorej content ustawiam na stworzona komorke (nw dlaczego ale tak trzeba)
                    Frame f = new Frame { Content = komorka };
                    //dodaje nowo powstala komorke do listy zeby zachowac wskaznik do niej
                    komorki.Add(komorka);

                    //Dodanie elementu do siatki (tego Frame-a)
                    PanelKomorek.Children.Add(f);
                    //ustawienie w ktorym wierszu ma byc
                    Grid.SetRow(f, row);
                    // i kolumnie
                    Grid.SetColumn(f, col);
                }
            }
        }
     
        public async Task LoadWeatherData() 
        {
            var weatherDataWro = await WeatherDataSource.GetWeatherDataAsync("wroclaw");
            WeatherLabelWro.Content = String.Format("pogoda: {0} {1} C", weatherDataWro.Stacja, weatherDataWro.Temperatura);
            var weatherDataWwa = await WeatherDataSource.GetWeatherDataAsync("warszawa");
            WeatherLabelWwa.Content = String.Format("pogoda: {0} {1} C", weatherDataWwa.Stacja, weatherDataWwa.Temperatura);
        }

        public void ReloadCells()
        {
            DateTime tmp = new DateTime(mViewedDate.date.Year, mViewedDate.date.Month, 1);

            while(tmp.DayOfWeek != DayOfWeek.Monday)
            {
                tmp = tmp.AddDays(-1);
            }

            foreach (var k in komorki)
            {
                k.date = tmp;
                tmp = tmp.AddDays(1);

                if(k.date.Month == mViewedDate.date.Month)
                {
                    k.SetDark();
                }
                else
                {
                    k.SetLight();
                }
            }
        }

        public void Open_New_Event(object sender, RoutedEventArgs e)
        {
            NewEventWindow mNewEventWindow = new NewEventWindow();
            mNewEventWindow.ShowDialog();
            LoadEvents();
        }

        public void View_Events(object sender, RoutedEventArgs e)
        {
            ViewEvents mViewEvents = new ViewEvents();
            mViewEvents.ShowDialog();
            LoadEvents();
        }
    }
}
