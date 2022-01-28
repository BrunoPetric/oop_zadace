using System;
using System.Collections.Generic;
using System.Text;

namespace zadaca5
{
    public class WeatherInfo
    {
        public coord coord { get; set; }
    }
        public class coord
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }
     //   public class weather
     //   {
     //       public string main { get; set; }
     //       public string desc { get; set; }
     //       public string icon { get; set; }
     //   }
     //   public class main
     //   {
     //       public double temp { get; set; }
     //       
     //   }

    //   public class forecast
    //   {
    //       
    //      // public List<weather> weather { get; set; }
    //      // public main main { get; set; }
    //   }
    
}
