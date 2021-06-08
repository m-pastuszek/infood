using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using InFood.Klasy;

namespace InFood.Klasy.BusinessLogic
{
    [DataContract]
    public class Uzytkownik : FileXmlStorage<Uzytkownik>
    {
        private int m_iId;
        private string m_sLogin;
        private string m_sHaslo;
        private int m_iIdRoli;

        [DataMember]
        public int Id
        {
            get => m_iId;
            set => m_iId = value;
        }

        [DataMember]
        public string Login
        {
            get => m_sLogin;
            set => m_sLogin = value;
        }

        [DataMember]
        public string Haslo
        {
            get => m_sHaslo;
            set => m_sHaslo = value;
        }

        [DataMember]
        public int IdRoli
        {
            get => m_iIdRoli;
            set => m_iIdRoli = value;
        }

        public static void DodajUzytkownika(string Login, string Haslo, int Rola)
        {
            Uzytkownik _oUzytkownik = new Uzytkownik
            {
                Login = Login,
                Haslo = Haslo,
                IdRoli = Rola
            };

            try
            {
                _oUzytkownik.ExportToFile("users.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void ModyfikujUzytkownika(int Id)
        {
            
        }

        public void UsunUzytkownika(int Id)
        {

        }

        public void Rola(int Id)
        {
            int IdUzytkownika = this.Id;


        }

        public override string ToString()
        {
            return $"[Login={Login}|Password={Haslo}|Rola={IdRoli}]";
        }


    }
}
