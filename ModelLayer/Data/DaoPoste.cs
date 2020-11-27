using ModelLayer.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ModelLayer.Data
{
    public class DaoPoste
    {
        private Dbal thedbal;

        public DaoPoste(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public void Insert(Poste thePoste)
        {
            string query= "Poste(id, nom, escouade) VALUES (" 
                + thePoste.Id + ", '"
                +thePoste.Nom + "')";

        }

        public List<Poste> SelectAll()
        {
            List<Poste> listPoste = new List<Poste>();
            DataTable myTable = this.thedbal.SelectAll("Poste");

            foreach (DataRow r in myTable.Rows)
            {
                listPoste.Add(new Poste((int)r["id"], (string)r["nom"]));
            }

            return listPoste;
        }

        public Poste SelectByName(string nomPoste)
        {
            DataTable result = new DataTable();
            result = this.thedbal.SelectByField("Poste", "nom= '" + nomPoste.Replace("'", "''") + "'");
            Poste foundPoste = new Poste((int)result.Rows[0]["id"], (string)result.Rows[0]["nom"]);

            return foundPoste;
        }

        public Poste SelectById(int idPoste)
        {
            DataRow result = this.thedbal.SelectById("Poste", idPoste);
            return new Poste((int)result["id"], (string)result["nom"]);
        }

    }
}
