using System;
using System.Collections.Generic;
using System.Text;

namespace classlibrary
{
    public class ConsolePrinter : IPrinter
    {
        private ConsoleColor color;
        public void SetColor(ConsoleColor color) { this.color = color; }
        public ConsoleColor GetColor() { return this.color; }

        public ConsolePrinter(ConsoleColor color = ConsoleColor.White)
        {
            this.color = color;
        }

        public void Print(string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }

    }
}
