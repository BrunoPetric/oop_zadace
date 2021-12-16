using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace classlibrary
{
    public class FilePrinter : IPrinter
    {
        private string path;

        public FilePrinter(string path)
        {
            this.path = path;
        }
        public void Print(string message)
        {
            using (var writer = new StreamWriter(path, true))
                 {
                 writer.WriteLine(message);
                 }

        }
    }
}
