using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Adversaire
    {
        private int id;
        private String libelle;
        private String logo;

        public Adversaire(int id, string libelle, string logo)
        {
            this.id = id;
            this.libelle = libelle;
            this.logo = logo;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Libelle
        {
            get
            {
                return libelle;
            }

            set
            {
                libelle = value;
            }
        }

        public string Logo
        {
            get
            {
                return logo;
            }

            set
            {
                logo = value;
            }
        }
    }
}
