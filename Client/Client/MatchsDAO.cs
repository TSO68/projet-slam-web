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



       /* public void create(Matchs m)
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


        }*/

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
            string idStade = null;
            string idAdversaire = null;
            StadeDAO sDAO = new StadeDAO();
            AdversaireDAO aDAO = new AdversaireDAO();

            if (dr.Read())
            {//je peux le faire
                System.Diagnostics.Debug.Write(dr[4]+ " " + dr[5]);
                idStade = dr[7].ToString();
                idAdversaire = dr[6].ToString();
                System.Diagnostics.Debug.Write(dr[1].ToString());
                DateTime date= Convert.ToDateTime(Convert.ToString(dr[1].ToString())+ " " +Convert.ToString(dr[2].ToString()));
                m = new Matchs(Convert.ToInt32(dr[0]), date, Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]), Convert.ToBoolean(dr[5]), null, null);
            }
            dr.Close();

            if (!String.IsNullOrEmpty(idStade))
            {
                m.LeStade = sDAO.findById(idStade.ToString());
            }

            if (!String.IsNullOrEmpty(idAdversaire))
            {
                m.LAdversaire = aDAO.findById(idAdversaire.ToString());
            }

            return m;
        }

        /*public List<Matchs> readAll()
        {
            List<Matchs> lesMatchs = new List<Matchs>();
            MySqlCommand cmd;
            String req = "SELECT * FROM MATCHS";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            StadeDAO sDAO = new StadeDAO();
            AdversaireDAO aDAO = new AdversaireDAO();
            string[] idStade = new string[req.Count()];
            string[] idAdversaire = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idStade[i] = dr[7].ToString();
                idAdversaire[i] = dr[6].ToString();
                i++;
                Matchs mag = new Matchs(Convert.ToInt32(dr[0]), Convert.ToDateTime(dr[1]), dr[2].ToString(), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]), Convert.ToBoolean(dr[5]), null, null);
                lesMatchs.Add(mag);
            }
            dr.Close();
            for(int k=0; k<i; k++)
            {
                lesMatchs[k].LeStade = sDAO.findById(idStade[k]);
                lesMatchs[k].LAdversaire = aDAO.findById(idAdversaire[k]);
            }
            return lesMatchs;
        }*/
    }
}
