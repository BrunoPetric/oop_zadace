using System;
using System.Collections.Generic;
using System.Text;

namespace classlibrary
{
    public class DailyForecast
    {
       private DateTime date;
       private Weather weather;

        public DailyForecast(DateTime date, Weather weather)
        {
            this.date = date;
            this.weather = weather;
        }
        public DailyForecast() { }
        public void SetDate(DateTime date)
        {
            this.date = date;
        }
        public void SetWeather(Weather weather)
        {
            this.weather = weather;
        }
        public DateTime GetDateTime() { return this.date; }
        public Weather GetWeather() { return this.weather; }

        public string GetAsString()
        {
            return $"{date}: {weather.GetAsString()}";
        }

    }
}
