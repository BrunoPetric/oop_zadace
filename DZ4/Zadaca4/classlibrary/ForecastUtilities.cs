using System;
using System.Collections.Generic;
using System.Text;

namespace classlibrary
{
    public class ForecastUtilities
    {
        public static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {
            Weather maxObj = weathers[0];
            double maxx = weathers[0].CalculateWindChill();

            foreach (Weather weather in weathers)
            {
                if (weather.CalculateWindChill() > maxx)
                {
                    maxx = weather.CalculateWindChill();
                    maxObj = weather;
                }
            }
            return maxObj;
        }
        public static DailyForecast Parse(string parse)
        {
            string datum = parse.Substring(0,19);
            string vrijeme = parse.Substring(20);
            var dateString = datum;
            DateTime date1 = Convert.ToDateTime(datum);//DateTime.Parse(dateString, System.Globalization.CultureInfo.CurrentCulture);
            string[] weathers = vrijeme.Split(',');
            weathers[0] = weathers[0].Replace('.',',');
            weathers[1] = weathers[1].Replace('.', ',');
            weathers[2] = weathers[2].Replace('.', ',');
            Weather weather = new Weather(Convert.ToDouble(weathers[0]), Convert.ToDouble(weathers[2]), Convert.ToDouble(weathers[1]));

            return new DailyForecast(date1, weather);
        }
        public static void PrintWeathers(IPrinter[] printers, Weather[] weathers)
        {
            foreach (IPrinter printer in printers)
            {         
            foreach (Weather weather in weathers)
            {
                printer.Print(weather.ToString());
            }
            }
        }
    }
}
