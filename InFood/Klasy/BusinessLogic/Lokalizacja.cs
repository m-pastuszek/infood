using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using InFood.Klasy.Database;
using InFood.Klasy.Toolbox;

namespace InFood.Klasy.BusinessLogic
{
    class Lokalizacja
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

        public Lokalizacja()
        {

        }

        public static void DodajLokalizacje()
        {
            string s_Nazwa = Fields.PoleTekstowe("Nazwa lokalizacji");

            AddLocalizationToDatabase(s_Nazwa);
        }
        public static void UsunLokalizacje(int ID)
        {
            Console.Write("Czy na pewno chcesz usunąć tą lokalizację? (T/N): ");

            switch (Console.ReadLine())
            {
                case "T":
                    DeleteLocalizationFromDatabase(ID);
                    break;

                case "N":
                    break;
            }
        }

        public static Lokalizacja WybierzLokalizacje()
        {
            List<Lokalizacja> l_Lokalizacje = GetLocalizationsFromDatabase();
            Console.Clear();
            Console.WriteLine("Lokalizacje do wyboru: ");
            
            foreach (Lokalizacja o_Lokalizacja in l_Lokalizacje)
            {
                Console.WriteLine($"{o_Lokalizacja.ID}) {o_Lokalizacja.Nazwa}");
            }

            int i_WybranaLokalizacja = (int)Fields.PoleLiczbowe("Wprowadź numer, który wybierasz");

            return GetLocalizationFromDatabase(i_WybranaLokalizacja);
        }

        /*
         * Pobranie listy wszystkich lokalizacji z bazy
         */
        private static List<Lokalizacja> GetLocalizationsFromDatabase()
        {
            string queryString = "SELECT * FROM dbo.Lokalizacja;";

            DataTable dt = DatabaseOperations.Select(queryString);

            List<Lokalizacja> localizationsList = new List<Lokalizacja>();

            foreach (DataRow row in dt.Rows)
            {
                localizationsList.Add(
                    new Lokalizacja()
                    {
                        ID = row.Field<int>("ID"),
                        Nazwa = row.Field<string>("Nazwa")
                    });
            }

            return localizationsList;
        }

        /*
         * Pobranie danych o lokalizacji z bazy danych
         * @Param: int ID
         */
        private static Lokalizacja GetLocalizationFromDatabase(int ID)
        {
            string queryString = "SELECT * FROM dbo.Lokalizacja WHERE ID = @ID;";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@ID", ID);

            DataTable dt = DatabaseOperations.SelectWithParams(queryString, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0]; // zaznaczenie pierwszego wiersza (w teorii zawsze będzie jeden)

                Lokalizacja o_Lokalizacja = new Lokalizacja()
                {
                    ID = row.Field<int>("ID"),
                    Nazwa = row.Field<string>("Nazwa")
                };

                return o_Lokalizacja;
            }

            else
            {
                return null;
            }
        }

        /*
         * Dodanie lokalizacji do bazy danych
         */
        public static void AddLocalizationToDatabase(string Nazwa)
        {
            string queryString = "INSERT INTO dbo.Lokalizacja (Nazwa) VALUES (@Nazwa);";

            var parameters = new Dictionary<string, object>();

            parameters.Add("@Nazwa", Nazwa);

            DatabaseOperations.Insert(queryString, parameters);   
        }

        /*
         * Usunięcie lokalizacji z bazy danych
         */
        public static void DeleteLocalizationFromDatabase(int ID)
        {
            string queryString = "DELETE FROM dbo.Lokalizacja WHERE ID=@ID";

            var parameters = new Dictionary<string, object>();

            parameters.Add("@ID", ID);

            DatabaseOperations.Delete(queryString, parameters);
        }
    }
}
