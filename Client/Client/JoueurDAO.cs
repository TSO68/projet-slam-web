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
            PersonnelDAO pD = new PersonnelDAO();
            Personnel p = new Personnel(j.Id,j.Nom,j.Prenom, j.DateNaiss,j.LieuNaiss,j.Biographie,j.LaNationalite,j.LaPhoto);
            pD.create(p);
            MySqlCommand cmd;
           // MySqlCommand cmd2;

            String req = "INSERT INTO JOUEUR VALUES ("+  j.Num + ",'" + j.Taille.ToString().Replace(',', '.') + "','" + j.Poids.ToString().Replace(',', '.') + "','" + j.Pied + "','" + j.DateVenueClub + "','" + j.Id + "','" + j.LePoste.Id + "')";
            //String req2 = "INSERT INTO PERSONNEL VALUES (" + j.Id + ", '" + j.Nom + "', '" + j.Prenom + "', '" + j.DateNaiss + "', '" + j.LieuNaiss + "', '" + j.Biographie + "', " + j.LaNationalite.Id + ", " + j.LaPhoto.Id + ")";

            //cmd2 = new MySqlCommand(req2, this.c);
            cmd = new MySqlCommand(req, this.c);

            //cmd2.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
        }

        public bool update(Joueur j)
        {
            MySqlCommand cmd;
            String req = "UPDATE JOUEUR SET num="+j.Num+", taille='" + j.Taille.ToString().Replace(',', '.') + "', poids='" + j.Poids.ToString().Replace(',', '.') + "', pied='" + j.Pied + "', venueClub='" + j.DateVenueClub + "' WHERE id='" + j.Id + "'";

            Personnel p = new Personnel(j.Id, j.Nom, j.Prenom, j.DateNaiss, j.LieuNaiss, j.Biographie, j.LaNationalite, j.LaPhoto);
            PersonnelDAO pDAO = new PersonnelDAO();
            pDAO.update(p);

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
            MySqlCommand cmd2;
            MySqlCommand cmd3;
            String req = "DELETE FROM JOUEUR WHERE id=" + j.Id;

            String req2 = "DELETE FROM participe WHERE id_PERSONNEL=" + j.Id;

            String req3 = "DELETE FROM PERSONNEL WHERE id=" + j.Id;

            

            cmd = new MySqlCommand(req, this.c);
            cmd2 = new MySqlCommand(req2, this.c);
            cmd3 = new MySqlCommand(req3, this.c);
            int nb = cmd2.ExecuteNonQuery() + cmd.ExecuteNonQuery() + cmd3.ExecuteNonQuery();
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

            String req = "SELECT num,taille,poids,pied,venueClub, id_POSTE, PERSONNEL.id, nom, prenom, dateNaiss, lieuNaiss, biographie, id_NATIONALITE, id_PHOTO FROM JOUEUR INNER JOIN PERSONNEL ON JOUEUR.id = PERSONNEL.id WHERE PERSONNEL.id=" + code + "";

            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();



            PosteDAO pDAO = new PosteDAO();

            PhotoDAO phDAO = new PhotoDAO();
            NationaliteDAO nDAO = new NationaliteDAO();

            Joueur m = null;
            string idPoste = null;
            string idNationalite = null;
            string idPhoto= null;

            if (dr.Read())
            {//je peux le faire
                idPoste = dr[5].ToString();
                idNationalite = dr[12].ToString();

                idPhoto = dr[13].ToString();
                string[] res = dr[9].ToString().Split('/', ':', ' ');
                m = new Joueur(Convert.ToInt32(dr[0]), float.Parse(dr[1].ToString()), float.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), null, Convert.ToInt32(dr[6]), dr[7].ToString(), dr[8].ToString(), res[0] + "/" + res[1] + "/" + res[2], dr[10].ToString(), dr[11].ToString(), null, null);

            }
            dr.Close(); // On coupte la connexion
            dr.Dispose();
            if (!String.IsNullOrEmpty(idPoste)) // Si idPoste n'est pas null
            {
                m.LePoste = pDAO.findById(idPoste); // On attribue le poste au joueur
            }
            if (!String.IsNullOrEmpty(idNationalite)) // Si idPoste n'est pas null
            {

                m.LaNationalite = nDAO.findById(idNationalite); // On attribue le poste au joueur
            }
            if (!String.IsNullOrEmpty(idPhoto)) // Si idPoste n'est pas null
            {
                m.LaPhoto = phDAO.findById(idPhoto); // On attribue le poste au joueur

            }
            return m;
        }

        public List<Joueur> readAll()
        {
            List<Joueur> lesJoueurs = new List<Joueur>();
            MySqlCommand cmd;

            String req = "SELECT num,taille,poids,pied,venueClub,id_POSTE, PERSONNEL.id, nom, prenom, dateNaiss, lieuNaiss, biographie, id_NATIONALITE, id_PHOTO FROM JOUEUR INNER JOIN PERSONNEL ON JOUEUR.id = PERSONNEL.id";

            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();
            PosteDAO pDAO = new PosteDAO();

            PhotoDAO phDAO = new PhotoDAO();

            NationaliteDAO nDAO = new NationaliteDAO();

            Joueur m = null;
            string[] idPoste = new string[req.Count()];
            string[] idNationalite = new string[req.Count()];

            string[] idPhoto = new string[req.Count()];
            int i = 0;

            while (dr.Read())
            {
                idPoste[i] = dr[5].ToString();
                idNationalite[i] = dr[12].ToString();

                idPhoto[i] = dr[13].ToString();
                i++;
                string[] res = dr[9].ToString().Split('/', ':', ' ');
                m = new Joueur(Convert.ToInt32(dr[0]), float.Parse(dr[1].ToString()), float.Parse(dr[2].ToString()), dr[3].ToString(), dr[4].ToString(), null, Convert.ToInt32(dr[6]), dr[7].ToString(), dr[8].ToString(), res[0] + "/" + res[1] + "/" + res[2], dr[10].ToString(), dr[11].ToString(), null, null);

                lesJoueurs.Add(m);

            }
            dr.Close();
            dr.Dispose();
            for (int k = 0; k < i; k++)
            {
                lesJoueurs[k].LePoste = pDAO.findById(idPoste[k]);

                lesJoueurs[k].LaNationalite = nDAO.findById(idNationalite[k]);
                lesJoueurs[k].LaPhoto = phDAO.findById(idPhoto[k]);

            }
            return lesJoueurs;
        }
    }
}
