using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class ProduitDAO
    {
        private MySqlConnection c;

        public ProduitDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Produit p)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO PRODUIT VALUES ('" + p.Id + "','" + p.Nom + "','" + p.Prix + "','" + p.Description + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Produit p)
        {
            MySqlCommand cmd;
            String req = "UPDATE PRODUIT SET nom='" + p.Nom + "' WHERE id='" + p.Id + "'";

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

        public bool delete(Produit p)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM PRODUIT WHERE id='" + p.Id + "'";

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

        public Produit findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM PRODUIT WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Produit m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Produit(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]),dr[3].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Produit> readAll()
        {
            List<Produit> lesProduits = new List<Produit>();
            MySqlCommand cmd;
            String req = "SELECT * FROM PRODUIT";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Produit mag = new Produit(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]), dr[3].ToString());
                lesProduits.Add(mag);
            }
            dr.Close();
            return lesProduits;
        }
    }
}
