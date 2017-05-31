using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
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
            String req = "INSERT INTO participe VALUES ('" + p.ButMarques + "','" + p.PasseDecisives + "','" + p.CartonJauneON + "','" + p.CartonRougeON + "','" + p.MinutesJouees + "','" + p.LeMatch.Id + "','" + p.LeJoueur.Id+"')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(participe p)
        {
            MySqlCommand cmd;
            String req = "UPDATE participe SET butMarques='" + p.ButMarques + "', passeDecisives='" + p.PasseDecisives + "', cartonJauneON='" + p.CartonJauneON + "', cartonRougeON='" + p.CartonRougeON + "', minutesJouees='" + p.MinutesJouees + "'  WHERE id='" + p.LeJoueur.Id + " AND id_MATCH=" + p.LeMatch.Id + "";

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

        public bool delete(participe p)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM participe WHERE id='" + p.LeJoueur.Id + " AND id_MATCH="+p.LeMatch.Id+"";

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

            participe p = null;
            string idMatch = null;
            string idJoueur = null;
            MatchsDAO mDAO = new MatchsDAO();
            JoueurDAO jDAO = new JoueurDAO();
            if (dr.Read())
            {//je peux le faire
                idMatch = dr[0].ToString();
                idJoueur = dr[1].ToString();
                p = new participe(null, null, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToBoolean(dr[4]), Convert.ToBoolean(dr[5]), Convert.ToInt32(dr[6]));
            }
            dr.Close();
            if (!String.IsNullOrEmpty(idMatch))
            {
                p.LeMatch = mDAO.findById(idMatch.ToString());
            }

            if (!String.IsNullOrEmpty(idJoueur))
            {
                p.LeJoueur = jDAO.findById(idJoueur.ToString());
            }
            return p;
        }

        public List<participe> readAll()
        {
            List<participe> lesparticipes = new List<participe>();
            MySqlCommand cmd;
            String req = "SELECT * FROM participe";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();
            MatchsDAO mDAO = new MatchsDAO();
            JoueurDAO jDAO = new JoueurDAO();
            List<string> idMatch = new List<string>();
            List<string> idJoueur = new List<string>();
            int i = 0;
            while (dr.Read())
            {
                idMatch.Add(dr[0].ToString());
                idJoueur.Add(dr[1].ToString());
                i++;
                participe p = new participe(null, null, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToBoolean(dr[4]), Convert.ToBoolean(dr[5]), Convert.ToInt32(dr[6]));
                lesparticipes.Add(p);
            }
            dr.Close();
            int k = 0;
            MessageBox.Show(lesparticipes.Count.ToString());
            while (k<lesparticipes.Count)
            {
                Matchs lem=null;
                Joueur lej=null;
                try
                {
                    lem = mDAO.findById(idMatch.ElementAt(k));
                    lej = jDAO.findById(idJoueur.ElementAt(k));
                }
                catch
                {
                    MessageBox.Show("pp");
                }
                    lesparticipes.ElementAt(k).LeMatch = lem;
                    lesparticipes.ElementAt(k).LeJoueur = lej;
                k++;

            }
            
            return lesparticipes;
        }
    }
}
