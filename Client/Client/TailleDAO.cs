using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Client
{
    class TailleDAO
    {
        private MySqlConnection c;

        public TailleDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Taille t)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO TAILLE VALUES ('" + t.Id + "','" + t.Libelle + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Taille t)
        {
            MySqlCommand cmd;
            String req = "UPDATE TAILLE SET libelle='" + t.Libelle + "' WHERE id='" + t.Id + "'";

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

        public bool delete(Taille t)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM TAILLE WHERE id='" + t.Id + "'";

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

        public Taille findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM TAILLE WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Taille m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Taille(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Taille> readAll()
        {
            List<Taille> lesTailles = new List<Taille>();
            MySqlCommand cmd;
            String req = "SELECT * FROM TAILLE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Taille mag = new Taille(Convert.ToInt32(dr[0]), dr[1].ToString());
                lesTailles.Add(mag);
            }
            dr.Close();
            return lesTailles;
        }
    }
}
