using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
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
            String req = "INSERT INTO COMMANDE VALUES ('" + t.Id + "','" + t.DateCommande + "','" + t.LeCompte+ "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Commande t)
        {
            MySqlCommand cmd;
            String req = "UPDATE COMMANDE SET dateCommande='" + t.DateCommande + "', id_COMPTE="+ t.LeCompte + "WHERE id='" + t.Id + "'";

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
            MySqlCommand cmd2;
            String req2 = "DELETE FROM ligneCmd WHERE id_COMMANDE='" + t.Id;
            String req = "DELETE FROM COMMANDE WHERE id='" + t.Id;

            cmd2 = new MySqlCommand(req2, this.c);
            cmd = new MySqlCommand(req, this.c);

            int nb = cmd2.ExecuteNonQuery() + cmd.ExecuteNonQuery();
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
                string[] res = dr[1].ToString().Split('/', ':', ' ');
                m = new Commande(dr[0].ToString(), res[0]+"/"+ res[1]+"/"+ res[2], Int32.Parse(dr[2].ToString()));
            }
            return m;
        }

        public List<Commande> readAll()
        {
            List<Commande> lesCommandes = new List<Commande>();
            MySqlCommand cmd;
            String req = "SELECT * FROM COMMANDE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();
            CompteDAO cDAO = new CompteDAO();
            string[] idCompte = new string[req.Count()];

            while (dr.Read())
            {
                string[] res = dr[1].ToString().Split('/', ':', ' ');
                Commande mag = new Commande(dr[0].ToString(), res[0] + "/" + res[1] + "/" + res[2], Int32.Parse(dr[2].ToString()));
                lesCommandes.Add(mag);
            }
            dr.Close();
            return lesCommandes;
        }
    }
}
