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
            string[] res = m.DateMatch.ToString().Split(' ',':','/');
            string date = res[2]+"-"+res[1]+"-"+res[0];
            string heure = res[3]+":00:00";
            string exterieurBool = "";
            if (m.ExterieurON == true)
            {
                exterieurBool = "1";
            }
            else
            {
                exterieurBool = "0";
            }
            String req = "INSERT INTO MATCHS VALUES ('" + m.Id + "','" + date + "','" + heure + "','" + m.ScoreDom + "','" + m.ScoreExt + "','" + exterieurBool + "','" + m.LAdversaire.Id + "','" + m.LeStade.Id + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }
        
        public bool update(Matchs m)
        {
            MySqlCommand cmd;
            string[] res = m.DateMatch.ToString().Split(' ');
            string date = res[0];
            string heure = res[1];
            String req = "UPDATE MATCHS SET dateMatch='" + date + "', heure='" + heure + "', scoreDom='" + m.ScoreDom + "', scoreExt='" + m.ScoreExt + "', exterieurON='" + m.ExterieurON + "', id_ADVERSAIRE='" + m.LAdversaire.Id + "', id_STADE='" + m.LeStade.Id + "' WHERE id='" + m.Id + "'";

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
            MySqlCommand cmd2;
            String req = "DELETE FROM MATCHS WHERE id='" + m.Id + "'";
            String req2 = "DELETE FROM participe WHERE id='" + m.Id + "'";

            cmd = new MySqlCommand(req, this.c);
            cmd2 = new MySqlCommand(req2, this.c);
            int nb = cmd2.ExecuteNonQuery() + cmd.ExecuteNonQuery();
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
                idStade = dr[7].ToString();
                idAdversaire = dr[6].ToString();
                string[] res = dr[1].ToString().Split('/', ':', ' ');
                string[] res2 = dr[2].ToString().Split(':');
                DateTime date = new DateTime(Int32.Parse(res[2]), Int32.Parse(res[1]), Int32.Parse(res[0]), Int32.Parse(res2[0]), Int32.Parse(res2[1]), Int32.Parse(res2[2]));
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

        public List<Matchs> readAll()
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
                string[] res = dr[1].ToString().Split('/', ':', ' ');
                string[] res2 = dr[2].ToString().Split(':');
                DateTime date = new DateTime(Int32.Parse(res[2]), Int32.Parse(res[1]), Int32.Parse(res[0]), Int32.Parse(res2[0]), Int32.Parse(res2[1]), Int32.Parse(res2[2]));
                Matchs mag = new Matchs(Convert.ToInt32(dr[0]), date, Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]), Convert.ToBoolean(dr[5]), null, null);
                lesMatchs.Add(mag);
            }
            dr.Close();
            for(int k=0; k<i; k++)
            {
                lesMatchs[k].LeStade = sDAO.findById(idStade[k]);
                lesMatchs[k].LAdversaire = aDAO.findById(idAdversaire[k]);
            }
            return lesMatchs;
        }
    }
}
