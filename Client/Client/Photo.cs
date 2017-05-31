using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Photo
    {
        private int id;
        private String lien;

        private Personnel lePersonnel;
        private Produit leProduit;

        public Photo(int id, string lien, Personnel personnel, Produit produit)
        {
            this.id = id;
            this.lien = lien;
            this.lePersonnel = personnel;
            this.leProduit = produit;
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

        public string Lien
        {
            get
            {
                return lien;
            }

            set
            {
                lien = value;
            }
        }

        public Personnel LePersonnel
        {
            get
            {
                return lePersonnel;
            }

            set
            {
                lePersonnel = value;
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
    }
}
