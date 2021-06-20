using System;
using System.Collections.Generic;
using System.Data;
using InFood.Klasy.Database;
using InFood.Klasy.Toolbox;
using InFood.Klasy.Menu;

namespace InFood.Klasy.BusinessLogic
{
    public class Uzytkownik
    {
        private int m_iId;
        private string m_sLogin;
        private string m_sHaslo;
        private int m_iIdRoli;

        public int ID
        {
            get => m_iId;
            set => m_iId = value;
        }

        public string Login
        {
            get => m_sLogin;
            set => m_sLogin = value;
        }

        public string Haslo
        {
            get => m_sHaslo;
            set => m_sHaslo = value;
        }

        public int IdRoli
        {
            get => m_iIdRoli;
            set => m_iIdRoli = value;
        }

        public Uzytkownik()
        {

        }

        public override string ToString()
        {
            return $"[Login={Login}|Password={Haslo}|Rola={IdRoli}]";
        }

        public static void DodajUzytkownika()
        {
            string s_Login = Fields.PoleTekstowe("Podaj login");
            string s_Haslo = Fields.PoleTekstowe("Podaj hasło");

            int i_IdRoli = 1;

            AddUserToDatabase(s_Login, s_Haslo, i_IdRoli);

            if(DatabaseOperations.LAST_INSERTED_ID != null)
            {
                Console.WriteLine("Konto zostało pomyslnie utworzone. Możesz się zalogować.");
                HelperClasses.PressEnterToContinue();
                Program.EntryMenu();
            }
        }

        public static void ModyfikujUzytkownika(string Login)
        {
            Dictionary<string, object> changedData = new Dictionary<string, object>();
            string s_NowyLogin, s_NoweHaslo;

            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.WriteLine("| Co chcesz edytować?                                                    |");
            Console.WriteLine("|                                                                        |");
            Console.WriteLine("| 1) Login użytkownika                                                   |");
            Console.WriteLine("| 2) Hasło użytkownika                                                   |");
            Console.WriteLine("| 3) Login i hasło użytkownika                                           |");
            Console.WriteLine("+------------------------------------------------------------------------+");
            Console.Write("| Wybór: ");

            switch (Console.ReadLine())
            {
                case "1":
                    s_NowyLogin = Fields.PoleTekstowe("Podaj nowy login");
                    changedData.Add("@LoginChanged", s_NowyLogin);

                    UpdateUserInDatabase(Login, 1, changedData);
                    break;

                case "2":
                    s_NoweHaslo = Fields.PoleTekstowe("Podaj nowe hasło");
                    changedData.Add("@HasloChanged", s_NoweHaslo);

                    UpdateUserInDatabase(Login, 2, changedData);
                    break;

                case "3":
                    s_NowyLogin = Fields.PoleTekstowe("Podaj nowy login");
                    s_NoweHaslo = Fields.PoleTekstowe("Podaj nowe hasło");

                    changedData.Add("@LoginChanged", s_NowyLogin);
                    changedData.Add("@HasloChanged", s_NoweHaslo);

                    UpdateUserInDatabase(Login, 3, changedData);
                    break;
                default:
                    ModyfikujUzytkownika(Login);
                    break;
            }
        }

        public static void UsunUzytkownika(string Login)
        {
            Console.Write("Czy na pewno chcesz usunąć konto użytkownika? (T/N): ");

            switch (Console.ReadLine())
            {
                case "T":
                    DeleteUserFromDatabase(Login);
                    break;

                case "N":
                    break;
            }
        }

        public static bool CzyPoprawneDaneLogowania(string s_Login, string s_Haslo)
        {
            Uzytkownik o_Uzytkownik = GetUserFromDatabase(s_Login);

            if (o_Uzytkownik != null && o_Uzytkownik.Login == s_Login && o_Uzytkownik.Haslo == s_Haslo)
            {
                InFood.Program.LOGGED_USER_LOGIN = s_Login;
                return true;
            }
            else
                return false;
        }

        public static int IdUzytkownikaOPodanymLoginie(string s_Login)
        {
            Uzytkownik o_Uzytkownik = GetUserFromDatabase(s_Login);

            return o_Uzytkownik.ID;
        }

        public static bool CzyUzytkownikJestAdminem(string s_Login)
        {
            Uzytkownik o_Uzytkownik = GetUserFromDatabase(s_Login);

            if (o_Uzytkownik.IdRoli == 2)
                return true;
            else
                return false;
        }

        /*
         * Pobranie listy wszystkich użytkowników z bazy
         */
        private static List<Uzytkownik> GetUsersFromDatabase()
        {
            string queryString = "SELECT * FROM dbo.Uzytkownik;"; // zapytanie SQL

            DataTable dt = DatabaseOperations.Select(queryString); // zapytanie SQL i zapisanie odpowiedzi do lokalnej tabeli

            List<Uzytkownik> usersList = new List<Uzytkownik>(); // utworzenie listy użytkowników

            foreach (DataRow row in dt.Rows) // przejechanie po wierszach
            {
                // dodanie użytkownika z bazy do listy
                usersList.Add(
                    new Uzytkownik()
                    {
                        ID = row.Field<int>("ID"),
                        Login = row.Field<string>("Login"),
                        Haslo = row.Field<string>("Haslo"),
                        IdRoli = row.Field<int>("IdRoli")
                    });
            }

            return usersList;
        }

        /*
         * Pobranie danych o użytkowniku z bazy danych
         * @Param: string Login - login użytkownika
         */
        private static Uzytkownik GetUserFromDatabase(string Login)
        {
            string queryString = "SELECT * FROM dbo.Uzytkownik WHERE Login = @Login;"; // zapytanie SQL

            var parameters = new Dictionary<string, object>();
            parameters.Add("@Login", Login);

            DataTable dt = DatabaseOperations.SelectWithParams(queryString, parameters); // zapytanie SQL i zapisanie odpowiedzi do lokalnej tabeli

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0]; // zaznaczenie pierwszego wiersza (w teorii zawsze będzie jeden)

                Uzytkownik o_Uzytkownik = new Uzytkownik()
                {
                    ID = row.Field<int>("ID"),
                    Login = row.Field<string>("Login"),
                    Haslo = row.Field<string>("Haslo"),
                    IdRoli = row.Field<int>("IdRoli")
                };

                return o_Uzytkownik;
            }
            else
                return null;
        }

        /*
         * Dodanie użytkownika do bazy danych
         */
        public static void AddUserToDatabase(string Login, string Haslo, int IdRoli)
        {
            string queryString = "INSERT INTO dbo.Uzytkownik (Login, Haslo, IdRoli) VALUES (@Login,@Haslo,@IdRoli);"; // zapytanie SQL

            var parameters = new Dictionary<string, object>();

            parameters.Add("@Login", Login);
            parameters.Add("@Haslo", Haslo);
            parameters.Add("@IdRoli", IdRoli);

            DatabaseOperations.Insert(queryString, parameters); // wykonanie polecenia SQL        
        }

        /*
         * Usunięcie użytkownika z bazy danych
         */
        public static void DeleteUserFromDatabase(string Login)
        {
            string queryString = "DELETE FROM dbo.Uzytkownik WHERE Login=@Login"; // zapytanie SQL
            
            var parameters = new Dictionary<string, object>();

            parameters.Add("@Login", Login);

            DatabaseOperations.Delete(queryString, parameters); // wykonanie polecenia SQL
        }

        /*
         * Update użytkownika w bazie
         * 
         * Parametry:
         * Login - login użytkownika, którego dotyczy zmiana
         * Case - tryb zmiany (1 - tylko login, 2 - tylko hasło, 3 - obie rzeczy)
         * editedParams - aktualizowane zmiany
         */

        public static void UpdateUserInDatabase(string Login, int Case, Dictionary<string, object> editedParams)
        {
            string queryString;

            var parameters = new Dictionary<string, object>();

            parameters.Add("@Login", Login);
            
            foreach(KeyValuePair<string,object> param in editedParams)
            {
                if(Case == 1)
                {
                    queryString = "UPDATE dbo.Uzytkownik SET Login = @LoginChanged WHERE Login = @Login;"; // zapytanie SQL
                    parameters.Add("@LoginChanged", editedParams["@LoginChanged"]);

                    DatabaseOperations.Update(queryString, parameters);
                }
                if (Case == 2)
                {
                    queryString = "UPDATE dbo.Uzytkownik SET Haslo = @HasloChanged WHERE Login = @Login;"; // zapytanie SQL
                    parameters.Add("@HasloChanged", editedParams["@HasloChanged"]);

                    DatabaseOperations.Update(queryString, parameters);
                }
                if (Case == 3)
                {
                    queryString = "UPDATE dbo.Uzytkownik SET Login = @LoginChanged, Haslo = @HasloChanged WHERE Login = @Login;"; // zapytanie SQL
                    parameters.Add("@LoginChanged", editedParams["@LoginChanged"]);
                    parameters.Add("@HasloChanged", editedParams["@HasloChanged"]);

                    DatabaseOperations.Update(queryString, parameters);
                }
            }     
        }
    }
}
