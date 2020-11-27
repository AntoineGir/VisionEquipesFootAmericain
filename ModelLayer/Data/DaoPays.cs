using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using ModelLayer.Business;

namespace ModelLayer.Data
{
    public class DaoPays
    {
        private Dbal thedbal;

        public DaoPays(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public List<Pays> SelectAll()
        {
            List<Pays> listPays = new List<Pays>();
            DataTable myTable = this.thedbal.SelectAll("Pays");

            foreach (DataRow r in myTable.Rows)
            {
                listPays.Add(new Pays((string)r["nom"], (int)r["id"]));
            }

            return listPays;
        }


        public Pays SelectByName(string namePays)
        {
            DataTable result = new DataTable();
            result = this.thedbal.SelectByField("pays", "nom = '" + namePays.Replace("'", "''") + "'");
            Pays foundPays = new Pays((string)result.Rows[0]["nom"], (int)result.Rows[0]["id"]);
            return foundPays;

        }

        public Pays SelectById(int idPays)
        {
            DataRow result = this.thedbal.SelectById("Pays", idPays);
            return new Pays((string)result["nom"], (int)result["id"]);

        }
    }
}
