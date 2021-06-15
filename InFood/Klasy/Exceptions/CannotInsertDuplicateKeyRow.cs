using System;

namespace InFood.Klasy.Exceptions
{
    public class CannotInsertDuplicateKeyRow : Exception
    {
        public CannotInsertDuplicateKeyRow() : base("Użytkownik o podanym loginie istnieje już w bazie!")
        {
        }
    }
}
