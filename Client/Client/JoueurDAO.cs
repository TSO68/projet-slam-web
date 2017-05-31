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
            String req = "INSERT INTO JOUEUR VALUES ('" + j.Num + "','" + j.Taille + "','" + j.Poids + "','" + j.Pied + "','" + j.DateVenueClub + "')";

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
            String req = "SELECT num,taille,poids,pied,venueClub, id_POSTE, PERSONNEL.id, nom, prenom, dateNaiss, lieuNaiss, biographie FROM JOUEUR INNER JOIN PERSONNEL ON JOUEUR.id = PERSONNEL.id WHERE PERSONNEL.id=" + code + "";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();



            PosteDAO pDAO = new PosteDAO();


            Joueur m = null;
            string idPoste = null;

            if (dr.Read())
            {//je peux le faire
                idPoste = dr[5].ToString();

                m = new Joueur(Convert.ToInt32(dr[0]), float.Parse(dr[1].ToString()), float.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), null, Convert.ToInt32(dr[6]), dr[7].ToString(), dr[8].ToString(), Convert.ToDateTime(dr[9]), dr[10].ToString(), dr[11].ToString());

            }
            dr.Close(); // On coupte la connexion
            dr.Dispose();
            if (!String.IsNullOrEmpty(idPoste)) // Si idPoste n'est pas null
            {
                m.LePoste = pDAO.findById(idPoste); // On attribue le poste au joueur
            }
            return m;
        }

        public List<Joueur> readAll()
        {
            List<Joueur> lesJoueurs = new List<Joueur>();
            MySqlCommand cmd;
            String req = "SELECT num,taille,poids,pied,venueClub,id_POSTE, PERSONNEL.id, nom, prenom, dateNaiss, lieuNaiss, biographie FROM JOUEUR INNER JOIN PERSONNEL ON JOUEUR.id = PERSONNEL.id";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();
            PosteDAO pDAO = new PosteDAO();

            Joueur m = null;
            string[] idPoste = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idPoste[i] = dr[5].ToString();
                i++;

                m = new Joueur(Convert.ToInt32(dr[0]), float.Parse(dr[1].ToString()), float.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), null, Convert.ToInt32(dr[6]), dr[7].ToString(), dr[8].ToString(), Convert.ToDateTime(dr[9]), dr[10].ToString(), dr[11].ToString());
                lesJoueurs.Add(m);

            }
            dr.Close();
            dr.Dispose();
            for (int k = 0; k < i; k++)
            {
                lesJoueurs[k].LePoste = pDAO.findById(idPoste[k]);
            }
            return lesJoueurs;
        }
    }
}
