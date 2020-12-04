using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Business
{
    public class Joueur
    {
        private string nom;
        private DateTime dateEntree;
        private int id;
        private DateTime dateNaissance;
        private Pays idPays;
        private Poste idPoste;

        public string Nom { get => nom; set => nom = value; }
        public DateTime DateEntree { get => dateEntree; set => dateEntree = value; }
        public int Id { get => id; set => id = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public Pays IdPays { get => idPays; set => idPays = value; }
        public Poste IdPoste { get => idPoste; set => idPoste = value; }

        public Joueur(string nom="", DateTime dateEntree= new DateTime(), int id=0, DateTime dateNaissance = new DateTime(), Pays idPays=null, Poste idPoste=null )
        {
            Nom = nom;
            DateEntree = dateEntree;
            Id = id;
            DateNaissance = dateNaissance;
            IdPays = idPays;
            IdPoste = idPoste;
        }

        public Joueur() { }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
