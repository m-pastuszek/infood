﻿using System;
using InFood.Klasy.Exceptions;

namespace InFood.Klasy
{
    public class StateObject
    {
        private readonly object m_oObject;
        private readonly object m_oData;

        public StateObject(object a_oObject, object a_oData = null)
        {
            m_oObject = a_oObject;
            m_oData = a_oData;
        }

        public T GetObject<T>()
        {
            if (m_oObject == null)
                throw new StateObjectReferenceIsNull();

            return (T)Convert.ChangeType(m_oObject, typeof(T));
        }

        public T GetData<T>()
        {
            if (m_oData == null)
                throw new StateObjectDataIsNull();

            return (T)Convert.ChangeType(m_oData, typeof(T));
        }
    }
}
