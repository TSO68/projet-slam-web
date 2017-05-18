using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Client
{
    class PosteDAO
    {
        private MySqlConnection c;

        public PosteDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Poste p)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO POSTE VALUES ('" + p.Id + "','" + p.Libelle + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Poste p)
        {
            MySqlCommand cmd;
            String req = "UPDATE POSTE SET nom='" + p.Id + "', prenom='" + p.Libelle + "'";

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

        public bool delete(Poste p)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM POSTE WHERE id='" + p.Id + "'";

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

        public Poste findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM POSTE WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Poste m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Poste(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Poste> readAll()
        {
            List<Poste> lesPostes = new List<Poste>();
            MySqlCommand cmd;
            String req = "SELECT * FROM POSTE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Poste mag = new Poste(Convert.ToInt32(dr[0]), dr[1].ToString());
                lesPostes.Add(mag);
            }
            dr.Close();
            return lesPostes;
        }
    }
}
