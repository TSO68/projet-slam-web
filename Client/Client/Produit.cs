using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Produit
    {
        private int id;
        private String nom;
        private float prix;
        private String description;
        private Photo laPhoto;

        public Produit(int id, string nom, float prix, string description, Photo p)
        {
            this.id = id;
            this.nom = nom;
            this.prix = prix;
            this.description = description;
            this.laPhoto = p;
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

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public float Prix
        {
            get
            {
                return prix;
            }

            set
            {
                prix = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public Photo LaPhoto
        {
            get
            {
                return laPhoto;
            }

            set
            {
                laPhoto = value;
            }
        }
    }
}
