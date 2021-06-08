using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InFood.Interfejsy;

namespace InFood.Klasy.System
{
    public class ConsoleLogWriter : ILogWriter
    {
        private static readonly object LOCK_WRITE = new object();
        public void Write(string a_sText)
        {
            lock (LOCK_WRITE)
            {
                if (!string.IsNullOrEmpty(a_sText))
                    Console.WriteLine(a_sText);
            }
        }
    }
}
