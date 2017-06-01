using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class FaitDAO
    {
        private MySqlConnection c;

        public FaitDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Fait f)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO fait VALUES ('" + f.LeProduit + "','" + f.LaTaille + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Fait f)
        {
            MySqlCommand cmd;
            String req = "UPDATE fait SET id_TAILLE='" + f.LaTaille + "' WHERE id='" + f.LeProduit + "'";

            cmd = new MySqlCommand(req, this.c);
            int nb = cmd.ExecuteNonQuery();
            if (nb != 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public bool delete(Fait f)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM fait WHERE id='" + f.LeProduit + "'";

            cmd = new MySqlCommand(req, this.c);
            int nb = cmd.ExecuteNonQuery();
            if (nb != 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public Fait findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM fait WHERE id = '" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Fait m = null;
            string idProduit = null;
            string idTaille = null;
            ProduitDAO pDAO = new ProduitDAO();
            TailleDAO tDAO = new TailleDAO();

            if (dr.Read())
            {//je peux le faire
                idProduit = dr[0].ToString();
                idTaille = dr[1].ToString();
                m = new Fait(null, null);
            }
            dr.Close();
            if (!String.IsNullOrEmpty(idProduit))
            {
                m.LeProduit = pDAO.findById(idProduit.ToString());
            }
            if (!String.IsNullOrEmpty(idTaille))
            {
                m.LaTaille = tDAO.findById(idTaille.ToString());
            }
            return m;

        }

        public List<Fait> readAll()
        {
            List<Fait> lesFaits = new List<Fait>();
            MySqlCommand cmd;
            String req = "SELECT * FROM fait";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr2 = cmd.ExecuteReader();
            int m = 0;
            while (dr2.Read())
            {
                m++;
            }
            dr2.Close();

            MySqlDataReader dr = cmd.ExecuteReader();
            ProduitDAO pDAO = new ProduitDAO();
            TailleDAO tDAO = new TailleDAO();
            string[] idProduit = new string[m];
            string[] idTaille = new string[m];
            int i = 0;

            while (dr.Read())
            {
                idProduit[i] = dr[0].ToString();
                idTaille[i] = dr[1].ToString();
                i++;
                Fait fa = new Fait(null, null);
                lesFaits.Add(fa);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                lesFaits[k].LeProduit = pDAO.findById(idProduit[k]);
                lesFaits[k].LaTaille = tDAO.findById(idTaille[k]);
            }
            return lesFaits;
        }
    }
}
