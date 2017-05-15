using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //bibliothèques à importer
using System.Data.Odbc;
using System.Data.OleDb;

namespace Client
{
    class Connexion
    {
        private static SqlConnection c;
        private Connexion() { } // Constructeur privé vide

        public static SqlConnection getIntstance()
        {
            if (c == null)
            {
                String chaineDeConnexion;
                chaineDeConnexion = "Data Source front-ha-mysql-01.shpv.fr;"
                 +
                "Initial Catalog=rnsycxun_projet_slam_bdd;"
                 +
                "User ID=rnsycxun_root;"
                 +
                "Password=admin68";
                c = new SqlConnection(chaineDeConnexion);
                c.Open();

            }
            return c;
        }
    }
}
