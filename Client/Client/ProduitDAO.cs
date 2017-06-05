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



        public bool create(Produit p)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO PRODUIT VALUES ('" + p.Id + "','" + p.Nom + "','" + p.Prix.ToString().Replace(',', '.') + "','" + p.Description + "','" + p.LaPhoto.Id + "')";

            cmd = new MySqlCommand(req, this.c);
            int nb = cmd.ExecuteNonQuery();
            
            string[] res = p.IdTaille.Split(',');
            FaitDAO fDAO = new FaitDAO();
            TailleDAO tDAO = new TailleDAO();
            for (int i = 0; i < res.Count(); i++)
            {
                Fait f = new Fait(p, tDAO.findById(res[i]));
                fDAO.create(f);
            }

            if (nb != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool update(Produit p)
        {
            MySqlCommand cmd;
            String req = "UPDATE PRODUIT SET nom='" + p.Nom + "', id="+p.Id+ ", prix="+p.Prix.ToString().Replace(',', '.') + ", description='"+p.Description+"', id_PHOTO="+p.LaPhoto.Id+" WHERE id='" + p.Id + "'";

            cmd = new MySqlCommand(req, this.c);
            int nb = cmd.ExecuteNonQuery();

            string[] res = p.IdTaille.Split(',');
            FaitDAO fDAO = new FaitDAO();
            TailleDAO tDAO = new TailleDAO();

            for (int i = 0; i < res.Count(); i++)
            {
                Fait f = new Fait(p, tDAO.findById(res[i]));
                fDAO.delete(f);
            }

            for (int i2 = 0; i2 < res.Count(); i2++)
            {
                Fait f2 = new Fait(p, tDAO.findById(res[i2]));
                fDAO.create(f2);
            }

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
            String req2 = "";
            try
            {
                req2 = "DELETE FROM ligneCmd WHERE id_PRODUIT=" + p.Id;
            }
            catch
            {

            }
            cmd2 = new MySqlCommand(req2, this.c);

            String req = "DELETE FROM PRODUIT WHERE id=" + p.Id;

            string[] res = p.IdTaille.Split(',');
            FaitDAO fDAO = new FaitDAO();
            TailleDAO tDAO = new TailleDAO();

            for (int i = 0; i < res.Count(); i++)
            {
                Fait f = new Fait(p, tDAO.findById(res[i]));
                fDAO.delete(f);
            }

            cmd = new MySqlCommand(req, this.c);

            int nb = cmd2.ExecuteNonQuery();
            int nb2 = cmd.ExecuteNonQuery();
            if (nb != 0 || nb2 !=0 )
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
            MySqlCommand cmd, cmd2;
            String req = "SELECT * FROM PRODUIT WHERE PRODUIT.id='" + code + "'";
            String req2 = "SELECT id_TAILLE FROM fait WHERE id='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            cmd2 = new MySqlCommand(req2, this.c);
            MySqlDataReader dr2 = cmd2.ExecuteReader();

            PhotoDAO pDAO = new PhotoDAO();
            Produit p = null;
            string idPhoto = null;
            string res = "";
            
            while (dr2.Read())
            {//je peux le faire
                res = dr2[0].ToString() + ",";
                
            }
            dr2.Close(); // On coupte la connexion

            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                idPhoto = dr[4].ToString();
                p = new Produit(Convert.ToInt32(dr[0]), dr[1].ToString(), float.Parse(dr[2].ToString()), dr[3].ToString(), null, res);
            }
            dr.Close();
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
                p = new Produit(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]), dr[3].ToString(), null, p.IdTaille);
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
