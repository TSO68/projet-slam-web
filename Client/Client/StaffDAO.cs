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
            String req = "INSERT INTO STAFF VALUES ('" + s.LeRole.Id + "')";

            Personnel p = new Personnel(s.Id, s.Nom, s.Prenom, s.DateNaiss, s.LieuNaiss, s.Biographie, s.LaNationalite, s.LaPhoto);
            PersonnelDAO pDAO = new PersonnelDAO();
            pDAO.create(p);

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Staff s)
        {
            MySqlCommand cmd;
            String req = "UPDATE STAFF SET id_ROLE='" + s.LeRole.Id + "'";

            Personnel p = new Personnel(s.Id, s.Nom, s.Prenom, s.DateNaiss, s.LieuNaiss, s.Biographie, s.LaNationalite, s.LaPhoto);
            PersonnelDAO pDAO = new PersonnelDAO();
            pDAO.update(p);

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
            MySqlCommand cmd2;
            String req = "DELETE FROM STAFF WHERE id='" + s.Id + "'";
            String req2 = "DELETE FROM PERSONNEL WHERE id='" + s.Id + "'";

            

            cmd = new MySqlCommand(req, this.c);
            cmd2 = new MySqlCommand(req2, this.c);
            int nb = cmd.ExecuteNonQuery() + cmd2.ExecuteNonQuery();
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

            String req = "SELECT PERSONNEL.id, id_ROLE, nom, prenom, dateNaiss, lieuNaiss, biographie, id_NATIONALITE, id_PHOTO FROM STAFF INNER JOIN PERSONNEL ON PERSONNEL.id=STAFF.id WHERE PERSONNEL.id='" + code + "'";

            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            PhotoDAO phDAO = new PhotoDAO();
            NationaliteDAO nDAO = new NationaliteDAO();
            RoleDAO rDAO = new RoleDAO();
            string idNationalite = null;
            string idPhoto = null;
            string idRole = null;
            Staff m = null;

            

            
            if (dr.Read())
            {//je peux le faire
                idNationalite = dr[7].ToString();

                idPhoto = dr[8].ToString();
                idRole = dr[0].ToString();
                string[] res = dr[4].ToString().Split('/', ':', ' ');
                m = new Staff(null, Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), res[0] + "/" + res[1] + "/" + res[2], dr[5].ToString(), dr[6].ToString(), null, null);
            }
            dr.Close();
            if (!String.IsNullOrEmpty(idRole)) // Si idPoste n'est pas null
            {
                m.LeRole = rDAO.findById(idRole); // On attribue le poste au joueur
            }
            if (!String.IsNullOrEmpty(idNationalite)) // Si idPoste n'est pas null
            {
                m.LaNationalite = nDAO.findById(idNationalite); // On attribue le poste au joueur
            }
            if (!String.IsNullOrEmpty(idPhoto)) // Si idPoste n'est pas null
            {
                m.LaPhoto = phDAO.findById(idPhoto); // On attribue le poste au joueur

            }
            return m;
            
        }

        public List<Staff> readAll()
        {
            List<Staff> lesStaffs = new List<Staff>();
            MySqlCommand cmd;
            String req = "SELECT PERSONNEL.id, id_ROLE, nom, prenom, dateNaiss, lieuNaiss, biographie, id_NATIONALITE, id_PHOTO FROM STAFF INNER JOIN PERSONNEL ON PERSONNEL.id=STAFF.id";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();


            RoleDAO pDAO = new RoleDAO();
            PhotoDAO phDAO = new PhotoDAO();
            NationaliteDAO nDAO = new NationaliteDAO();
            
            string[] idRole = new string[req.Count()];
            string[] idNationalite = new string[req.Count()];
            string[] idPhoto = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idRole[i] = dr[0].ToString();
                idNationalite[i] = dr[7].ToString();
                idPhoto[i] = dr[8].ToString();
                i++;
                string[] res = dr[4].ToString().Split('/', ':', ' ');
                Staff mag = new Staff(null, Convert.ToInt32(dr[1]), dr[2].ToString(), dr[3].ToString(), res[0] + "/" + res[1] + "/" + res[2], dr[5].ToString(), dr[6].ToString(), null, null);

                lesStaffs.Add(mag);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {

                lesStaffs[k].LeRole = pDAO.findById(idRole[k]);
                lesStaffs[k].LaNationalite = nDAO.findById(idNationalite[k]);
                lesStaffs[k].LaPhoto = phDAO.findById(idPhoto[k]);

            }
            return lesStaffs;
        }
    }
}
