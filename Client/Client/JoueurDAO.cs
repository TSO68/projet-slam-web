using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Client
{
    class JoueurDAO
    {
        private SqlConnection c;

        public JoueurDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Joueur j)
        {
            SqlCommand cmd;
            String req = "INSERT INTO Joueur VALUES ('" + j.Id + "','" + j.Nom + "','" + j.Prenom + "','" + j.DateNaiss + "','" + j.LieuNaiss + "','" + j.Biographie + "')";

            cmd = new SqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Joueur j)
        {
            SqlCommand cmd;
            String req = "UPDATE Joueur SET nom='" + j.Nom + "', prenom='" + j.Prenom + "', dateNaiss='" + j.DateNaiss + "', lieuNaiss='" + j.LieuNaiss + "', biographie='" + j.Biographie + "' WHERE mag_num='" + j.Id + "'";

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

        public bool delete(Joueur j)
        {
            SqlCommand cmd;
            String req = "DELETE FROM Joueur WHERE id='" + j.Id + "'";

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

        public Joueur findById(String code)
        {
            SqlCommand cmd;
            String req = "SELECT * FROM Joueur WHERE id='" + code + "'";
            cmd = new SqlCommand(req, this.c);
            SqlDataReader dr = cmd.ExecuteReader();

            Joueur m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Joueur(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), Convert.ToDateTime(dr[4]), Convert.ToInt32(dr[5]), dr[6].ToString(), dr[7].ToString(), Convert.ToDateTime(dr[8]), dr[9].ToString(), Convert.ToInt32(dr[10]), dr[12].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Joueur> readAll()
        {
            List<Joueur> lesJoueurs = new List<Joueur>();
            SqlCommand cmd;
            String req = "SELECT * FROM Joueur";
            cmd = new SqlCommand(req, this.c);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Joueur mag = new Joueur(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]), Convert.ToInt32(dr[2]), dr[3].ToString(), Convert.ToDateTime(dr[4]), Convert.ToInt32(dr[5]), dr[6].ToString(), dr[7].ToString(), Convert.ToDateTime(dr[8]), dr[9].ToString(), Convert.ToInt32(dr[10]), dr[12].ToString());
                lesJoueurs.Add(mag);
            }
            dr.Close();
            return lesJoueurs;
        }
    }
}
