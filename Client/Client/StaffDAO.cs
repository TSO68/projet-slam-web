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
            String req = "SELECT * FROM STAFF WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Staff m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Staff(dr[0].ToString(), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), Convert.ToDateTime(dr[4]), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Staff> readAll()
        {
            List<Staff> lesStaffs = new List<Staff>();
            MySqlCommand cmd;
            String req = "SELECT * FROM STAFF";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Staff mag = new Staff(dr[0].ToString(), Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), Convert.ToDateTime(dr[4]), dr[5].ToString(), dr[6].ToString());
                lesStaffs.Add(mag);
            }
            dr.Close();
            return lesStaffs;
        }
    }
}
