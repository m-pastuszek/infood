using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using InFood.Klasy.Database;
using InFood.Klasy.BusinessLogic;
using InFood.Klasy.Toolbox;

namespace InFood.Klasy
{
    class Skrytka
    {
        private int m_iId;
        private int m_iNumer;
        private bool m_bCzyZajeta;
        private int m_iIdLokalizacji;
        private int m_iIdProduktu;
        private int m_iIdUzytkownika;

        public int ID
        {
            get => m_iId;
            set => m_iId = value;
        }

        public int Numer
        {
            get => m_iNumer;
            set => m_iNumer = value;
        }

        public bool CzyZajeta
        {
            get => m_bCzyZajeta;
            set => m_bCzyZajeta = value;
        }

        public int IdLokalizacji
        {
            get => m_iIdLokalizacji;
            set => m_iIdLokalizacji = value;
        }

        public int? IdProduktu
        {
            get => m_iIdProduktu;
            set
            {
                if (value != null)
                {
                    m_iIdProduktu = (int)value;
                }
            }      
        }

        public int? IdUzytkownika
        {
            get => m_iIdUzytkownika;
            set
            {
                if (value != null)
                {
                    m_iIdProduktu = (int)value;
                }
            }
        }

        public Skrytka()
        {
            
        }

        public static List<Skrytka> DostepneSkrytki(Lokalizacja o_Lokalizacja)
        {
            List<Skrytka> l_Skrytki = GetFreeDepositsInLocalizationFromDatabase(o_Lokalizacja.ID);

            return l_Skrytki;
                    
        }

        public static List<Skrytka> ZajeteSkrytki(Lokalizacja o_Lokalizacja)
        {
            List<Skrytka> l_Skrytki = GetFullDepositsInLocalizationFromDatabase(o_Lokalizacja.ID);

            return l_Skrytki;

        }

        public static Skrytka WybierzSkrytke(Lokalizacja o_Lokalizacja)
        {
            List<Skrytka> l_WolneSkrytkiWLokalizacji = Skrytka.DostepneSkrytki(o_Lokalizacja);

            foreach (Skrytka o_Skrytka in l_WolneSkrytkiWLokalizacji)
            {
                Console.Write($" [ {o_Skrytka.Numer} ] ");
            }
            Console.WriteLine("\n");
            int i_WybranaSkrytka = (int)Fields.PoleLiczbowe("Numer skrytki");

            Skrytka skrytka = l_WolneSkrytkiWLokalizacji.Find(skrytka => skrytka.Numer == i_WybranaSkrytka);
            if (skrytka != null)
                return skrytka;
            else
                return null;

        }

        public static Skrytka WybierzZajetaSkrytke(Lokalizacja o_Lokalizacja)
        {
            List<Skrytka> l_ZajeteSkrytkiWLokalizacji = Skrytka.ZajeteSkrytki(o_Lokalizacja);

            if (l_ZajeteSkrytkiWLokalizacji.Count > 0)
            {
                foreach (Skrytka o_Skrytka in l_ZajeteSkrytkiWLokalizacji)
                {
                    Console.Write($" [ {o_Skrytka.Numer} ] ");
                }

                int i_WybranaSkrytka = (int)Fields.PoleLiczbowe("Numer skrytki");

                Skrytka skrytka = l_ZajeteSkrytkiWLokalizacji.Find(skrytka => skrytka.Numer == i_WybranaSkrytka);

                return skrytka;
            }
            else
            {
                return null;
            }
        }

        public static Produkt ZawartoscSkrytki(Skrytka o_Skrytka)
        {
            string queryString = "SELECT Produkt.ID AS ID, Nazwa, Ilosc, Waga, TerminWaznosci FROM dbo.Skrytka INNER JOIN dbo.Produkt ON dbo.Skrytka.IdProduktu = dbo.Produkt.ID WHERE dbo.Skrytka.ID=@IdSkrytki;"; // zapytanie SQL
            
            var parameters = new Dictionary<string, object>();
            parameters.Add("@IdSkrytki", o_Skrytka.ID);

            DataTable dt = DatabaseOperations.SelectWithParams(queryString, parameters); // zapytanie SQL i zapisanie odpowiedzi do lokalnej tabeli

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0]; // zaznaczenie pierwszego wiersza (w teorii zawsze będzie jeden)

                Produkt o_Produkt = new Produkt()
                {
                    ID = row.Field<int>("ID"),
                    Nazwa = row.Field<string>("Nazwa"),
                    Ilosc = row.Field<int>("Ilosc"),
                    Waga = row.Field<decimal>("Waga"),
                    TerminWaznosci = row.Field<DateTime>("TerminWaznosci")
                };

                return o_Produkt;
            }
            else
                return null;
        }

        public static List<Skrytka> GetFreeDepositsInLocalizationFromDatabase(int i_IdLokalizacji)
        {
            string queryString = "SELECT * FROM dbo.Skrytka INNER JOIN dbo.Lokalizacja ON dbo.Skrytka.IdLokalizacji = dbo.Lokalizacja.ID WHERE IdLokalizacji=@IdLokalizacji AND CzyZajeta=0;"; // zapytanie SQL

            var parameters = new Dictionary<string, object>();
            parameters.Add("@IdLokalizacji", i_IdLokalizacji);

            DataTable dt = DatabaseOperations.SelectWithParams(queryString, parameters); // zapytanie SQL i zapisanie odpowiedzi do lokalnej tabeli

            List<Skrytka> depositsList = new List<Skrytka>(); // utworzenie listy użytkowników

            foreach (DataRow row in dt.Rows) // przejechanie po wierszach
            {
                // dodanie skrytki z bazy do listy
                depositsList.Add(
                    new Skrytka()
                    {
                        ID = row.Field<int>("ID"),
                        Numer = row.Field<int>("Numer"),
                        CzyZajeta = row.Field<bool>("CzyZajeta"),
                        IdLokalizacji = row.Field<int>("IdLokalizacji"),
                        IdProduktu = row.Field<int?>("IdProduktu"),
                        IdUzytkownika = row.Field<int?>("IdUzytkownika")
                    });
            }

            return depositsList;
        }

        public static List<Skrytka> GetFullDepositsInLocalizationFromDatabase(int i_IdLokalizacji)
        {
            string queryString = "SELECT * FROM dbo.Skrytka INNER JOIN dbo.Lokalizacja ON dbo.Skrytka.IdLokalizacji = dbo.Lokalizacja.ID WHERE IdLokalizacji=@IdLokalizacji AND CzyZajeta=1;"; // zapytanie SQL

            var parameters = new Dictionary<string, object>();
            parameters.Add("@IdLokalizacji", i_IdLokalizacji);

            DataTable dt = DatabaseOperations.SelectWithParams(queryString, parameters); // zapytanie SQL i zapisanie odpowiedzi do lokalnej tabeli

            List<Skrytka> depositsList = new List<Skrytka>(); // utworzenie listy użytkowników

            foreach (DataRow row in dt.Rows) // przejechanie po wierszach
            {
                // dodanie skrytki z bazy do listy
                depositsList.Add(
                    new Skrytka()
                    {
                        ID = row.Field<int>("ID"),
                        Numer = row.Field<int>("Numer"),
                        CzyZajeta = row.Field<bool>("CzyZajeta"),
                        IdLokalizacji = row.Field<int>("IdLokalizacji"),
                        IdProduktu = row.Field<int?>("IdProduktu"),
                        IdUzytkownika = row.Field<int?>("IdUzytkownika")
                    });
            }

            return depositsList;
        }
    }
}
