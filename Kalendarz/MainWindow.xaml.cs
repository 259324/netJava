using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private readonly Date date;

        
        public MainWindow()
        {
            InitializeComponent();

            date = new Date(this);

            LoadDate();

            LoadCells();

            ReloadCells();

            LoadEvents();

            LoadWeatherData();

            

            /*
            void NewAddtoCalendar(AddToCalendar addToCalendar)
            {
                using (var db = new AddToCalendarContext())
                {
                    db.Events.Add(addToCalendar);
                    db.SaveChanges();
                }
            }
            */
            /*
            var context = new AddToCalendarContext();
            var temp = new AddToCalendar
            {
                ID = 1,
                EventName = "Urodziny 3",
                EventDescription = "5 urodziny Kasi"
            };
            context.NewAddToCalendar(temp);
            
             var temp1 = new AddToCalendar
             {
                 ID = 2,
                 EventName = "Zakupy",
                 EventDescription = "Kup marchewke"
             };


            komorki[5].AddEvent(ListEvents[1].EventName);
             */

        }

        public void LoadDate()
        {
            Frame f = new Frame { Content = date };
            PanelKomorek.Children.Add(f);
            Grid.SetRow(f, 0);
            Grid.SetColumn(f, 0);
            Grid.SetColumnSpan(f, 7);
        }

        public void LoadEvents()
        {
            IList<Event> ListEvents;
            using (var db = new EventContext())
            {
                ListEvents = db.Events.ToList();
            }

            for (int i = 0; i < ListEvents.Count; i++)
                komorki[i].AddEvent(ListEvents[i].EventName);
        }

        public void LoadCells()
        { //Zlicza ilosc komorek i je numeruje
            int count = 0;
            //Iteracja po wierszach siatce (Grid), którą nazwałem PanelKomorek
            for (int row = 2; row < 8; row++)
            {
                // po kolumnach
                for (int col = 0; col < 7; col++)
                {
                    // Tworze nowa komorke do wstawienia z parametrem int, który wyswietli w rogu komorki
                    Komorka komorka = new Komorka(count);
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
                    count++;
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
            DateTime PrevMonth = date.ViewedDate.AddMonths(-1);

            int PrevDaysInMonth = DateTime.DaysInMonth(PrevMonth.Year, PrevMonth.Month);

            int cellCount = 0;
            int PrevDayCount, CurrDayCount = 1, NextDayCount=1;

            //Dodanie dni poprzedniego miesiąca
            PrevDayCount = PrevDaysInMonth - date.FirstDayOfTheMonth() +2;
            while (PrevDayCount< PrevDaysInMonth+1)
                komorki[cellCount++].SetLight(PrevDayCount++);

            //Dodanie dni aktualnego miesiąca
            while(CurrDayCount<=date.TotalDays)
                komorki[cellCount++].SetDark(CurrDayCount++);

            //Dodanie dni następnego miesiąca
            while (cellCount < 42)
                komorki[cellCount++].SetLight(NextDayCount++);
        }

        public void Open_New_Event(object sender, RoutedEventArgs e)
        {
            NewEventWindow newev = new NewEventWindow();
            newev.Show();
            Show11();

        }

        public void Show11()
        {
            IList<Event> ListEvents1;
            using (var db = new EventContext())
            {
                ListEvents1 = db.Events.ToList();
            }
            int SizeOfList = ListEvents1.Count;
            for (int i = 0; i < SizeOfList; i++)
            {
                Console.WriteLine(ListEvents1[i].EventName);
                komorki[i].AddEvent(ListEvents1[i].EventName);
            }
        }

    }
}
