using System;
using System.Collections.Generic;
using System.Data;
using InFood.Klasy.Database;

namespace InFood.Klasy.BusinessLogic
{
    public class Uzytkownik
    {
        private int m_iId;
        private string m_sLogin;
        private string m_sHaslo;
        private int m_iIdRoli;

        public int Id
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

        public static void DodajUzytkownika()
        {
            Console.WriteLine("Podaj login: ");
            string s_Login = Console.ReadLine();

            Console.WriteLine("Podaj hasło: ");
            string s_Haslo = Console.ReadLine();

            int i_IdRoli = 1;

            AddUserToDatabase(s_Login, s_Haslo, i_IdRoli);
        }

        public void ModyfikujUzytkownika(string Login)
        {
            Dictionary<string, object> changedData = new Dictionary<string, object>();
            string s_NowyLogin, s_NoweHaslo;

            Console.WriteLine("Co chcesz edytować?");
            Console.WriteLine();
            Console.WriteLine("1) Login użytkownika");
            Console.WriteLine("2) Hasło użytkownika");
            Console.WriteLine("3) Login i hasło użytkownika");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Wprowadź nowy login: ");
                    s_NowyLogin = Console.ReadLine();
                    changedData.Add("@LoginChanged", s_NowyLogin);

                    UpdateUserInDatabase(Login, 1, changedData);
                    break;

                case "2":
                    Console.WriteLine("Wprowadź nowe hasło: ");
                    s_NoweHaslo = Console.ReadLine();
                    changedData.Add("@HasloChanged", s_NoweHaslo);

                    UpdateUserInDatabase(Login, 2, changedData);
                    break;

                case "3":
                    Console.WriteLine("Wprowadź nowy login: ");
                    s_NowyLogin = Console.ReadLine();
                    changedData.Add("@LoginChanged", s_NowyLogin);

                    Console.WriteLine("Wprowadź nowe hasło: ");
                    s_NoweHaslo = Console.ReadLine();
                    changedData.Add("@HasloChanged", s_NoweHaslo);

                    UpdateUserInDatabase(Login, 3, changedData);
                    break;
            }
        }

        public void UsunUzytkownika(string Login)
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

        public override string ToString()
        {
            return $"[Login={Login}|Password={Haslo}|Rola={IdRoli}]";
        }

        /*
         * Pobranie listy wszystkich użytkowników z bazy
         */
        public static void GetUsersFromDatabase()
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
                        Id = row.Field<int>("ID"),
                        Login = row.Field<string>("Login"),
                        Haslo = row.Field<string>("Haslo"),
                        IdRoli = row.Field<int>("IdRoli")
                    });
            }
        }

        /*
         * Pobranie danych o użytkowniku z bazy danych
         * @Param: string Login - login użytkownika
         */
        public static void GetUserFromDatabase(string Login)
        {
            string queryString = "SELECT * FROM dbo.Uzytkownik WHERE Login = @Login;"; // zapytanie SQL

            var parameters = new Dictionary<string, string>();
            parameters.Add("@Login", Login);

            DataTable dt = DatabaseOperations.SelectWithParams(queryString, parameters); // zapytanie SQL i zapisanie odpowiedzi do lokalnej tabeli

            List<Uzytkownik> usersList = new List<Uzytkownik>(); // utworzenie listy użytkowników

            foreach (DataRow row in dt.Rows) // przejechanie po wierszach
            {
                // dodanie użytkownika z bazy do listy
                usersList.Add(
                    new Uzytkownik()
                    {
                        Id = row.Field<int>("ID"),
                        Login = row.Field<string>("Login"),
                        Haslo = row.Field<string>("Haslo"),
                        IdRoli = row.Field<int>("IdRoli")
                    });
            }
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

                    DatabaseOperations.Insert(queryString, parameters);
                }
                if (Case == 2)
                {
                    queryString = "UPDATE dbo.Uzytkownik SET Haslo = @HasloChanged WHERE Login = @Login;"; // zapytanie SQL
                    parameters.Add("@HasloChanged", editedParams["@HasloChanged"]);

                    DatabaseOperations.Insert(queryString, parameters);
                }
                if (Case == 3)
                {
                    queryString = "UPDATE dbo.Uzytkownik SET Login = @LoginChanged, Haslo = @HasloChanged WHERE Login = @Login;"; // zapytanie SQL
                    parameters.Add("@LoginChanged", editedParams["@LoginChanged"]);
                    parameters.Add("@HasloChanged", editedParams["@HasloChanged"]);

                    DatabaseOperations.Insert(queryString, parameters);
                }
            }     
        }
    }
}
