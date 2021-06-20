using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using InFood.Klasy.Database;
using InFood.Klasy.Toolbox;

namespace InFood.Klasy.BusinessLogic
{
    class Rola
    {
        private int m_iId;
        private string m_sNazwa;

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

        public Rola()
        {
            
        }

        public static void DodajRole()
        {
            string s_Nazwa = Fields.PoleTekstowe("Nazwa roli");

            AddRoleToDatabase(s_Nazwa);
        }
        public static void UsunLokalizacje(int ID)
        {
            Console.Write("Czy na pewno chcesz usunąć tą lokalizację? (T/N): ");

            switch (Console.ReadLine())
            {
                case "T":
                    DeleteRoleFromDatabase(ID);
                    break;

                case "N":
                    break;
            }
        }

        /*
         * Pobranie listy wszystkich roli z bazy
         */
        public static void GetRolesFromDatabase()
        {
            string queryString = "SELECT * FROM dbo.Rola;";

            DataTable dt = DatabaseOperations.Select(queryString);

            List<Rola> rolesList = new List<Rola>();

            foreach (DataRow row in dt.Rows)
            {
                rolesList.Add(
                    new Rola()
                    {
                        ID = row.Field<int>("ID"),
                        Nazwa = row.Field<string>("Nazwa")
                    });
            }
        }

        /*
         * Pobranie danych o roli z bazy danych
         * @Param: int ID
         */
        public static void GetRoleFromDatabase(int ID)
        {
            string queryString = "SELECT * FROM dbo.Rola WHERE ID = @ID;";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@ID", ID);

            DataTable dt = DatabaseOperations.SelectWithParams(queryString, parameters);

            List<Rola> rolesList = new List<Rola>();

            foreach (DataRow row in dt.Rows)
            {
                rolesList.Add(
                    new Rola()
                    {
                        ID = row.Field<int>("ID"),
                        Nazwa = row.Field<string>("Nazwa")
                    });
            }
        }

        /*
         * Dodanie roli do bazy danych
         */
        public static void AddRoleToDatabase(string Nazwa)
        {
            string queryString = "INSERT INTO dbo.Rola (Nazwa) VALUES (@Nazwa);";

            var parameters = new Dictionary<string, object>();

            parameters.Add("@Nazwa", Nazwa);

            DatabaseOperations.Insert(queryString, parameters);
        }

        /*
         * Usunięcie roli z bazy danych
         */
        public static void DeleteRoleFromDatabase(int ID)
        {
            string queryString = "DELETE FROM dbo.Rola WHERE ID=@ID";

            var parameters = new Dictionary<string, object>();

            parameters.Add("@ID", ID);

            DatabaseOperations.Delete(queryString, parameters);
        }
    }
}
