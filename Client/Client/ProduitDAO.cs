using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Client
{
    class ProduitDAO
    {
        private MySqlConnection c;

        public ProduitDAO()
        {
            this.c = Connexion.getIntstance();
        }



        public void create(Produit p)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO PRODUIT VALUES ('" + p.Id + "','" + p.Nom + "','" + p.Prix + "','" + p.Description + "','" + p.LaPhoto.Id + "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(Produit p)
        {
            MySqlCommand cmd;
            String req = "UPDATE PRODUIT SET nom='" + p.Nom + "', id="+p.Id+ ", prix="+p.Prix+", description='"+p.Description+"', id_PHOTO="+p.LaPhoto.Id+" WHERE id='" + p.Id + "'";

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

        public bool delete(Produit p)
        {
            MySqlCommand cmd;
            MySqlCommand cmd2;
            MySqlCommand cmd3;
            String req3 = "DELETE FROM ligneCmd WHERE id_PRODUIT=" + p.Id;
            String req2 = "DELETE FROM fait WHERE id=" + p.Id;
            String req = "DELETE FROM PRODUIT WHERE id=" + p.Id;

            cmd2 = new MySqlCommand(req2, this.c);
            cmd3 = new MySqlCommand(req3, this.c);
            cmd = new MySqlCommand(req, this.c);
            int nb = cmd3.ExecuteNonQuery() + cmd2.ExecuteNonQuery() + cmd.ExecuteNonQuery();
            if (nb != 0)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public Produit findById(String code)
        {
            MySqlCommand cmd;
            String req = "SELECT * FROM PRODUIT WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            PhotoDAO pDAO = new PhotoDAO();
            Produit p = null;
            string idPhoto = null;
            
            if (dr.Read())
            {//je peux le faire
                idPhoto = dr[4].ToString();
                p = new Produit(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]),dr[3].ToString(), null);
            }
            dr.Close(); // On coupte la connexion
            dr.Dispose();
            if (!String.IsNullOrEmpty(idPhoto)) // Si idPoste n'est pas null
            {
                p.LaPhoto = pDAO.findById(idPhoto); // On attribue le poste au joueur
            }
            return p;
        }

        public List<Produit> readAll()
        {
            List<Produit> lesProduits = new List<Produit>();
            MySqlCommand cmd;
            String req = "SELECT * FROM PRODUIT";
            cmd = new MySqlCommand(req, this.c);

            MySqlDataReader dr = cmd.ExecuteReader();
            PhotoDAO pDAO = new PhotoDAO();

            Produit p = null;
            string[] idPhoto = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idPhoto[i] = dr[4].ToString();
                i++;
                p = new Produit(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]), dr[3].ToString(), null);
                lesProduits.Add(p);
            }
            dr.Close();
            dr.Dispose();
            for (int k = 0; k < i; k++)
            {
                lesProduits[k].LaPhoto = pDAO.findById(idPhoto[k]);
            }
            return lesProduits;
        }
    }
}
