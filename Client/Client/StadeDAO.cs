using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class StadeDAO
    {
        private MySqlConnection c;

        public StadeDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Stade s)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO STADE VALUES ('" + s.Id + "','" + s.Libelle + "','" + s.NbPlaces + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Stade s)
        {
            MySqlCommand cmd;
            String req = "UPDATE STADE SET libelle='" + s.Libelle+ "', nbPlaces='" + s.NbPlaces + "' WHERE id='" + s.Id + "'";

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

        public bool delete(Stade s)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM STADE WHERE id='" + s.Id + "'";

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

        public Stade findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM STADE WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Stade m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Stade(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]));
            }
            dr.Close();
            return m;
        }

        public List<Stade> readAll()
        {
            List<Stade> lesStades = new List<Stade>();
            MySqlCommand cmd;
            String req = "SELECT * FROM STADE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Stade mag = new Stade(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]));
                lesStades.Add(mag);
            }
            dr.Close();
            return lesStades;
        }
    }
}
