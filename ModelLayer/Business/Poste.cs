using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Business
{
    public class Poste
    {

        private int id;
        private string nom;
        private int escouade;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Escouade { get => escouade; set => escouade = value; }

        public Poste(int id = 0, string nom="", int escouade=0 )
        {
            Id = id;
            Nom = nom;
            Escouade = escouade;
        }

        public Poste()
        {

        }
    }
}
