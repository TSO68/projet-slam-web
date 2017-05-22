using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Commande
    {
        private int id;
        private DateTime dateCommande;

        public Commande(int id, DateTime dateCommande)
        {
            this.id = id;
            this.dateCommande = dateCommande;
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
    }
}
