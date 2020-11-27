using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using ModelLayer.Business;

namespace ModelLayer.Data
{
    public class DaoEquipe
    {
        private Dbal thedbal;
        private DaoJoueur theDaoJoueur;

        public DaoEquipe(Dbal mydbal, DaoJoueur theDaoJoueur)
        {
            this.thedbal = mydbal;
            this.theDaoJoueur = theDaoJoueur;
        }

        public void Insert(Equipe theEquipe)
        {
            string query = "Equipe (id, nom, dateCreation) VALUES ("
                + theEquipe.Id + ",'"
                + theEquipe.Nom.Replace("'", "''") + "','"
                + theEquipe.DateCreation.ToString("yyyy-MM-dd") + "')";

            this.thedbal.Insert(query);

        }

        public void Update(Equipe myEquipe)
        {
            string query = "Equipe Set id = " + myEquipe.Id
                + ", nom = '" + myEquipe.Nom.Replace("'", "''")
                + "', dateCreation = '" + myEquipe.DateCreation.ToString("yyyy-MM-dd") + "'"
                + "WHERE id =" + myEquipe.Id;
            this.thedbal.Update(query);
        }

        public List<Equipe> SelectAll()
        {
            List<Equipe> listEquipe = new List<Equipe>();
            DataTable myTable = this.thedbal.SelectAll("Equipe");

            foreach (DataRow r in myTable.Rows)
            {
                listEquipe.Add(new Equipe((int)r["id"], (string)r["nom"], (DateTime)r["dateCreation"]));
            }

            return listEquipe;
        }

        public Equipe SelectById(int id)
        {
            DataRow rowEquipe = this.thedbal.SelectById("Equipe", id);
            
            return new Equipe((int)rowEquipe["id"], (string)rowEquipe["nom"], (DateTime)rowEquipe["dateCreation"]);
        }

        public Equipe SelectByName(string nom)
        {
            string search = "nom = '" + nom + "'";

            DataTable tableEquipe = this.thedbal.SelectByField("Equipe", search);
            return new Equipe((int)tableEquipe.Rows[0]["id"], (string)tableEquipe.Rows[0]["nom"], (DateTime)tableEquipe.Rows[0]["dateCreation"]);
        }

        public void Delete(Equipe uneEquipe)
        {
            string query = "Equipe where nom= '" + uneEquipe.Nom + "';";
            this.thedbal.Delete(query);
        }

    }
}
