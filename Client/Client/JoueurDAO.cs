using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace Client
{
    class JoueurDAO
    {
        private MySqlConnection c;

        public JoueurDAO()
        {
            this.c = Connexion.getIntstance();
        }

        

        public void create(Joueur j)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO JOUEUR VALUES ('" + j.Num + "','" + j.Taille + "','" + j.Poids + "','" + j.Pied+ "','" + j.DateVenueClub+ "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Joueur j)
        {
            MySqlCommand cmd;
            String req = "UPDATE JOUEUR SET taille='" + j.Taille + "', poids='" + j.Poids + "', pied='" + j.Pied + "', venueClub='" + j.DateVenueClub + "' WHERE num='" + j.Num + "'";

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

        public bool delete(Joueur j)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM JOUEUR WHERE num='" + j.Num + "'";

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

        public Joueur findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM JOUEUR WHERE num='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();
            
            Joueur m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Joueur(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), Convert.ToDateTime(dr[4]), Convert.ToInt32(dr[5]), dr[6].ToString(), dr[7].ToString(), Convert.ToDateTime(dr[8]), dr[9].ToString(), Convert.ToInt32(dr[10]), dr[12].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Joueur> readAll()
        {
            List<Joueur> lesJoueurs = new List<Joueur>();
            MySqlCommand cmd;
            String req = "SELECT * FROM JOUEUR";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Joueur mag = new Joueur(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), Convert.ToDateTime(dr[4]), Convert.ToInt32(dr[5]), dr[6].ToString(), dr[7].ToString(), Convert.ToDateTime(dr[8]), dr[9].ToString(), Convert.ToInt32(dr[10]), dr[12].ToString());
                lesJoueurs.Add(mag);
            }
            dr.Close();
            return lesJoueurs;
        }
    }
}
