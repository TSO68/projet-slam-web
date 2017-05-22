using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class participeDAO
    {
        private MySqlConnection c;

        public participeDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(participe p)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO participe VALUES ('" + p.Id + "','" + p.ButMarques + "','" + p.PasseDecisives + "','" + p.CartonJauneON + "','" + p.CartonRougeON + "','" + p.MinutesJouees + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(participe p)
        {
            MySqlCommand cmd;
            String req = "UPDATE participe SET butMarques='" + p.ButMarques + "', passeDecisives='" + p.PasseDecisives + "', cartonJauneON='" + p.CartonJauneON + "', cartonRougeON='" + p.CartonRougeON + "', minutesJouees='" + p.MinutesJouees + "' WHERE id='" + p.Id + "'";

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

        public bool delete(participe a)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM participe WHERE id='" + a.Id + "'";

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

        public participe findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM participe WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            participe m = null;
            if (dr.Read())
            {//je peux le faire
                m = new participe(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToBoolean(dr[3]), Convert.ToBoolean(dr[4]), Convert.ToInt32(dr[5]));
            }
            dr.Close();
            return m;
        }

        public List<participe> readAll()
        {
            List<participe> lesparticipes = new List<participe>();
            MySqlCommand cmd;
            String req = "SELECT * FROM participe";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                participe mag = new participe(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), Convert.ToBoolean(dr[3]), Convert.ToBoolean(dr[4]), Convert.ToInt32(dr[5]));
                lesparticipes.Add(mag);
            }
            dr.Close();
            return lesparticipes;
        }
    }
}
