using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InFood.Classes
{
    public class Użytkownik
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

        public void Uzytkownik()
        {

        }

        public void DodajUzytkownika(string Login, string Haslo, int Rola)
        {
            this.Login = m_sLogin;
            this.Haslo = m_sHaslo;
            this.IdRoli = m_iIdRoli;
        }

        public void ModyfikujUzytkownika(int ID)
        {
            
        }

        public void UsunUzytkownika(int ID)
        {

        }

        public void Rola(int ID)
        {
            int IdUzytkownika = this.ID;


        }


    }
}
