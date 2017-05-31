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
        private Stade leStade;

        public Adversaire(int id, string libelle, string logo, Stade s)
        {
            this.id = id;
            this.libelle = libelle;
            this.logo = logo;
            this.leStade = s;
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
        public Stade LeStade
        {
            get
            {
                return leStade;
            }

            set
            {
                leStade = value;
            }
        }
    }
}
