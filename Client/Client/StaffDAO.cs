using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Client
{
    class StaffDAO
    {
        private SqlConnection c;

        public StaffDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Staff s)
        {
            SqlCommand cmd;
            String req = "INSERT INTO Staff VALUES ('" + s.Role + "')";

            cmd = new SqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Staff s)
        {
            SqlCommand cmd;
            String req = "UPDATE Staff SET nom='" + s.Role + "'";

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

        public bool delete(Staff s)
        {
            SqlCommand cmd;
            String req = "DELETE FROM Staff WHERE id='" + s.Id + "'";

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

        public Staff findById(String code)
        {
            SqlCommand cmd;
            String req = "SELECT * FROM Staff WHERE id='" + code + "'";
            cmd = new SqlCommand(req, this.c);
            SqlDataReader dr = cmd.ExecuteReader();

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
            SqlCommand cmd;
            String req = "SELECT * FROM Staff";
            cmd = new SqlCommand(req, this.c);

            SqlDataReader dr = cmd.ExecuteReader();

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
