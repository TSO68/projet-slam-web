using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ligneCmdDAO
    {
        private MySqlConnection c;

        public ligneCmdDAO()
        {
            this.c = Connexion.getIntstance();
        }

        public void create(ligneCmd l)
        {
            MySqlCommand cmd;
            String req = "INSERT INTO ligneCmd VALUES ('" + l.LeProduit.Id+", " + l.LaTaille.Id + ", " +l.LaCommande.Id+ ", " +l.Quantite+ "')";

            cmd = new MySqlCommand(req, this.c);
            cmd.ExecuteNonQuery();

        }

        public bool update(ligneCmd l)
        {
            MySqlCommand cmd;
            String req = "UPDATE ligneCmd SET id_PRODUIT='" + l.LeProduit.Id + "', id_TAILLE='" + l.LaTaille.Id + "', id_COMMANDE='" + l.LaCommande.Id + "', quantite='" + l.Quantite + "'  WHERE id_PRODUIT='" + l.LeProduit.Id + " AND id_TAILLE=" + l.LaTaille.Id + " AND id_COMMANDE=" + l.LaCommande.Id + "";

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

        public bool delete(ligneCmd l)
        {
            MySqlCommand cmd;
            String req = "DELETE FROM ligneCmd WHERE id_PRODUIT='" + l.LeProduit.Id + " OR id_TAILLE=" + l.LaTaille.Id + " OR id_COMMANDE=" + l.LaCommande.Id + "";

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

        public List<ligneCmd> findByIdProduit(String code)
        {
            List<ligneCmd> leslignesCmd = new List<ligneCmd>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ligneCmd WHERE id_PRODUIT='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            ProduitDAO pDAO = new ProduitDAO();
            TailleDAO tDAO = new TailleDAO();
            CommandeDAO cDAO = new CommandeDAO();
            string[] idProduit= new string[req.Count()];
            string[] idTaille = new string[req.Count()];
            string[] idCommande = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idProduit[i] = dr[0].ToString();
                idTaille[i] = dr[1].ToString();
                idCommande[i] = dr[2].ToString();
                i++;
                ligneCmd l = new ligneCmd(null, null, null, Convert.ToInt32(dr[3]));
                leslignesCmd.Add(l);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                leslignesCmd[k].LeProduit = pDAO.findById(idProduit[k]);
                leslignesCmd[k].LaTaille = tDAO.findById(idTaille[k]);
                leslignesCmd[k].LaCommande = cDAO.findById(idCommande[k]);
            }
            return leslignesCmd;
        }

        public List<ligneCmd> findByIdTaille(String code)
        {
            List<ligneCmd> leslignesCmd = new List<ligneCmd>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ligneCmd WHERE id_TAILLE='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            ProduitDAO pDAO = new ProduitDAO();
            TailleDAO tDAO = new TailleDAO();
            CommandeDAO cDAO = new CommandeDAO();
            string[] idProduit = new string[req.Count()];
            string[] idTaille = new string[req.Count()];
            string[] idCommande = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idProduit[i] = dr[0].ToString();
                idTaille[i] = dr[1].ToString();
                idCommande[i] = dr[2].ToString();
                i++;
                ligneCmd l = new ligneCmd(null, null, null, Convert.ToInt32(dr[3]));
                leslignesCmd.Add(l);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                leslignesCmd[k].LeProduit = pDAO.findById(idProduit[k]);
                leslignesCmd[k].LaTaille = tDAO.findById(idTaille[k]);
                leslignesCmd[k].LaCommande = cDAO.findById(idCommande[k]);
            }
            return leslignesCmd;
        }

        public List<ligneCmd> findByIdCommande(String code)
        {
            List<ligneCmd> leslignesCmd = new List<ligneCmd>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ligneCmd WHERE id_COMMANDE='" + code + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            ProduitDAO pDAO = new ProduitDAO();
            TailleDAO tDAO = new TailleDAO();
            CommandeDAO cDAO = new CommandeDAO();
            string[] idProduit = new string[req.Count()];
            string[] idTaille = new string[req.Count()];
            string[] idCommande = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idProduit[i] = dr[0].ToString();
                idTaille[i] = dr[1].ToString();
                idCommande[i] = dr[2].ToString();
                i++;
                ligneCmd l = new ligneCmd(null, null, null, Convert.ToInt32(dr[3]));
                leslignesCmd.Add(l);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                leslignesCmd[k].LeProduit = pDAO.findById(idProduit[k]);
                leslignesCmd[k].LaTaille = tDAO.findById(idTaille[k]);
                leslignesCmd[k].LaCommande = cDAO.findById(idCommande[k]);
            }
            return leslignesCmd;
        }
        public List<ligneCmd> findByIdCommandeEtProduit(String code, String a)
        {
            List<ligneCmd> leslignesCmd = new List<ligneCmd>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ligneCmd WHERE id_COMMANDE='" + code + "' AND id_PRODUIT='" + a + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            ProduitDAO pDAO = new ProduitDAO();
            TailleDAO tDAO = new TailleDAO();
            CommandeDAO cDAO = new CommandeDAO();
            string[] idProduit = new string[req.Count()];
            string[] idTaille = new string[req.Count()];
            string[] idCommande = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idProduit[i] = dr[0].ToString();
                idTaille[i] = dr[1].ToString();
                idCommande[i] = dr[2].ToString();
                i++;
                ligneCmd l = new ligneCmd(null, null, null, Convert.ToInt32(dr[3]));
                leslignesCmd.Add(l);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                leslignesCmd[k].LeProduit = pDAO.findById(idProduit[k]);
                leslignesCmd[k].LaTaille = tDAO.findById(idTaille[k]);
                leslignesCmd[k].LaCommande = cDAO.findById(idCommande[k]);
            }
            return leslignesCmd;
        }
        public List<ligneCmd> findByIdTailleEtProduit(String code, String a)
        {
            List<ligneCmd> leslignesCmd = new List<ligneCmd>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ligneCmd WHERE id_TAILLE='" + code + "' AND id_PRODUIT='" + a + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            ProduitDAO pDAO = new ProduitDAO();
            TailleDAO tDAO = new TailleDAO();
            CommandeDAO cDAO = new CommandeDAO();
            string[] idProduit = new string[req.Count()];
            string[] idTaille = new string[req.Count()];
            string[] idCommande = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idProduit[i] = dr[0].ToString();
                idTaille[i] = dr[1].ToString();
                idCommande[i] = dr[2].ToString();
                i++;
                ligneCmd l = new ligneCmd(null, null, null, Convert.ToInt32(dr[3]));
                leslignesCmd.Add(l);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                leslignesCmd[k].LeProduit = pDAO.findById(idProduit[k]);
                leslignesCmd[k].LaTaille = tDAO.findById(idTaille[k]);
                leslignesCmd[k].LaCommande = cDAO.findById(idCommande[k]);
            }
            return leslignesCmd;
        }
        public List<ligneCmd> findByIdCommandeEtTaille(String code, String a)
        {
            List<ligneCmd> leslignesCmd = new List<ligneCmd>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ligneCmd WHERE id_COMMANDE='" + code + "' AND id_TAILLE='" + a + "'";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            ProduitDAO pDAO = new ProduitDAO();
            TailleDAO tDAO = new TailleDAO();
            CommandeDAO cDAO = new CommandeDAO();
            string[] idProduit = new string[req.Count()];
            string[] idTaille = new string[req.Count()];
            string[] idCommande = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idProduit[i] = dr[0].ToString();
                idTaille[i] = dr[1].ToString();
                idCommande[i] = dr[2].ToString();
                i++;
                ligneCmd l = new ligneCmd(null, null, null, Convert.ToInt32(dr[3]));
                leslignesCmd.Add(l);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                leslignesCmd[k].LeProduit = pDAO.findById(idProduit[k]);
                leslignesCmd[k].LaTaille = tDAO.findById(idTaille[k]);
                leslignesCmd[k].LaCommande = cDAO.findById(idCommande[k]);
            }
            return leslignesCmd;
        }
        public List<ligneCmd> readAll()
        {
            List<ligneCmd> leslignesCmd = new List<ligneCmd>();
            MySqlCommand cmd;
            String req = "SELECT * FROM ligneCmd";
            cmd = new MySqlCommand(req, this.c);
            MySqlDataReader dr = cmd.ExecuteReader();

            ProduitDAO pDAO = new ProduitDAO();
            TailleDAO tDAO = new TailleDAO();
            CommandeDAO cDAO = new CommandeDAO();
            string[] idProduit = new string[req.Count()];
            string[] idTaille = new string[req.Count()];
            string[] idCommande = new string[req.Count()];
            int i = 0;
            while (dr.Read())
            {
                idProduit[i] = dr[0].ToString();
                idTaille[i] = dr[1].ToString();
                idCommande[i] = dr[2].ToString();
                i++;
                ligneCmd l = new ligneCmd(null, null, null, Convert.ToInt32(dr[3]));
                leslignesCmd.Add(l);
            }
            dr.Close();
            for (int k = 0; k < i; k++)
            {
                leslignesCmd[k].LeProduit = pDAO.findById(idProduit[k]);
                leslignesCmd[k].LaTaille = tDAO.findById(idTaille[k]);
                leslignesCmd[k].LaCommande = cDAO.findById(idCommande[k]);
            }
            return leslignesCmd;
        }
    }
}
