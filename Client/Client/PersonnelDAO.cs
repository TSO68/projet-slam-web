using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Client
{
    class PersonnelDAO
    {
        private MySqlConnection c;

        public PersonnelDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Personnel p)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO PERSONNEL VALUES ('" + p.Id + "','" + p.Nom + "','" + p.Prenom + "','" + p.DateNaiss + "','" + p.LieuNaiss + "','" + p.Biographie + "','" + p.LaNationalite + "','" + p.LaPhoto + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Personnel p)
        {
            MySqlCommand cmd;
            String req = "UPDATE PERSONNEL SET nom='" + p.Nom + "', prenom='" + p.Prenom + "', dateNaiss='" + p.DateNaiss + "', lieuNaiss='" + p.LieuNaiss + "', biographie='" + p.Biographie + "', id_NATIONALITE=" + p.LaNationalite.Id + "', id_PHOTO=" + p.LaPhoto.Id + " WHERE mag_num='" + p.Id + "'";

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

        public bool delete(Personnel p)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM PERSONNEL WHERE id='" + p.Id + "'";

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

        public Personnel findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM PERSONNEL WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();


            Personnel p = null;
            string idNationalite = null;
            string idPhoto = null;
            NationaliteDAO nDAO = new NationaliteDAO();
            PhotoDAO pDAO = new PhotoDAO();
            if (dr.Read())
            {//je peux le faire
                idNationalite = dr[6].ToString();
                idPhoto = dr[7].ToString();
                string[] res = dr[3].ToString().Split('/', ':', ' ');
                p = new Personnel(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), res[0]+"/"+res[1]+"/"+res[2], dr[4].ToString(), dr[5].ToString(), null, null);
            }
            dr.Close();
            if (!String.IsNullOrEmpty(idNationalite))
            {

                p.LaNationalite = nDAO.findById(idNationalite.ToString());
            }

            if (!String.IsNullOrEmpty(idPhoto))
            {
                p.LaPhoto = pDAO.findById(idPhoto.ToString());

            }
            return p;
        }

        public List<Personnel> readAll()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            MySqlCommand cmd;
            String req = "SELECT * FROM PERSONNEL";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr2 = cmd.ExecuteReader();
            int c = 0;
            while (dr2.Read())
            {
                c++;
            }
            dr2.Close();
            MySqlDataReader dr = cmd.ExecuteReader();


            NationaliteDAO nDAO = new NationaliteDAO();
            PhotoDAO pDAO = new PhotoDAO();
            string[] idNationalite = new string[c];
            string[] idPhoto = new string[c];
            
            int i = 0;
            while (dr.Read())
            {
                idNationalite[i] = dr[6].ToString();
                idPhoto[i] = dr[7].ToString();
                i++;
                string[] res = dr[3].ToString().Split('/', ':', ' ');
                Personnel p = new Personnel(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), res[0] + "/" + res[1] + "/" + res[2], dr[4].ToString(), dr[5].ToString(), null, null);
                lesPersonnels.Add(p);
            }
            dr.Close();
            
            for (int k = 0; k < i; k++)
            {
                lesPersonnels[k].LaNationalite = nDAO.findById(idNationalite[k]);
                lesPersonnels[k].LaPhoto = pDAO.findById(idPhoto[k]);

            }
            return lesPersonnels;
        }
    }
}