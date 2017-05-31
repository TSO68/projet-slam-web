using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Commande
    {
        private string id;
        private DateTime dateCommande;

        private int leCompte;

        public Commande(string id, DateTime dateCommande, int compte)
        {
            this.id = id;
            this.dateCommande = dateCommande;
            this.leCompte = compte;
        }

        public string Id
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

        public DateTime DateCommande
        {
            get
            {
                return dateCommande;
            }

            set
            {
                dateCommande = value;
            }
        }

        public int LeCompte
        {
            get
            {
                return leCompte;
            }

            set
            {
                leCompte = value;
            }
        }
    }
}
