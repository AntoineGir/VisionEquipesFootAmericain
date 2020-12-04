using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Business
{
    public class Equipe
    {
        private int id;
        private string nom;
        private DateTime dateCreation;


        private List<Joueur> joueurs = new List<Joueur>();

        public DateTime DateCreation { get => dateCreation; set => dateCreation = value; }
        public string Nom { get => nom; set => nom = value; }
        public int Id { get => id; set => id = value; }
        public List<Joueur> Joueurs { get => joueurs; set => joueurs = value; }

        public Equipe(int id = 0, string nom = "", DateTime dateCreation= new DateTime(),   List<Joueur> joueurs =null)
        {
            DateCreation = dateCreation;
            Nom = nom;
            Id = id;
            Joueurs = joueurs;

        }

        public Equipe() { }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
