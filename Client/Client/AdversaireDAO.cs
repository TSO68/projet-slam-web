using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class AdversaireDAO
    {
        private MySqlConnection c;

        public AdversaireDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Adversaire a)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO ADVERSAIRE VALUES ('" + a.Id + "','" + a.Libelle + "','" + a.Logo + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Adversaire a)
        {
            MySqlCommand cmd;
            String req = "UPDATE ADVERSAIRE SET libelle='" + a.Libelle + "', logo='" + a.Logo + "' WHERE id='" + a.Id + "'";

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

        public bool delete(Adversaire a)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM ADVERSAIRE WHERE id='" + a.Id + "'";

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

        public Adversaire findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM ADVERSAIRE WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Adversaire m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Adversaire(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Adversaire> readAll()
        {
            List<Adversaire> lesAdversaires = new List<Adversaire>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ADVERSAIRE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Adversaire mag = new Adversaire(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString());
                lesAdversaires.Add(mag);
            }
            dr.Close();
            return lesAdversaires;
        }
    }
}
