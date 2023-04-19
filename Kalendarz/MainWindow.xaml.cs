using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Komorka> komorki = new List<Komorka>();
        public MainWindow()
        {
            InitializeComponent();

        //Lista komorek (poszczegolnych dni wyswietlanych w miesiacu)
        

        //Zlicza ilosc komorek i je numeruje
        int count = 0;
            //Iteracja po wierszach siatce (Grid), którą nazwałem PanelKomorek
            for(int row = 2; row < 7; row++)
            {
                // po kolumnach
                for(int col = 0; col < 7; col++)
                {
                    // Tworze nowa komorke do wstawienia z parametrem int, który wyswietli w rogu komorki
                    Komorka komorka = new Komorka(count);
                    //Tworzy frame ktorej content ustawiam na stworzona komorke (nw dlaczego ale tak trzeba)
                    Frame f = new Frame
                    {
                        Content = komorka
                    };

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
             */
            IList<AddToCalendar> ListEvents;
            using (var db = new AddToCalendarContext())
            {
                ListEvents = db.Events.ToList();
            }

            komorki[5].AddEvent(ListEvents[1].EventName);
        }


        public void Open_New_Event(object sender, RoutedEventArgs e)
        {
            new_event newev = new new_event();
            newev.Show();
            Show11();

        }
        
        public void Show11()
        {
            IList<AddToCalendar> ListEvents1;
            using (var db = new AddToCalendarContext())
            {
                ListEvents1 = db.Events.ToList();
            }
            int SizeOfList = ListEvents1.Count;
            for(int i = 0; i < SizeOfList; i++)
            {
                Console.WriteLine(ListEvents1[i].EventName);
                komorki[i].AddEvent(ListEvents1[i].EventName);
            }
        }
        
    }
}


//new_event newev = new new_event();
/*
Frame ffr = new Frame
{
    Content = newev
};
PanelKomorek.Children.Add(ffr);
Grid.SetRow(ffr, 1);
// i kolumnie
Grid.SetColumn(ffr, 1);

using (var db = new AddToCalendarContext())
            {
                var query = db.Events
                              .Where(s =>  s.EventName == "Urodziny")
                              .FirstOrDefault<AddToCalendar>();
                komorki[5].AddEvent(query.EventDescription);
            }
*/
//dodanie w komorce szostej w liscie wydarzenia
//komorki[5].AddEvent("przeglad techniczny gruza");
//komorki[20].AddEvent("wywiadowka bachora");
//komorki[21].AddEvent("lanie bachora");