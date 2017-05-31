using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Client
{
    class CompteDAO
    {
        private MySqlConnection c;

        public CompteDAO()
        {
            this.c = Connexion.getIntstance();
        }

        public Compte chercherCompteAvecIdCommande(string id)
        {
            CommandeDAO cdao = new CommandeDAO();
            Commande com = null;
            Compte unCompte = null;
            foreach (Commande co in cdao.readAll())
            {
                if (co.Id.ToString() == id)
                {
                    com = co;
                }
            }
            foreach (Compte c in readAll())
            {
                if (com.LeCompte == c.Id)
                {
                    unCompte = c;
                }
            }
            return unCompte;
        }

        public void create(Compte c)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO COMPTE VALUES ('" + c.Id + "','" + c.Mail + "','" + c.Mdp + "','" + c.Nom + "','" + c.Prenom + "','" + c.Tel + "','" + c.Adresse + "','" + c.Cp + "','" + c.Ville + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Compte c)
        {
            MySqlCommand cmd;
            String req = "UPDATE COMPTE SET mail='" + c.Mail + "', mdp='" + c.Mdp + "', nom='" + c.Nom + "', prenom='" + c.Prenom + "', tel='" + c.Tel + "', adresse='" + c.Adresse + "', cp='" + c.Cp + "', ville='" + c.Ville + "' WHERE id='" + c.Id + "'";

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

        public bool delete(Compte c)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM COMPTE WHERE id='" + c.Id + "'";

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

        public Compte findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM COMPTE WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Compte m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Compte(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Compte> readAll()
        {
            List<Compte> lesComptes = new List<Compte>();
            MySqlCommand cmd;
            String req = "SELECT * FROM COMPTE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Compte mag = new Compte(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString());
                lesComptes.Add(mag);
            }
            dr.Close();
            return lesComptes;
        }
    }
}
