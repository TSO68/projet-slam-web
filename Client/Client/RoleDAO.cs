using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class RoleDAO
    {
        private MySqlConnection c;

        public RoleDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Role r)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO ROLE VALUES ('" + r.Id + "','" + r.Libelle + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Role r)
        {
            MySqlCommand cmd;
            String req = "UPDATE ROLE SET libelle='" + r.Libelle + "' WHERE id='" + r.Id + "'";

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

        public bool delete(Role r)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM ROLE WHERE id='" + r.Id + "'";

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

        public Role findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM ROLE WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            Role m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Role(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Role> readAll()
        {
            List<Role> lesRoles = new List<Role>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ROLE";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Role mag = new Role(Convert.ToInt32(dr[0]), dr[1].ToString());
                lesRoles.Add(mag);
            }
            dr.Close();
            return lesRoles;
        }
    }
}
