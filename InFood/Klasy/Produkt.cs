using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InFood.Classes
{
    class Produkt
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
    }
}
