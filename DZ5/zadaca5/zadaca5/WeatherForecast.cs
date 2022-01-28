using System;
using System.Collections.Generic;
using System.Text;

namespace zadaca5
{
    public class WeatherForecast
    {
        public List<daily> daily { get; set; }
        public current current { get; set; }
    }
   
    public class temp
    {
        public double min { get; set; }
        public double max { get; set; }
    }
    public class weather
    {
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class current
    {
        public double temp { get; set; }
        public double humidity { get; set; }
        public double pressure { get; set; }
        public double wind_speed { get; set; }
        public List<weather> weather { get; set; }
    }
    public class daily
        {
            public double dt { get; set; }
            public temp temp { get; set; }
            public double humidity { get; set; }
            public double wind_speed { get; set; }
            public List<weather> weather { get; set; }

        }

   
}
