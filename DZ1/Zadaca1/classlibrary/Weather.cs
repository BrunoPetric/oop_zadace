using System;
using System.Collections.Generic;
using System.Text;

namespace Zadaca1
{
    public class Weather
    {
        private double temperature;
        private double humidity;
        private double windSpeed;

        public Weather(double temperature, double humidity, double windSpeed)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
        }
        public Weather() { }

        public void SetTemperature(double temperature) { this.temperature = temperature; }
        public void SetHumidity(double humidity) { this.humidity = humidity; }
        public void SetWindSpeed(double windSpeed) { this.windSpeed = windSpeed; }
        public double GetTemperature() { return this.temperature; }
        public double GetHumidity() { return this.humidity; }
        public double GetWindSpeed() { return this.windSpeed; }

        public double CalculateFeelsLikeTemperature()
        {
            return -8.78469475556 + 1.61139411 * this.temperature + 2.33854883889 * this.humidity + -0.14611605 * this.temperature * this.humidity + -0.012308094 * this.temperature * this.temperature + -0.0164248277778 * this.humidity * this.humidity + 0.002211732 * this.temperature * this.temperature * this.humidity + 0.00072546 * this.temperature * this.humidity * this.humidity + -0.000003582 * this.temperature * this.temperature * this.humidity * this.humidity;

        }
        public double CalculateWindChill()
        {
            if (this.windSpeed < 4.8 || this.temperature > 10)
                return 0;
            return 13.12 + 0.6215 * this.temperature - 11.37 * Math.Pow(this.windSpeed, 0.16) + 0.3965 * this.temperature *Math.Pow(this.windSpeed, 0.16) ;
        }
    
    }
}
