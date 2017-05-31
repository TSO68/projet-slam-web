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
            foreach (Commande c in readAll())
            {
                if (c.Id.ToString() == dr[0].ToString())
                {
                    m = c;
                }
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
                DateTime date = new DateTime(Int32.Parse(res[2]), Int32.Parse(res[1]), Int32.Parse(res[0]));
                DateTime dateOnly = date.Date;
                Commande mag = new Commande(dr[0].ToString(), dateOnly, Int32.Parse(dr[2].ToString()));
                lesCommandes.Add(mag);
            }
            dr.Close();
            return lesCommandes;
        }
    }
}
