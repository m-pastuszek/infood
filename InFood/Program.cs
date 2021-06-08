using System;
using System.IO;
using InFood.Klasy;
using InFood.Klasy.BusinessLogic;
using InFood.Klasy.System;
using InFood.Klasy.Database;
using System.Collections.Generic;

namespace InFood
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.CurrentLevel = Log.LevelEnum.DEB;

            using var _log = Log.DEB("Program", "Main");

            _log.PR_DEB("to jest początek aplikacji");

            XmlStorageTypes.Initialize();

            


        }
    }
}
