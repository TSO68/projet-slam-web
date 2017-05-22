using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class MatchsDAO
    {
        private MySqlConnection c;

        public MatchsDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Matchs m)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO MATCHS VALUES ('" + m.Id + "','" + m.DateMatch + "','" + m.Heure + "','" + m.ExterieurON + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Matchs m)
        {
            MySqlCommand cmd;
            String req = "UPDATE MATCHS SET dateMatch='" + m.DateMatch + "', heure='" + m.Heure + "', exterieurON='" + m.ExterieurON + "' WHERE id='" + m.Id + "'";

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

        public bool delete(Matchs m)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM MATCHS WHERE id='" + m.Id + "'";

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

        public Matchs findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM MATCHS WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Matchs m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Matchs(Convert.ToInt32(dr[0]), Convert.ToDateTime(dr[1]), Convert.ToDateTime(dr[2].ToString()), Convert.ToBoolean(dr[3]));
            }
            dr.Close();
            return m;
        }

        public List<Matchs> readAll()
        {
            List<Matchs> lesMatchss = new List<Matchs>();
            MySqlCommand cmd;
            String req = "SELECT * FROM MATCHS";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Matchs mag = new Matchs(Convert.ToInt32(dr[0]), Convert.ToDateTime(dr[1]), Convert.ToDateTime(dr[2].ToString()), Convert.ToBoolean(dr[3]));
                lesMatchss.Add(mag);
            }
            dr.Close();
            return lesMatchss;
        }
    }
}
