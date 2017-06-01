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

            Personnel p=null;
            string idNationalite = null;
            NationaliteDAO nDAO = new NationaliteDAO();
            if (dr.Read())
            {//je peux le faire
                idNationalite= dr[6].ToString();
                 p = new Personnel(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDateTime(dr[3]), dr[4].ToString(), dr[5].ToString(), null);
            }
            dr.Close();
            if (!String.IsNullOrEmpty(idNationalite))
            {
                p.Nationalite = nDAO.findById(idNationalite.ToString());
            }
            return p;
        }

        public List<Personnel> readAll()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            MySqlCommand cmd;
            String req = "SELECT * FROM PERSONNEL";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();
            Personnel p;
            NationaliteDAO nDAO = new NationaliteDAO();
            string[] idNationalite = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                System.Diagnostics.Debug.Write("Issou"+req.Count().ToString());
                idNationalite[i] = dr[5].ToString();
                i++;
                p = new Personnel(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), Convert.ToDateTime(dr[3]), dr[4].ToString(), dr[5].ToString(), null);
                lesPersonnels.Add(p);
            }
            dr.Close();
            dr.Dispose();
            for (int k = 0; k < i; k++)
            {
                lesPersonnels[k].Nationalite = nDAO.findById(idNationalite[k]);
            }
            return lesPersonnels;
        }
    }
}
