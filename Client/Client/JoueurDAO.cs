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
            String req = "SELECT num,taille,poids,pied,venueClub, id_POSTE, PERSONNEL.id, nom, prenom, dateNaiss, lieuNaiss, biographie FROM JOUEUR INNER JOIN PERSONNEL ON JOUEUR.id = PERSONNEL.id WHERE num='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();
            
           
            
            PosteDAO pDAO = new PosteDAO();

            
            Joueur m = null;
            if (dr.Read())
            {//je peux le faire
                String []test = {dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString()} ;
                System.Diagnostics.Debug.Write("test"+test[9]+" ttttt");
                dr.Close();
                
                m = new Joueur(Convert.ToInt32(test[0]), Convert.ToInt32(test[1]), Convert.ToInt32(test[2]), test[3].ToString(), test[4].ToString(), pDAO.findById(test[5].ToString()), Convert.ToInt32(test[6]), test[7].ToString(), test[8].ToString(), Convert.ToDateTime(test[9]), test[10].ToString(), test[11].ToString());
                
            }
            dr.Close();
            return m;
        }

        public List<Joueur> readAll()
        {
            List<Joueur> lesJoueurs = new List<Joueur>();
            MySqlCommand cmd;
            String req = "SELECT num,taille,poids,pied,venueClub, PERSONNEL.id, nom, prenom, dateNaiss, lieuNaiss, biographie FROM JOUEUR INNER JOIN PERSONNEL ON JOUEUR.id = PERSONNEL.id";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();
            Poste p;
            PosteDAO pDAO = new PosteDAO();
            p = pDAO.findById(dr[5].ToString());
            while (dr.Read())
            {
                Joueur mag = new Joueur(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), dr[4].ToString(), p, Convert.ToInt32(dr[6]), dr[7].ToString(), dr[8].ToString(), Convert.ToDateTime(dr[9]), dr[10].ToString(), dr[11].ToString());
                lesJoueurs.Add(mag);
            }
            dr.Close();
            return lesJoueurs;
        }
    }
}
