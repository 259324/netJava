using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Kalendarz
{
    public class WeatherData
    {
        public static WeatherData FromJson(Dictionary<string, string> json) { return new WeatherData(json["id_stacji"], json["stacja"], json["data_pomiaru"], json["godzina_pomiaru"], json["temperatura"], json["predkosc_wiatru"], json["kierunek_wiatru"], json["wilgotnosc_wzgledna"], json["suma_opadu"], json["cisnienie"]); }
        public WeatherData(string idStacji, string stacja, string dataPomiaru, string godzinaPomiaru, string temperatura, string predkoscWiatru, string kierunekWiatru, string wilgotnoscWzgledna, string sumaOpadu, string cisnienie)
        {
            IdStacji = idStacji;
            Stacja = stacja;
            DataPomiaru = dataPomiaru;
            GodzinaPomiaru = godzinaPomiaru;
            Temperatura = temperatura;
            PredkoscWiatru = predkoscWiatru;
            KierunekWiatru = kierunekWiatru;
            WilgotnoscWzgledna = wilgotnoscWzgledna;
            SumaOpadu = sumaOpadu;
            Cisnienie = cisnienie;
        }
        public string IdStacji { get; set; }
        public string Stacja { get; set; }
        public string DataPomiaru { get; set; }
        public string GodzinaPomiaru { get; set; }
        public string Temperatura { get; set; }
        public string PredkoscWiatru { get; set; }
        public string KierunekWiatru { get; set; }
        public string WilgotnoscWzgledna { get; set; }
        public string SumaOpadu { get; set; }
        public string Cisnienie { get; set; }
    }


    internal class WeatherDataSource
    {
        private static readonly HttpClient client = new HttpClient();
        private const string url = "https://danepubliczne.imgw.pl/api/data/synop/station/";

        public static async Task<WeatherData> GetWeatherDataAsync(string city)
        {   
            
            var response = await client.GetAsync(url+city);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseBody);
            var weatherdata = WeatherData.FromJson(data);
            return weatherdata;
        }

    }
}
