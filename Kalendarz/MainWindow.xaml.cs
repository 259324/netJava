﻿using System;
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
    /// Main class which integrates all classes and functions 
    /// </summary>
    public partial class MainWindow : Window
    {
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
        /// <summary>
        /// Function loads date 
        /// </summary>
        public void LoadDate()
        {
            Frame f = new Frame { Content = mViewedDate };
            PanelKomorek.Children.Add(f);
            Grid.SetRow(f, 0);
            Grid.SetColumn(f, 0);
            Grid.SetColumnSpan(f, 7);
        }
        /// <summary>
        /// Function loads event to exact cell in calendar
        /// </summary>
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
        /// <summary>
        /// Function loads content for every cell and generate view of calendar
        /// </summary>
        public void LoadCells()
        {
            for (int row = 2; row < 8; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Komorka komorka = new Komorka();
                    Frame f = new Frame { Content = komorka }; 
                    komorki.Add(komorka);
                    PanelKomorek.Children.Add(f);                 
                    Grid.SetRow(f, row);
                    Grid.SetColumn(f, col);
                }
            }
        }
        /// <summary>
        /// Function download temperature data for Wroclaw and Warsaw city 
        /// </summary>
        public async Task LoadWeatherData() 
        {
            var weatherDataWro = await WeatherDataSource.GetWeatherDataAsync("wroclaw");
            WeatherLabelWro.Content = String.Format("pogoda: {0} {1} C", weatherDataWro.Stacja, weatherDataWro.Temperatura);
            var weatherDataWwa = await WeatherDataSource.GetWeatherDataAsync("warszawa");
            WeatherLabelWwa.Content = String.Format("pogoda: {0} {1} C", weatherDataWwa.Stacja, weatherDataWwa.Temperatura);
        }
        /// <summary>
        /// Function reload content of cell 
        /// </summary>
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
        /// <summary>
        /// Function regards to button that shows new event window
        /// </summary>
        public void Open_New_Event(object sender, RoutedEventArgs e)
        {
            NewEventWindow mNewEventWindow = new NewEventWindow();
            mNewEventWindow.ShowDialog();
            LoadEvents();
        }
        /// <summary>
        /// Function regards to button that shows existing event window
        /// </summary>
        public void View_Events(object sender, RoutedEventArgs e)
        {
            ViewEvents mViewEvents = new ViewEvents();
            mViewEvents.ShowDialog();
            LoadEvents();
        }
    }
}
