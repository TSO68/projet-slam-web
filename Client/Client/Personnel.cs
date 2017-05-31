using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Personnel
    {
        private int id;
        private String nom;
        private String prenom;
        private string dateNaiss;
        private String lieuNaiss;
        private String biographie;
        private Nationalite laNationalite;
        private Photo laPhoto;

        public Personnel(int id, string nom, string prenom, string dateNaiss, string lieuNaiss, string biographie, Nationalite n, Photo p)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaiss = dateNaiss;
            this.lieuNaiss = lieuNaiss;
            this.biographie = biographie;
            this.laNationalite = n;
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

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public string DateNaiss
        {
            get
            {
                return dateNaiss;
            }

            set
            {
                dateNaiss = value;
            }
        }

        public string LieuNaiss
        {
            get
            {
                return lieuNaiss;
            }

            set
            {
                lieuNaiss = value;
            }
        }

        public string Biographie
        {
            get
            {
                return biographie;
            }

            set
            {
                biographie = value;
            }
        }
        public Nationalite LaNationalite
        {
            get
            {
                return laNationalite;
            }

            set
            {
                laNationalite = value;
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
