using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Business
{
    public class Pays
    {
        private string nom;
        private int id;

        public string Nom { get => nom; set => nom = value; }
        public int Id { get => id; set => id = value; }

        public Pays(string nom = "", int id=0)
        {
            Nom = nom;
            Id = id;
        }


    }
}
