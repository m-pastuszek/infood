using System;

namespace InFood.Klasy.Exceptions
{
    public class StateObjectReferenceIsNull : Exception
    {
        public StateObjectReferenceIsNull() : base("Referencja do obiektu jest null!")
        {

        }
    }
}
