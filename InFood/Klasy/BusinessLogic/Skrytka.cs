using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int IdProduktu
        {
            get => m_iIdProduktu;
            set => m_iIdProduktu = value;
        }

        public int IdUzytkownika
        {
            get => m_iIdUzytkownika;
            set => m_iIdUzytkownika = value;
        }

        public Skrytka()
        {
            
        }

        public void DodajProdukt()
        {

        }

        public void UsunProdukt()
        {

        }

        public void OdbierzProdukt()
        {

        }

        public void WymienProdukt()
        {
            
        }
    }
}
