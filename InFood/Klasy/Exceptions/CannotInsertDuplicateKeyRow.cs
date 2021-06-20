using System;

namespace InFood.Klasy.Exceptions
{
    public class CannotInsertDuplicateKeyRow : Exception
    {
        public CannotInsertDuplicateKeyRow() : base("Duplikacja wartości w bazie. Spróbuj zmienić dane.")
        {
        }
    }
}
