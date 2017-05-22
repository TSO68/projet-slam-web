using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class CommandeDAO
    {
        private MySqlConnection c;

        public CommandeDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Commande t)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO COMMANDE VALUES ('" + t.Id + "','" + t.DateCommande + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Commande t)
        {
            MySqlCommand cmd;
            String req = "UPDATE COMMANDE SET dateCommande='" + t.DateCommande + "' WHERE id='" + t.Id + "'";

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

        public bool delete(Commande t)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM COMMANDE WHERE id='" + t.Id + "'";

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

        public Commande findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM COMMANDE WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Commande m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Commande(Convert.ToInt32(dr[0]), Convert.ToDateTime(dr[1]));
            }
            dr.Close();
            return m;
        }

        public List<Commande> readAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            MySqlCommand cmd;
            String req = "SELECT * FROM COMMANDE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Commande mag = new Commande(Convert.ToInt32(dr[0]), Convert.ToDateTime(dr[1]));
                lesCommandes.Add(mag);
            }
            dr.Close();
            return lesCommandes;
        }
    }
}
