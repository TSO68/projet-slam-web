using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class ligneCmd
    {
        private Produit leProduit;
        private Taille laTaille;
        private Commande laCommande;
        private int quantite;

        public ligneCmd(Produit p, Taille t, Commande c, int q)
        {
            this.leProduit = p;
            this.laTaille = t;
            this.laCommande = c;
            this.quantite = q;
        }

        public int Quantite
        {
            get
            {
                return quantite;
            }

            set
            {
                quantite = value;
            }
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

        public Commande LaCommande
        {
            get
            {
                return laCommande;
            }

            set
            {
                laCommande = value;
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
