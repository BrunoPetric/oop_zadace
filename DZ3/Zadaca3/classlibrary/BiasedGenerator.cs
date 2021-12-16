using System;
using System.Collections.Generic;
using System.Text;

namespace classlibrary
{
   public class BiasedGenerator : IRandomGenerator
    {

        private Random generator;

        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }
        public void SetGenerator(Random generator) { this.generator = generator; }
        public Random GetGenerator() { return this.generator; }
        public double Generate(double a, double b)
        {
            double c;
             c = generator.NextDouble() * (a - b) + b;
            if(c >= (a-b)/2)
            {
                c = generator.NextDouble() * (a - b) + b;
            }
            return c;
        }
    }
}
