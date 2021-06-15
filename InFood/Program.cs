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
            Uzytkownik.AddUserToDatabase("test123", "pass123", 1);

            /*          Dictionary<string, object> changedData = new Dictionary<string, object>();
                      changedData.Add("@HasloChanged", "testChanged");

                      Uzytkownik.DeleteUserFromDatabase("testChanged");*/

            Console.ReadLine();

            private static bool MainMenu()
            {
                Console.Clear();
                Console.WriteLine("1) Zaloguj sie");
                Console.WriteLine("2) Zarejestruj sie");
                Console.WriteLine("3) Wyjscie z aplikacji");

                switch (Console.ReadLine())
                {
                    case 1:
                        if (nazwa uzytkownika jest w bazie)
                        {
                Console.WriteLine("Zalogowano");
                switch to LoginMenu
                        }
                        else
                break:
            {
                Console.WriteLine("Nieprawidlowa nazwa uzytkownika");
                break;
                switch to MainMenu;
           
                    case 2:
                Console.WriteLine("Podaj login uzytkownika");
                Console.ReadLine(nazwa uzytkownika);
                Console.WriteLine("Podaj haslo uzytkownika");
                Console.ReadLine(haslo uzytkownika);
                Console.WriteLine("Uzytkownik dodany";
                switch to MainMenu;
                break;
                    case 3:
                        public static void Exit();
            default:
                     Console.WriteLine("Zly wybor. Prosze wybrac 1, 2, or 3.");
            break;
        }
    }

    private static bool LoginMenu)
            {
                Console.Clear();
                Console.WriteLine("1) Wybierz lokalizację");
                Console.WriteLine("2) Wyświetl historię produktów");
                Console.WriteLine("3) Zarzadzaj kontem");
                Console.WriteLine("4) Wyjscie z aplikacji");

                switch (Console.ReadLine())
                {
                    case 1:
                        if (odebrane produkty = jakaś wartość) or(oddane produkty = jakas wartosc)
    {
        if
            {
            (odebrane produkty = jakas wartosc)
                            Console.WriteLine(odebrane produkty);
        }
        else
        {
            Console WriteLine(oddane produkty);

        }
                        else
        {
            Console.Writeline("uzytkownik nie posiada odebranych ani oddanych produktow")
                    switch to LoginMenu;
                    case 2:
                       if (dostepne skrytki = jakaś wartość)
                        {
                Console.WriteLine("dostepne skrytki");
                switch to SkrytkiMenu
                        }
                        else
            {
                Console.Writeline("zadne skrytki nie sa dostepne");
                break;
                    case 3:
                    switch to KontoMenu
                    case 4:
                        public static void Exit();
            default:
                        Console.WriteLine("Zly wybor. Prosze wybrac 1, 2, or 3.");
            break;
        }
    }
    private static bool Kontomenu)
            {
        Console.Clear();
        Console.WriteLine("1) Zmien login");
        Console.WriteLine("2) Zmien haslo");
        Console.WriteLine("3) Powrot do menu uzytkownika);
        Console.WriteLine("4)Wyjscie z aplikacji);
        switch (Console.ReadLine())
        {
        case 1:
        Console.WriteLine("Podaj nowe haslo");
        Console.ReadLine(NOWE HASLO);
        Console.WriteLine("haslo zmienione pomyslnie);
        break;
        case 2
 private static bool LokalizacjaMenu)
            {
    Console.Clear();
    Console.WriteLine("Wybierz skrytke");
    Console.WriteLine("1) Grunwald");
    Console.WriteLine("2) Nowe Miasto");
    Console.WriteLine("3) Jeżyce");
    Console.WriteLine("4) Stare Miasto");
    Console.WriteLine("5) Wilda");
    Console.WriteLine("6) Powrot do menu uzytkowika");
    Console.WriteLine("7) Wyjscie z aplikacji");
    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("W skrytce Grunwald znajduje sie"  GRUNWALD ILOSC  "miejsc");
            Console.WriteLine("1) Dodaj produkt do skrytki");
            Console.WriteLine("2) Usun produkt ze skrytki");
            Console.WriteLine("3) Powrot do wyboru lokalizacji");
            Console.WriteLine("4) Wyjscie z aplikacji");
            switch (Console.ReadLine())
            {
                case 1:
                    Console.WriteLine("Dodano jedzenie do skrytki")
            int GRUNWALD ILOSC + 1;
                    break;
                case 2:
                    Console.WriteLine("Usunieto jedzenie ze skrytki")
            int GRUNWALD ILOSC - 1;
                    break;
                case 3:
                    switch to LokalizacjaMenu();
                    break;
                case 4:
                    public static void Exit();
                    break;
            }
                case 2:
                    Console.WriteLine("W skrytce Nowe Miasto znajduje sie"  Nowe Miasto ILOSC  "miejsc");
                    Console.WriteLine("1) Dodaj produkt do skrytki");
                    Console.WriteLine("2) Usun produkt ze skrytki");
                    Console.WriteLine("3) Powrot do wyboru lokalizacji");
                    Console.WriteLine("4) Wyjscie z aplikacji");
switch (Console.ReadLine())
{
    case 1:
        Console.WriteLine("Dodano jedzenie do skrytki")
                   int Nowe Miasto ILOSC +1;
        break;
    case 2:
        Console.WriteLine("Usunieto jedzenie ze skrytki")
                   int Nowe Miasto ILOSC -1;
        break;
    case 3:
        switch to LokalizacjaMenu();
        break;
    case 4:
        public static void Exit();
        break;
}
                        case 3:
                            Console.WriteLine("W skrytce Jeżyce znajduje sie"  Jeżyce ILOSC  "miejsc");
                            Console.WriteLine("1) Dodaj produkt do skrytki");
                            Console.WriteLine("2) Usun produkt ze skrytki");
                            Console.WriteLine("3) Powrot do wyboru lokalizacji");
                            Console.WriteLine("4) Wyjscie z aplikacji");
switch (Console.ReadLine())
{
    case 1:
        Console.WriteLine("Dodano jedzenie do skrytki")
                           int Jeżyce ILOSC + 1;
        break;
    case 2:
        Console.WriteLine("Usunieto jedzenie ze skrytki")
                           int Jeżyce ILOSC - 1;
        break;
    case 3:
        switch to LokalizacjaMenu();
        break;
    case 4:
        public static void Exit();
        break;
}

                                case 4:
                                    Console.WriteLine("W skrytce Stare Miasto znajduje sie"  Stare Miasto ILOSC  "miejsc");
                                    Console.WriteLine("1) Dodaj produkt do skrytki");
                                    Console.WriteLine("2) Usun produkt ze skrytki");
                                    Console.WriteLine("3) Powrot do wyboru lokalizacji");
                                    Console.WriteLine("4) Wyjscie z aplikacji");
switch (Console.ReadLine())
{
    case 1:
        Console.WriteLine("Dodano jedzenie do skrytki")
                                   int Stare Miasto ILOSC +1;
        break;
    case 2:
        Console.WriteLine("Usunieto jedzenie ze skrytki")
                                   int Stare Miasto ILOSC -1;
        break;
    case 3:
        switch to LokalizacjaMenu();
        break;
    case 4:
        public static void Exit();
        break;
}
                                        case 5:
                                            Console.WriteLine("W skrytce Wilda znajduje sie"  Wilda ILOSC  "miejsc");
                                            Console.WriteLine("1) Dodaj produkt do skrytki");
                                            Console.WriteLine("2) Usun produkt ze skrytki");
                                            Console.WriteLine("3) Powrot do wyboru lokalizacji");
                                            Console.WriteLine("4) Wyjscie z aplikacji");
                                            switch (Console.ReadLine())
                                            {
                                                case 1:
                                                    Console.WriteLine("Dodano jedzenie do skrytki")
                                           int Wilda ILOSC + 1;
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Usunieto jedzenie ze skrytki")
                                           int Wilda ILOSC - 1;
                                                    break;
                                                case 3:
                                                    switch to LokalizacjaMenu();
                                                    break;
                                                case 4":
                                                    public static void Exit();
                                                    break;
                                            }
                                    }
}
