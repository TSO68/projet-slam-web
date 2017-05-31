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
            String req = "INSERT INTO PERSONNEL VALUES ('" + p.Id + "','" + p.Nom + "','" + p.Prenom + "','" + p.DateNaiss + "','" + p.LieuNaiss + "','" + p.Biographie + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Personnel p)
        {
            MySqlCommand cmd;
            String req = "UPDATE PERSONNEL SET nom='" + p.Nom + "', prenom='" + p.Prenom + "', dateNaiss='" + p.DateNaiss + "', lieuNaiss='" + p.LieuNaiss + "', biographie='" + p.Biographie + "' WHERE mag_num='" + p.Id + "'";

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
            MySqlCommand cmd;
            String req = "SELECT * FROM PERSONNEL";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

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