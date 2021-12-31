using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace classlibrary
{
    public class DailyForecastRepository : IEnumerable, IEnumerator
    {
        private List<DailyForecast> list;
        int position = -1;

        public DailyForecastRepository()
        {
            list = new List<DailyForecast>();
        }
        public DailyForecastRepository(DailyForecastRepository oldRepository)
        {
            list = new List<DailyForecast>();
            foreach (DailyForecast forecast in oldRepository.list)
            {
                Add(forecast);
            }
        }
        
        public void Add(DailyForecast newDailyForecast)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetDateTime().Year == newDailyForecast.GetDateTime().Year && list[i].GetDateTime().Month == newDailyForecast.GetDateTime().Month && list[i].GetDateTime().Day == newDailyForecast.GetDateTime().Day)
                    list.RemoveAt(i);
            }
            list.Add(newDailyForecast);
            list.Sort((x, y) => x.GetDateTime().CompareTo(y.GetDateTime()));
        }
        public void Add(List<DailyForecast> newList)
        {
            foreach (DailyForecast forecast in newList)
            {
                Add(forecast);
            }
           
        }
        public void Remove(DateTime date)
        {
            bool flag = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetDateTime().Year == date.Year && list[i].GetDateTime().Month == date.Month && list[i].GetDateTime().Day == date.Day) 
                {
                
                    list.RemoveAt(i);
                    flag = true;
                }
            }
            if(flag == false)
            {
                throw new NoSuchDailyWeatherException($"No daily forecast for {date}", date);
            }
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return (position < list.Count);
        }
        //IEnumerable
        public void Reset()
        {
            position = -1;
        }
        //IEnumerable
        public object Current
        {
            get { return list[position]; }
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (DailyForecast forecast in list)
            {
                s.Append(forecast.ToString());
                s.Append("\n");
            }
            return s.ToString();
        }

    }
}
