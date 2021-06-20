using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InFood.Klasy.Toolbox
{
    class Fields
    {
        public static string PoleTekstowe(string a_sText, bool a_bCanBeEmpty = false)
        {
            while (true)
            {
                Console.Write($"| {a_sText}: ");

                string _sValue = Console.ReadLine();

                if (string.IsNullOrEmpty(_sValue) && a_bCanBeEmpty == false)
                {
                    Console.WriteLine("| ## Nic nie zostało wpisane. Spróbuj ponownie. ##                       |");
                }
                else
                    return _sValue;
            }
        }

        public static int PoleLiczbowe(string a_sText, bool a_bCanBeEmpty = false)
        {
            while (true)
            {
                Console.Write($"| {a_sText}: ");

                string _sValue = Console.ReadLine();

                if (string.IsNullOrEmpty(_sValue) && a_bCanBeEmpty == true)
                {
                    return 0;
                }
                else if (!string.IsNullOrEmpty(_sValue) && int.TryParse(_sValue, out int _iValue) == true)
                {
                    return _iValue;
                }

                else
                    Console.WriteLine("| ## Wprowadzono nieprawidłową wartość. Spróbuj ponownie. ##             |");
            }
        }

        public static decimal PoleWaga(string a_sText, bool a_bCanBeEmpty = false)
        {
            while (true)
            {
                Console.Write($"| {a_sText}: ");

                string _sValue = Console.ReadLine();

                if (!string.IsNullOrEmpty(_sValue) && decimal.TryParse(_sValue, out decimal _dValue))
                {
                    return _dValue;
                }
                else
                    Console.WriteLine("| ## Wprowadzono nieprawidłową wartość. Spróbuj ponownie. ##             |");
            }
        }
    }
}
