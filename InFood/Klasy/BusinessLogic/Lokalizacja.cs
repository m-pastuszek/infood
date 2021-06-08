using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InFood.Klasy.BusinessLogic
{
   public class Lokalizacja
    {
        private int m_iId;
        private string m_sNazwa;
        private int m_iIlosc;
        private float m_fWaga;
        private date m_dTerminWaznosci;
        
        public int ID
        {
            get => m_iId;
            set => m_iId = value;
        }
        public int Nazwa
        {
            get => m_sNazwa;
            set => m_sNazwa = value;
        }
        public int Ilosc
        {
            get => m_iIlosc;
            set => m_iIlosc = value;
        }
        public int Waga
        {
            get => m_fWaga;
            set => m_fWaga = value;
        }
        public int ID
        {
            get => m_iId;
            set => m_iId = value;
        }
    }
}
