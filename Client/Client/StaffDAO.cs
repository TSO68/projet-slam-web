using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Client
{
    class StaffDAO
    {
        private MySqlConnection c;

        public StaffDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Staff s)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO STAFF VALUES ('" + s.Role + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Staff s)
        {
            MySqlCommand cmd;
            String req = "UPDATE STAFF SET nom='" + s.Role + "'";

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

        public bool delete(Staff s)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM STAFF WHERE id='" + s.Id + "'";

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

        public Staff findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT STAFF.id,id_ROLE,nom,prenom,dateNaiss,lieuNaiss,biographie,id_NATIONALITE,id_PHOTO FROM STAFF INNER JOIN PERSONNEL ON STAFF.id = PERSONNEL.id  WHERE STAFF.id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Staff m = null;
            string idNationalite=null;
            string idRole = null;
            NationaliteDAO nDAO = new NationaliteDAO();
            RoleDAO rDAO = new RoleDAO();
            if (dr.Read())
            {//je peux le faire
                idNationalite = dr[7].ToString();
                idRole = dr[8].ToString();
                m = new Staff(dr[0].ToString(), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), Convert.ToDateTime(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(),null,null);
            }
            dr.Close();
            if (!String.IsNullOrEmpty(idNationalite))
            {
                m.Nationalite = nDAO.findById(idNationalite.ToString());
            }

            if (!String.IsNullOrEmpty(idRole))
            {
                m.Role = rDAO.findById(idRole.ToString());
            }
            return m;
        }

        public List<Staff> readAll()
        {
            List<Staff> lesStaffs = new List<Staff>();
            MySqlCommand cmd;
            String req = "SELECT * FROM STAFF";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            RoleDAO rDAO = new RoleDAO();
            NationaliteDAO nDAO = new NationaliteDAO();
            string[] idNationalite = new string[req.Count()];
            string[] idRole = new string[req.Count()];
            int i = 0;

            while (dr.Read())
            {
                idNationalite[i] = dr[7].ToString();
                idRole[i] = dr[8].ToString();
                i++;
                Staff mag = new Staff(dr[0].ToString(), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), Convert.ToDateTime(dr[4]), dr[5].ToString(), dr[6].ToString(),null,null);
                lesStaffs.Add(mag);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                lesStaffs[k].Nationalite = nDAO.findById(idNationalite[k]);
                lesStaffs[k].Role = rDAO.findById(idRole[k]);
            }
            return lesStaffs;
        }
    }
}
