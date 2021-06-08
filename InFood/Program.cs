using System;
using System.IO;
using InFood.Klasy;
using InFood.Klasy.BusinessLogic;
using InFood.Klasy.System;
using InFood.Klasy.Database;

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

            /*Uzytkownik.DodajUzytkownika("test", "123qwe", 1);*/

            SqlDatabase.PodlaczBaze();
           
            /*

            User _oUser = new User();
            try
            {
                if (_oUser.ImportFromFile("user.xml"))
                {
                    Console.WriteLine(_oUser);
                }
                else
                {
                    Console.WriteLine("Coś nie pykło...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/
        }
    }
}
