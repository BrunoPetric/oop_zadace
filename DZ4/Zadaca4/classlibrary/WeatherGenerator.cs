using System;
using System.Collections.Generic;
using System.Text;

namespace classlibrary
{
    public class WeatherGenerator
    {
        double minTemperature, maxTemperature, minHumidity, maxHumidity, minWindSpeed, maxWindSpeed;
        IRandomGenerator generator;

        public WeatherGenerator(double minTemperature, double maxTemperature, double minHumidity, double maxHumidity, double minWindSpeed, double maxWindSpeed, IRandomGenerator generator)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.minHumidity = minHumidity;
            this.maxHumidity = maxHumidity;
            this.minWindSpeed = minWindSpeed;
            this.maxWindSpeed = maxWindSpeed;
            this.generator = generator;
        }
        public void SetGenerator(IRandomGenerator generator)
        {
            this.generator = generator;
        }

        public Weather Generate()
        {
            return new Weather(generator.Generate(maxTemperature, minTemperature), generator.Generate(maxHumidity, minHumidity), generator.Generate(maxWindSpeed, minWindSpeed));
        }

    }
}
