using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class AdversaireDAO
    {
        private MySqlConnection c;

        public AdversaireDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Adversaire a)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO ADVERSAIRE VALUES ('" + a.Id + "','" + a.Libelle + "','" + a.Logo + "','" + a.LeStade.Id + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Adversaire a)
        {
            MySqlCommand cmd;
            String req = "UPDATE ADVERSAIRE SET libelle='" + a.Libelle + "', logo='" + a.Logo + "', id_STADE='" + a.LeStade.Id + "' WHERE id='" + a.Id + "'";

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

        public bool delete(Adversaire a)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM ADVERSAIRE WHERE id='" + a.Id + "'";

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

        public Adversaire findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM ADVERSAIRE WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            StadeDAO sDAO = new StadeDAO();
            string idStade = null;
            Adversaire a = null;
            if (dr.Read())
            {//je peux le faire
                idStade = dr[3].ToString();
                a = new Adversaire(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), null);
            }
            dr.Close();
            if (!String.IsNullOrEmpty(idStade))
            {
                a.LeStade = sDAO.findById(idStade.ToString());
            }
            return a;
        }

        public List<Adversaire> readAll()
        {
            List<Adversaire> lesAdversaires = new List<Adversaire>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ADVERSAIRE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            StadeDAO sDAO = new StadeDAO();
            string[] idStade = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idStade[i] = dr[3].ToString();
                i++;
                Adversaire mag = new Adversaire(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), null);
                lesAdversaires.Add(mag);
            }
            dr.Close();
            for(int k = 0; k < i; k++)
            {
                lesAdversaires[k].LeStade = sDAO.findById(idStade[k]);
            }
            return lesAdversaires;
        }
    }
}
