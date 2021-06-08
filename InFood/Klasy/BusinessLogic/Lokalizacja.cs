using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InFood.Klasy.BusinessLogic
{
    [DataContract]
    class Lokalizacja
    {
        private int m_iId;
        private string m_sNazwa;

        [DataMember]
        public int ID
        {
            get => m_iId;
            set => m_iId = value;
        }

        [DataMember]
        public string Nazwa
        {
            get => m_sNazwa;
            set => m_sNazwa = value;
        }
        public Lokalizacja()
            {

            }
    }
}
