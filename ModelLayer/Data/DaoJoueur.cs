using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using ModelLayer.Business;

namespace ModelLayer.Data
{
    public class DaoJoueur
    {
        private Dbal thedbal;
        private DaoPays theDaoPays;
        private DaoPoste theDaoPoste;

        public DaoJoueur(Dbal mydbal, DaoPays theDaoPays, DaoPoste theDaoPoste)
        {
            this.thedbal = mydbal;
            this.theDaoPays = theDaoPays;
            this.theDaoPoste = theDaoPoste;
        }


        public void Insert(Joueur theJoueur, Equipe thequipe)
        {
            string query = "Joueur (id, nom, dateEntree, dateNaissance, pays, poste, equipe) VALUES ("
                +theJoueur.Id + ",'"
                +theJoueur.Nom + "','"
                +theJoueur.DateEntree + "','"
                +theJoueur.DateNaissance + "',"
                +theJoueur.IdPays.Id + ","
                +theJoueur.IdPays.Id + ","
                +thequipe.Id + ")" ;
            this.thedbal.Insert(query);
        }

        public List<Joueur> SelectAll()
        {
            List<Joueur> listJoueur = new List<Joueur>();
            DataTable myTable = this.thedbal.SelectAll("Joueur");

            foreach (DataRow r in myTable.Rows)
            {
                Pays myPays = this.theDaoPays.SelectById((int)r["id"]);
                Poste myPoste = this.theDaoPoste.SelectById((int)r["id"]);
                listJoueur.Add(new Joueur((string)r["nom"], (DateTime)r["dateEntree"], (int)r["id"], (DateTime)r["dateNaissance"], myPays, myPoste));
            }
            return listJoueur;
        }

        public void Update(Joueur myJoueur, Equipe myequipe)
        {
            string query = "Joueur SET id=" + myJoueur.Id
                + ", nom = ' " + myJoueur.Nom.Replace("'", "''")
                + "' dateEntree = '" + myJoueur.DateEntree.ToString("yyyy-MM-dd")
                + "', dateNaissance = '" + myJoueur.DateEntree.ToString("yyyy-MM-dd ")
                + "', pays =" + myJoueur.IdPays.Id
                + ", poste =" + myJoueur.IdPoste.Id
                + ", equipe =" + myequipe.Id
                + "WHERE id= " + myJoueur.Id;
            this.thedbal.Update(query);
        }

        public Joueur SelectById(int id)
        {
            DataRow rowJoueur = this.thedbal.SelectById("Joueur", id);
            Pays myPays = this.theDaoPays.SelectById((int)rowJoueur["id"]);
            Poste myPoste = this.theDaoPoste.SelectById((int)rowJoueur["id"]);
            return new Joueur((string)rowJoueur["nom"], (DateTime)rowJoueur["dateEntree"], (int)rowJoueur["id"], (DateTime)rowJoueur["dateNaissance"], myPays, myPoste);
        }

        public Joueur SelectByName(string nom)
        {
            string search = "nom ='" + nom + "'";
            DataTable tableJoueur = this.thedbal.SelectByField("Joueur", search);
            Pays myPays = this.theDaoPays.SelectById((int)tableJoueur.Rows[0]["id"]);
            Poste myPoste = this.theDaoPoste.SelectById((int)tableJoueur.Rows[0]["id"]);
            return new Joueur((string)tableJoueur.Rows[0]["nom"], (DateTime)tableJoueur.Rows[0]["dateEntree"], (int)tableJoueur.Rows[0]["id"], (DateTime)tableJoueur.Rows[0]["dateNaissance"], myPays, myPoste);
        }

        public void Delete(Joueur unJoueur)
        {
            string query = "Joueur where nom = '" + unJoueur.Nom + "';";

            this.thedbal.Delete(query);
        }

    }
}
