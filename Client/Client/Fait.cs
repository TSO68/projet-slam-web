using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Fait
    {
        private Produit leProduit;
        private Taille laTaille;

        public Fait(Produit produit, Taille taille)
        {
            this.leProduit = produit;
            this.laTaille = taille;
        }


        public Produit LeProduit
        {
            get
            {
                return leProduit;
            }

            set
            {
                leProduit = value;
            }
        }

        public Taille LaTaille
        {
            get
            {
                return laTaille;
            }

            set
            {
                laTaille = value;
            }
        }
    }
}
