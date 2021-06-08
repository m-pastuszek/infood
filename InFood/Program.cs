using System;
using System.IO;
using InFood.Klasy;
using InFood.Klasy.BusinessLogic;
using InFood.Klasy.System;

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

            Uzytkownik _oUzytkownik = new Uzytkownik
            {

            }
        }
    }
}
