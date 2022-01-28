using System;
using System.Collections.Generic;
using System.Text;

namespace zadaca5
{
    public class TodayForecast
    {
        public List<list> list { get; set; }
    }
    public class main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double humidity { get; set; }
    }
    public class wind
    {
        public double speed { get; set; }
    }
    public class list
    {
        public main main { get; set; }
        public List<weather> weather { get; set; }
        public wind wind { get; set; }
        public string dt_txt { get; set; }
    }
}
