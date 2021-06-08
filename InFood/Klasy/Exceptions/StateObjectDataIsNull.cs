using System;

namespace InFood.Klasy.Exceptions
{
    public class StateObjectDataIsNull : Exception
    {
        public StateObjectDataIsNull() : base("Referencja do danych jest null!")
        {
        }
    }
}
