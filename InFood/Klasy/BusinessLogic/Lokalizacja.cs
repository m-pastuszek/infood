﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
