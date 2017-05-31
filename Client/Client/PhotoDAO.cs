using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class PhotoDAO
    {
        private MySqlConnection c;

        public PhotoDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Photo p)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO PHOTO VALUES ('" + p.Id + "','" + p.Lien +"')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Photo p)
        {
            MySqlCommand cmd;
            String req = "UPDATE PHOTO SET lien='" + p.Lien + "' WHERE id='" + p.Id + "'";

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

        public bool delete(Photo p)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM PHOTO WHERE id='" + p.Id + "'";

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

        public Photo findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT PHOTO.id, lien, PERSONNEL.id_PHOTO, PRODUIT.id_PHOTO FROM PHOTO LEFT OUTER JOIN PERSONNEL ON PHOTO.id = PERSONNEL.id_PHOTO LEFT OUTER JOIN PRODUIT ON PHOTO.id = PRODUIT.id_PHOTO WHERE PHOTO.id='" + code + "' AND (PHOTO.id = PERSONNEL.id_PHOTO OR PHOTO.id = PRODUIT.id_PHOTO)";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Photo m = null;
            string idPersonnel = null;
            string idProduit = null;
            PersonnelDAO peDAO = new PersonnelDAO();
            ProduitDAO prDAO = new ProduitDAO();

            if (dr.Read())
            {//je peux le faire
                System.Diagnostics.Debug.Write(dr[0]);
                System.Diagnostics.Debug.Write(dr[1]);
                System.Diagnostics.Debug.Write(dr[2]);
                System.Diagnostics.Debug.Write(dr[3]);
                idPersonnel = dr[2].ToString();
                idProduit = dr[3].ToString();
                m = new Photo(Convert.ToInt32(dr[0]), dr[1].ToString(), null, null);
            }
            dr.Close();
            if (!String.IsNullOrEmpty(idPersonnel))
            {
                m.LePersonnel = peDAO.findById(idPersonnel.ToString());
            }

            if (!String.IsNullOrEmpty(idProduit))
            {
                m.LeProduit = prDAO.findById(idProduit.ToString());
            }
            return m;

        }

        public List<Photo> readAll()
        {
            List<Photo> lesPhotos = new List<Photo>();
            MySqlCommand cmd;
            String req = "SELECT PHOTO.id, lien, PERSONNEL.id_PHOTO, PRODUIT.id_PHOTO FROM PHOTO LEFT OUTER JOIN PERSONNEL ON PHOTO.id = PERSONNEL.id_PHOTO LEFT OUTER JOIN PRODUIT ON PHOTO.id = PRODUIT.id_PHOTO WHERE PHOTO.id = PERSONNEL.id_PHOTO OR PHOTO.id = PRODUIT.id_PHOTO";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();
            PersonnelDAO peDAO = new PersonnelDAO();
            ProduitDAO prDAO = new ProduitDAO();
            string[] idPersonnel = new string[req.Count()];
            string[] idProduit = new string[req.Count()];
            int i = 0;

            while (dr.Read())
            {
                idPersonnel[i] = dr[2].ToString();
                idProduit[i] = dr[3].ToString();
                i++;
                Photo mag = new Photo(Convert.ToInt32(dr[0]), dr[1].ToString(), null, null);
                lesPhotos.Add(mag);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                lesPhotos[k].LePersonnel = peDAO.findById(idPersonnel[k]);
                lesPhotos[k].LeProduit = prDAO.findById(idProduit[k]);
            }
            return lesPhotos;
        }
    }
}
