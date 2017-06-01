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

        public List<participe> findByIdMatch(String code)
        {
            List<participe> lesparticipes = new List<participe>();
            MySqlCommand cmd;
            String req = "SELECT * FROM participe WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();


            MatchsDAO mDAO = new MatchsDAO();
            JoueurDAO jDAO = new JoueurDAO();
            string[] idMatch = new string[req.Count()];
            string[] idJoueur = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idMatch[i] = dr[0].ToString();
                idJoueur[i] = dr[1].ToString();
                i++;
                participe p = new participe(null, null, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToBoolean(dr[4]), Convert.ToBoolean(dr[5]), Convert.ToInt32(dr[6]));
                lesparticipes.Add(p);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                lesparticipes[k].LeMatch = mDAO.findById(idMatch[k]);
                lesparticipes[k].LeJoueur = jDAO.findById(idJoueur[k]);
            }
            return lesparticipes;
        }
        public List<participe> findByIdJoueur(String code)
        {
            List<participe> lesparticipes = new List<participe>();
            MySqlCommand cmd;
            String req = "SELECT * FROM participe WHERE id_PERSONNEL='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            MatchsDAO mDAO = new MatchsDAO();
            JoueurDAO jDAO = new JoueurDAO();
            string[] idMatch = new string[req.Count()];
            string[] idJoueur = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idMatch[i] = dr[0].ToString();
                idJoueur[i] = dr[1].ToString();
                i++;
                participe p = new participe(null, null, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToBoolean(dr[4]), Convert.ToBoolean(dr[5]), Convert.ToInt32(dr[6]));
                lesparticipes.Add(p);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                lesparticipes[k].LeMatch = mDAO.findById(idMatch[k]);
                lesparticipes[k].LeJoueur = jDAO.findById(idJoueur[k]);
            }
            return lesparticipes;
        }
        public List<participe> findByIdJoueurEtMatch(String code, String a)
        {
            List<participe> lesparticipes = new List<participe>();
            MySqlCommand cmd;
            String req = "SELECT * FROM participe WHERE id_PERSONNEL='" + code + "' AND id='" + a + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            MatchsDAO mDAO = new MatchsDAO();
            JoueurDAO jDAO = new JoueurDAO();
            string[] idMatch = new string[req.Count()];
            string[] idJoueur = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idMatch[i] = dr[0].ToString();
                idJoueur[i] = dr[1].ToString();
                i++;
                participe p = new participe(null, null, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToBoolean(dr[4]), Convert.ToBoolean(dr[5]), Convert.ToInt32(dr[6]));
                lesparticipes.Add(p);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                lesparticipes[k].LeMatch = mDAO.findById(idMatch[k]);
                lesparticipes[k].LeJoueur = jDAO.findById(idJoueur[k]);
            }
            return lesparticipes;
        }

        public List<participe> readAll()
        { 
            String req = "SELECT * FROM participe";
            List<participe> lesparticipes = new List<participe>();
            MySqlCommand cmd = new MySqlCommand(req, this.c);
 
            MySqlDataReader dr2 = cmd.ExecuteReader();
            int m = 0;
            while (dr2.Read())
            {
                m++;
            }
            dr2.Close();
 
            MySqlDataReader dr = cmd.ExecuteReader();
            MatchsDAO mDAO = new MatchsDAO();
            JoueurDAO jDAO = new JoueurDAO();
            string[] idMatch = new string[m];
            string[] idJoueur = new string[m];
            int i = 0;
             while (dr.Read())
             {
                idMatch[i] = dr[0].ToString();
                idJoueur[i] = dr[1].ToString();
                i++;
                participe p = new participe(null, null, Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), Convert.ToBoolean(dr[4]), Convert.ToBoolean(dr[5]), Convert.ToInt32(dr[6]));
                lesparticipes.Add(p);
             }
             dr.Close();
            for (int k = 0; k < i; k++)
            {
                lesparticipes[k].LeMatch = mDAO.findById(idMatch[k]);
                lesparticipes[k].LeJoueur = jDAO.findById(idJoueur[k]);
            }
             return lesparticipes;
         }
    }
}
