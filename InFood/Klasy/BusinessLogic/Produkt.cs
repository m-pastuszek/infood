using System;
using System.Collections.Generic;
using System.Data;
using InFood.Klasy.Database;

namespace InFood.Klasy.BusinessLogic
{
    class Produkt
    {
        private int m_iId;
        private string m_sNazwa;
        private int m_iIlosc;
        private float m_fWaga;
        private DateTime m_dtTerminWaznosci;
       
        public int ID
        {
            get => m_iId;
            set => m_iId = value;
        }

        public string Nazwa
        {
            get => m_sNazwa;
            set => m_sNazwa = value;
        }

        public int Ilosc
        {
            get => m_iIlosc;
            set => m_iIlosc = value;
        }

        public float Waga
        {
            get => m_fWaga;
            set => m_fWaga = value;
        }

        public DateTime TerminWaznosci
        {
            get => m_dtTerminWaznosci;
            set => m_dtTerminWaznosci = value;
        }

        public Produkt()
        {
            
        }

        /*
         * Pobranie listy wszystkich produktów z bazy
         */
        public static void GetProductsFromDatabase()
        {
            string queryString = "SELECT * FROM dbo.Produkt;"; // zapytanie SQL

            DataTable dt = DatabaseOperations.Select(queryString); // zapytanie SQL i zapisanie odpowiedzi do lokalnej tabeli

            List<Produkt> productsList = new List<Produkt>(); // utworzenie listy produktów

            foreach (DataRow row in dt.Rows) // przejechanie po wierszach
            {
                // dodanie użytkownika z bazy do listy
                productsList.Add(
                    new Produkt()
                    {
                        ID = row.Field<int>("ID"),
                        Nazwa = row.Field<string>("Nazwa"),
                        Ilosc = row.Field<int>("Ilosc"),
                        Waga = row.Field<float>("Waga"),
                        TerminWaznosci = row.Field<DateTime>("TerminWaznosci")
                    });
            }
        }

        // TODO: PRODUKT NIESKOŃCZONY...

        /*
         * Pobranie danych o użytkowniku z bazy danych
         * @Param: string Login - login użytkownika
         */
        public static void GetProductFromDatabase(string ID)
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

            foreach (KeyValuePair<string, object> param in editedParams)
            {
                if (Case == 1)
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
