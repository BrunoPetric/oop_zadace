using System;
using System.Collections.Generic;
using System.Text;

namespace classlibrary
{
    public class UniformGenerator : IRandomGenerator
    {
        private Random generator;

        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }
        public void SetGenerator(Random generator) { this.generator = generator; }
        //public Random GetGenerator() { return this.generator; }
        public double Generate(double a, double b)
        {
            return generator.NextDouble() *(a-b) + b;
        }
    }
}
