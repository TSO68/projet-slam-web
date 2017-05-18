﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Client
{
    class PosteDAO
    {
        private SqlConnection c;

        public PosteDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Poste p)
        {
            SqlCommand cmd;
            String req = "INSERT INTO Poste VALUES ('" + p.Id + "','" + p.Libelle + "')";

            cmd = new SqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Poste p)
        {
            SqlCommand cmd;
            String req = "UPDATE Poste SET nom='" + p.Id + "', prenom='" + p.Libelle + "'";

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

        public bool delete(Poste p)
        {
            SqlCommand cmd;
            String req = "DELETE FROM Poste WHERE id='" + p.Id + "'";

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

        public Poste findById(String code)
        {
            SqlCommand cmd;
            String req = "SELECT * FROM Poste WHERE id='" + code + "'";
            cmd = new SqlCommand(req, this.c);
            SqlDataReader dr = cmd.ExecuteReader();

            Poste m = null;
            if (dr.Read())
            {//je peux le faire
                m = new Poste(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            dr.Close();
            return m;
        }

        public List<Poste> readAll()
        {
            List<Poste> lesPostes = new List<Poste>();
            SqlCommand cmd;
            String req = "SELECT * FROM Poste";
            cmd = new SqlCommand(req, this.c);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Poste mag = new Poste(Convert.ToInt32(dr[0]), dr[1].ToString());
                lesPostes.Add(mag);
            }
            dr.Close();
            return lesPostes;
        }
    }
}
