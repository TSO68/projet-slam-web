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
            String req = "SELECT * FROM PHOTO WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Photo m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Photo(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Photo> readAll()
        {
            List<Photo> lesPhotos = new List<Photo>();
            MySqlCommand cmd;
            String req = "SELECT * FROM PHOTO";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Photo mag = new Photo(Convert.ToInt32(dr[0]), dr[1].ToString());
                lesPhotos.Add(mag);
            }
            dr.Close();
            return lesPhotos;
        }
    }
}
