using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TBot
{
    class Parser
    {
        static HttpClient httpClient = new HttpClient();
        public static string GetTemperature(string Title)
        {
            try
            {
                string url = $"https://api.openweathermap.org" +
                    $"/data/2.5/weather?" +
                    $"q={Title}&units=metric&appid=197c182f49e41dcf2f5329c267b1734b";
                string data = httpClient.GetStringAsync(url).Result;
                dynamic r = JObject.Parse(data);
                return $" Температура равна {r.main.temp}C\n Скорость ветра: {r.wind.speed}m/s\n Страна: {r.sys.country}";
            }
            catch (Exception)
            {
                return "ошибка запроса...";
            }
        }
    }
}
