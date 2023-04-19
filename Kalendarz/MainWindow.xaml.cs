using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        public MainWindow()
        {
            InitializeComponent();

        //Lista komorek (poszczegolnych dni wyswietlanych w miesiacu)
        List<Komorka> komorki= new List<Komorka>();

        //Zlicza ilosc komorek i je numeruje
        int count = 0;
            //Iteracja po wierszach siatce (Grid), którą nazwałem PanelKomorek
            for(int row = 1; row < 7; row++)
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

            //dodanie w komorce szostej w liscie wydarzenia
            komorki[5].AddEvent("przeglad techniczny gruza");
            komorki[20].AddEvent("wywiadowka bachora");
            komorki[21].AddEvent("lanie bachora");

        }
    }
}
