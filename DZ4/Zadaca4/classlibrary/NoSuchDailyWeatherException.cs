using System;
using System.Runtime.Serialization;

namespace classlibrary
{
    [Serializable]
    public class NoSuchDailyWeatherException : Exception
    {
       private DateTime date;
        public DateTime GetDate()
        {
            return date;
        }
        public NoSuchDailyWeatherException()
        {
        }

        public NoSuchDailyWeatherException(string message) : base(message)
        {
        }
        public NoSuchDailyWeatherException(string message, DateTime date) : base(message)
        {
            this.date = date;
        }

        public NoSuchDailyWeatherException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSuchDailyWeatherException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}