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
        public Weather Weather
        {
            get { return this.weather; }

        }
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

        public override string ToString()
        {
            return $"{date}: {weather.ToString()}";
        }

    }
}
