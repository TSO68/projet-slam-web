using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class NationaliteDAO
    {
        private MySqlConnection c;

        public NationaliteDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Nationalite n)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO NATIONALITE VALUES ('" + n.Id + "','" + n.Libelle + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();
            
        }

        public bool update(Nationalite n)
        {
            MySqlCommand cmd;
            String req = "UPDATE NATIONALITE SET libelle='" + n.Libelle + "' WHERE id='" + n.Id + "'";

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

        public bool delete(Nationalite n)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM NATIONALITE WHERE id='" + n.Id + "'";

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

        public Nationalite findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM NATIONALITE WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Nationalite m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Nationalite(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Nationalite> readAll()
        {
            List<Nationalite> lesNationalites = new List<Nationalite>();
            MySqlCommand cmd;
            String req = "SELECT * FROM NATIONALITE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Nationalite mag = new Nationalite(Convert.ToInt32(dr[0]), dr[1].ToString());
                lesNationalites.Add(mag);
            }
            dr.Close();
            return lesNationalites;
        }
    }
}
