using System;
using System.Collections.Generic;
using System.Data;
using InFood.Klasy.Database;
using InFood.Klasy.Toolbox;

namespace InFood.Klasy.BusinessLogic
{
    class Produkt
    {
        private int m_iId;
        private string m_sNazwa;
        private int m_iIlosc;
        private decimal m_dWaga;
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

        public decimal Waga
        {
            get => m_dWaga;
            set => m_dWaga = value;
        }

        public DateTime TerminWaznosci
        {
            get => m_dtTerminWaznosci;
            set => m_dtTerminWaznosci = value;
        }

        public Produkt()
        {
            
        }

        public static void DodajProduktDoSkrytki(Skrytka o_Skrytka)
        {
            int? productId = DodajProdukt();
            int userId = Uzytkownik.IdUzytkownikaOPodanymLoginie(InFood.Program.LOGGED_USER_LOGIN);

            string queryString = "UPDATE dbo.Skrytka SET IdProduktu = @IdProduktu, IdUzytkownika = @IdUzytkownika, CzyZajeta = 1 WHERE ID = @ID;";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@IdProduktu", productId);
            parameters.Add("@IdUzytkownika", userId);
            parameters.Add("@ID", o_Skrytka.ID);

            DatabaseOperations.Update(queryString, parameters);
        }

        public static void UsunProduktZeSkrytki(Skrytka o_Skrytka)
        {
            UsunProdukt(o_Skrytka.IdProduktu);

            string queryString = "UPDATE dbo.Skrytka SET IdProduktu = NULL, IdUzytkownika = NULL, CzyZajeta = 0 WHERE ID = @IdSkrytki";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@IdSkrytki", o_Skrytka.ID);

            DatabaseOperations.Update(queryString, parameters);
        }

        public static int? DodajProdukt()
        {
            string s_Nazwa = Fields.PoleTekstowe("Nazwa produktu");
            int i_Ilosc = (int)Fields.PoleLiczbowe("Ilość sztuk produktu");
            decimal d_Waga = (decimal)Fields.PoleWaga("Waga sztuki produktu");

            string s_TerminWaznosci = WprowadzDateWaznosci();

            DateTime dt_TerminWaznosci;

            while(!DateTime.TryParse(s_TerminWaznosci, out dt_TerminWaznosci))
            {
                Console.WriteLine("Wprowadzono nieprawidłową datę ważności. Spróbuj jeszcze raz.");
                s_TerminWaznosci = WprowadzDateWaznosci();

            }

            AddProductToDatabase(s_Nazwa, i_Ilosc, d_Waga, dt_TerminWaznosci);

            return DatabaseOperations.LAST_INSERTED_ID;
        }

        public static void UsunProdukt(int? ID)
        {
            Console.Write("Czy na pewno chcesz wyjąć ten produkt? (T/N): ");

            switch (Console.ReadLine())
            {
                case "T":
                    DeleteProductFromDatabase(ID);
                    break;

                case "N":
                    break;
            }
        }

        private static string WprowadzDateWaznosci()
        {
            Console.WriteLine("| Termin ważności produktu: ");

            int i_Dzien = (int)Fields.PoleLiczbowe(" -> Dzień");
            int i_Miesiac = (int)Fields.PoleLiczbowe(" -> Miesiąc");
            int i_Rok = (int)Fields.PoleLiczbowe(" -> Rok");

            string s_TerminWaznosci = $"{i_Rok}-{i_Miesiac}-{i_Dzien}";

            return s_TerminWaznosci;
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
                // dodanie produktu z bazy do listy
                productsList.Add(
                    new Produkt()
                    {
                        ID = row.Field<int>("ID"),
                        Nazwa = row.Field<string>("Nazwa"),
                        Ilosc = row.Field<int>("Ilosc"),
                        Waga = row.Field<decimal>("Waga"),
                        TerminWaznosci = row.Field<DateTime>("TerminWaznosci")
                    });
            }
        }

        /*
         * Pobranie danych o użytkowniku z bazy danych
         * @Param: string Login - login użytkownika
         */
        public static void GetProductFromDatabase(string ID)
        {
            string queryString = "SELECT * FROM dbo.Produkt WHERE ID = @ID;"; // zapytanie SQL

            var parameters = new Dictionary<string, object>();
            parameters.Add("@ID", ID);

            DataTable dt = DatabaseOperations.SelectWithParams(queryString, parameters); // zapytanie SQL i zapisanie odpowiedzi do lokalnej tabeli

            List<Produkt> productsList = new List<Produkt>(); // utworzenie listy produktów

            foreach (DataRow row in dt.Rows) // przejechanie po wierszach
            {
                // dodanie produktu z bazy do listy
                productsList.Add(
                    new Produkt()
                    {
                        ID = row.Field<int>("ID"),
                        Nazwa = row.Field<string>("Nazwa"),
                        Ilosc = row.Field<int>("Ilosc"),
                        Waga = row.Field<decimal>("Waga"),
                        TerminWaznosci = row.Field<DateTime>("TerminWaznosci")
                    });
            }
        }

        /*
         * Dodanie produktu do bazy danych
         */
        public static void AddProductToDatabase(string Nazwa, int Ilosc, decimal Waga, DateTime TerminWaznosci)
        {
            string queryString = "INSERT INTO dbo.Produkt (Nazwa, Ilosc, Waga, TerminWaznosci) VALUES (@Nazwa,@Ilosc,@Waga,@TerminWaznosci);"; // zapytanie SQL

            var parameters = new Dictionary<string, object>();

            parameters.Add("@Nazwa", Nazwa);
            parameters.Add("@Ilosc", Ilosc);
            parameters.Add("@Waga", Waga);
            parameters.Add("@TerminWaznosci", TerminWaznosci);

            DatabaseOperations.Insert(queryString, parameters); // wykonanie polecenia SQL i zwrócienie jego ID

            int? i_IdDodanegoProduktu = DatabaseOperations.LAST_INSERTED_ID; // wykonanie polecenia SQL

            Console.WriteLine($"ID dodanego produktu: {i_IdDodanegoProduktu}");
        }

        /*
         * Usunięcie produktu z bazy danych
         */
        public static void DeleteProductFromDatabase(int? ID)
        {
            string queryString = "DELETE FROM dbo.Produkt WHERE ID=@ID"; // zapytanie SQL

            var parameters = new Dictionary<string, object>();

            parameters.Add("@ID", ID);

            DatabaseOperations.Delete(queryString, parameters); // wykonanie polecenia SQL
        }
    }
}
