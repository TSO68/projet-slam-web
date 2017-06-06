using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //bibliothèques à importer
using System.Data.Odbc;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace Client
{
    class Connexion
    {
        private static MySqlConnection c;
        private Connexion() { } // Constructeur privé vide

        public static MySqlConnection getIntstance()
        {
            if (c == null)
            {
                String chaineDeConnexion;
                chaineDeConnexion = "server=front-ha-mysql-01.shpv.fr;" // serveur
                 +
                "database=rnsycxun_projet_slam_bdd_samy;" // nom de la base de données
                 +
                "uid=rnsycxun_root;" // nom de compte
                 +
                "pwd=admin68;"; // mot de passe
                c = new MySqlConnection(chaineDeConnexion);
                try
                {
                    c.Open();
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("ERREUR : La connexion SQL n'a pas pu être établie.");
                }
                

            }
            return c;
        }
    }
}
