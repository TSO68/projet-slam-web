using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Client
{
    class PersonnelDAO
    {
        private SqlConnection c;

        public PersonnelDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Personnel p)
        {
            SqlCommand cmd;
            String req = "INSERT INTO Personnel VALUES ('" + p.Id + "','" + p.Nom + "','" + p.Prenom + "','" + p.DateNaiss + "','" + p.LieuNaiss + "','" + p.Biographie + "')";

            cmd = new SqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Personnel p)
        {
            SqlCommand cmd;
            String req = "UPDATE Personnel SET nom='" + p.Nom + "', prenom='" + p.Prenom + "', dateNaiss='" + p.DateNaiss + "', lieuNaiss='" + p.LieuNaiss + "', biographie='" + p.Biographie + "' WHERE mag_num='" + p.Id + "'";

            cmd = new SqlCommand(req, this.c);
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
            SqlCommand cmd;
            String req = "DELETE FROM Personnel WHERE id='" + p.Id + "'";

            cmd = new SqlCommand(req, this.c);
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
            SqlCommand cmd;
            String req = "SELECT * FROM Personnel WHERE id='" + code + "'";
            cmd = new SqlCommand(req, this.c);
            SqlDataReader dr = cmd.ExecuteReader();

            Personnel m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Personnel(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDateTime(dr[3]), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Personnel> readAll()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            SqlCommand cmd;
            String req = "SELECT * FROM Personnel";
            cmd = new SqlCommand(req, this.c);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Personnel mag = new Personnel(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDateTime(dr[3]), dr[4].ToString(), dr[5].ToString());
                lesPersonnels.Add(mag);
            }
            dr.Close();
            return lesPersonnels;
        }
    }
}
