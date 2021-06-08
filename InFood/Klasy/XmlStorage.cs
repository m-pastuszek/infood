using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using InFood.Classes;


namespace InFood
{
    public static class XmlStorageTypes
    {
        private static readonly List<Type> KnownTypes = new List<Type>();

        static XmlStorageTypes()
        {
            Register<Object>();

        }
    }
}
