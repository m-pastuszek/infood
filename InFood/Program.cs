using System;
using InFood.Klasy;
using InFood.Klasy.BusinessLogic;
using InFood.Klasy.Toolbox;
using InFood.Klasy.Menu;
using System.Text;

namespace InFood
{
    class Program
    {
        public static string LOGGED_USER_LOGIN;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            EntryMenu();

        }
        // MENU PODCZAS URUCHOMIENIA APLIKACJI
        public static void EntryMenu()
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                             MENU GŁÓWNE                                |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Wybierz opcję:                                                         |");
            Console.WriteLine("|                                                                        |");
            Console.WriteLine("| 1) Zaloguj się                                                         |");
            Console.WriteLine("| 2) Zarejestruj się                                                     |");
            Console.WriteLine("| 3) Wyjście z aplikacji                                                 |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Wybierz opcję i zatwierdź klawiszem ENTER.                             |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.Write("| Wybór: ");

            switch (Console.ReadLine())
            {
                case "1":
                    LoginMenu();
                    break;
                case "2":
                    RegisterMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    HelperClasses.ZlyWybor();
                    EntryMenu();
                    break;
            }
        }

        // MENU LOGOWANIA
        private static void LoginMenu()
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                               LOGOWANIE                                |");
            Console.WriteLine("+------------------------------------------------------------------------+");

            string s_Login = Fields.PoleTekstowe("Podaj login");
            string s_Haslo = Fields.PoleTekstowe("Podaj hasło");

            while (!Uzytkownik.CzyPoprawneDaneLogowania(s_Login, s_Haslo))
            {
                Console.WriteLine("+------------------------------------------------------------------------+");
                Console.WriteLine("| Wprowadzono nieprawidłowe dane logowania. Spróbuj ponownie.            |");
                Console.WriteLine("+------------------------------------------------------------------------+");
                Console.ReadKey();
                LoginMenu();
            }

            if (Uzytkownik.CzyUzytkownikJestAdminem(s_Login))
                AdminUserMenu();
            else
                NormalUserMenu();
        }

        // MENU REJESTRACJI
        private static void RegisterMenu()
        {
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                             REJESTRACJA                                |");
            Console.WriteLine("+------------------------------------------------------------------------+");

            Uzytkownik.DodajUzytkownika();
        }

        // MENU NORMALNEGO UŻYTKOWNIKA (Z ROLĄ 1)
        private static void NormalUserMenu()
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                           MENU UŻYTKOWNIKA                             |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Wybierz opcję:                                                         |");
            Console.WriteLine("|                                                                        |");
            Console.WriteLine("| 1) Wybierz lokalizację                                                 |");
            Console.WriteLine("| 2) Zarzadzaj kontem                                                    |");
            Console.WriteLine("| 3) Wyjście z aplikacji                                                 |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.Write("| Wybór: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Lokalizacja o_WybranaLokalizacja = Lokalizacja.WybierzLokalizacje();

                    if (o_WybranaLokalizacja != null)
                    {
                        GiveOrGetProductMenu(o_WybranaLokalizacja);
                    }
                    break;
                case "2":
                    UserSettings();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    HelperClasses.ZlyWybor();
                    NormalUserMenu();
                    break;
            }
        }

        // MENU ADMINISTRATORA
        private static void AdminUserMenu()
        {
            // TODO
        }

        // MENU AKCJI W WYBRANEJ LOKALIZACJI
        private static void GiveOrGetProductMenu(Lokalizacja o_Lokalizacja)
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine($"LOKALIZACJA: {o_Lokalizacja.Nazwa}");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Wybierz opcję:                                                         |");
            Console.WriteLine("|                                                                        |");
            Console.WriteLine("| 1) Oddaj produkt                                                       |");
            Console.WriteLine("| 2) Odbierz produkt                                                     |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.Write("| Wybór: ");

            switch (Console.ReadLine())
            {
                case "1":
                    GiveProduct(o_Lokalizacja);
                    break;
                case "2":
                    TakeProduct(o_Lokalizacja);
                    break;
                default:
                    HelperClasses.ZlyWybor();
                    GiveOrGetProductMenu(o_Lokalizacja);
                    break;
            }
        }

        // WYBÓR WOLNEJ SKRYTKI W LOKALIZACJI
        private static void GiveProduct(Lokalizacja o_Lokalizacja)
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine($"LOKALIZACJA: {o_Lokalizacja.Nazwa}");
            Console.WriteLine("---> WYBÓR SKRTYKI");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Wybierz skrytkę, w której chcesz umieścić produkt.                     |");
            Console.WriteLine("+------------------------------------------------------------------------+");


            Skrytka o_Skrytka = Skrytka.WybierzSkrytke(o_Lokalizacja);

            if (o_Skrytka == null)
            {
                Console.WriteLine("+------------------------------------------------------------------------+");
                Console.WriteLine("| Wybrano błędną skrytkę. Spróbuj ponownie.                              |");
                Console.WriteLine("+------------------------------------------------------------------------+");
                HelperClasses.PressEnterToContinue();
                GiveProduct(o_Lokalizacja);
            }

            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine($"LOKALIZACJA: {o_Lokalizacja.Nazwa}");
            Console.WriteLine("---> WYBÓR SKRTYKI");
            Console.WriteLine("------> DODAWANIE PRODUKTU");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Wprowadź informacje o umieszczanym produkcie.                          |");
            Console.WriteLine("+------------------------------------------------------------------------+");

            Produkt.DodajProduktDoSkrytki(o_Skrytka);

            HelperClasses.PressEnterToContinue();
            NormalUserMenu();
        }

        private static void TakeProduct(Lokalizacja o_Lokalizacja)
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine($"LOKALIZACJA: {o_Lokalizacja.Nazwa}");
            Console.WriteLine("---> WYBÓR SKRTYKI");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Wybierz skrytkę z której chcesz wyciągnąć produkt.                     |");
            Console.WriteLine("+------------------------------------------------------------------------+");

            Skrytka o_Skrytka = Skrytka.WybierzZajetaSkrytke(o_Lokalizacja);

            if (o_Skrytka == null)
            {
                Console.WriteLine();
                Console.WriteLine("+------------------------------------------------------------------------+");
                Console.WriteLine("| BRAK SKRYTEK DO WYBORU.                                                |");
                Console.WriteLine("+------------------------------------------------------------------------+");

                HelperClasses.PressEnterToContinue();
                NormalUserMenu();
            }

            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine($"LOKALIZACJA: {o_Lokalizacja.Nazwa}");
            Console.WriteLine("---> WYBÓR SKRTYKI");
            Console.WriteLine("------> PRODUKT");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Informacje o produkcie.                                                |");
            Console.WriteLine("+------------------------------------------------------------------------+");

            Produkt o_Produkt = Skrytka.ZawartoscSkrytki(o_Skrytka);
            Console.WriteLine($"| Nazwa: {o_Produkt.Nazwa}");
            Console.WriteLine($"| Ilość: {o_Produkt.Ilosc}");
            Console.WriteLine($"| Waga: {o_Produkt.Waga}");
            Console.WriteLine($"| Termin ważności: {o_Produkt.TerminWaznosci}");

            Console.Write("| Czy chcesz wyjąć ten produkt? (T/N): ");

            switch (Console.ReadLine())
            {
                case "T":
                    break;
                case "N":
                    TakeProduct(o_Lokalizacja);
                    break;
            }

            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine($"LOKALIZACJA: {o_Lokalizacja.Nazwa}");
            Console.WriteLine("---> WYBÓR SKRTYKI");
            Console.WriteLine("------> WYCIĄGANIE PRODUKTU");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Potwierdź wyjęcie produktu.                                            |");
            Console.WriteLine("+------------------------------------------------------------------------+");

            Produkt.UsunProduktZeSkrytki(o_Skrytka);

            HelperClasses.PressEnterToContinue();
            NormalUserMenu();
        }

        // USTAWIENIA KONTA UŻYTKOWNIKA
        private static void UserSettings()
        {
            Console.Clear();
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                      ## InFood - jedzeniomaty ##                       |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("|                           USTAWIENIA KONTA                             |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| 1) Zmiana danych konta                                                 |");
            Console.WriteLine("| 2) Powrót do menu użytkownika                                          |");
            Console.WriteLine("| 3) Wyjście z aplikacji                                                 |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.Write("| Wybór: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Uzytkownik.ModyfikujUzytkownika(LOGGED_USER_LOGIN);
                    break;
                case "2":
                    NormalUserMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    HelperClasses.ZlyWybor();
                    UserSettings();
                    break;
            }
        }
    }
}