using System;
using System.Collections.Generic;
using System.Text;

namespace classlibrary
{
    public class WeeklyForecast
    {
       private DailyForecast[] forcasts = new DailyForecast[7];

        public WeeklyForecast(DailyForecast[] forecasts)
        {
            this.forcasts = forecasts;
        }
        public WeeklyForecast() { }
        public void SetForcasts(DailyForecast[] forcasts)
        {
            this.forcasts = forcasts;
        }
        public DailyForecast[] GetForcasts() { return this.forcasts; }
      
        public string GetAsString()
        {
            StringBuilder s = new StringBuilder();
            foreach (DailyForecast forecast in this.forcasts)
            {
                s.Append(forecast.GetAsString());
                s.Append("\n");
            }
            return s.ToString();
        }
        public DailyForecast this[int wordIndex]
        {
             get { return forcasts[wordIndex]; }
             set { forcasts[wordIndex] = value; }
         }
        public double GetMaxTemperature()
        {
            int max = 0;
            for (int i = 0; i < 7; i++)
            {
                if(forcasts[i].GetWeather() > forcasts[max].GetWeather())
                {
                    max = i;
                }
            }
            return forcasts[max].GetWeather().GetTemperature();
        }

        }
    }
