using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InFood.Klasy.Menu
{
    class HelperClasses
    {
        public static void ZlyWybor()
        {
            Console.WriteLine("| Zły wybór. Proszę wybrać 1, 2, lub 3.                                  |");
            PressEnterToContinue();
        }

        public static void PressEnterToContinue()
        {
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Naciśnij ENTER, aby kontynuować.                                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.ReadKey();
        }
    }
}
