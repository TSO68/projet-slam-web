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
        private DateTime dateNaiss;
        private String lieuNaiss;
        private String biographie;
        private Nationalite nationalite;

        public Personnel(int id, string nom, string prenom, DateTime dateNaiss, string lieuNaiss, string biographie, Nationalite nationalite)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaiss = dateNaiss;
            this.lieuNaiss = lieuNaiss;
            this.biographie = biographie;
            this.Nationalite = nationalite;
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

        public DateTime DateNaiss
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

        internal Nationalite Nationalite
        {
            get
            {
                return nationalite;
            }

            set
            {
                nationalite = value;
            }
        }
    }
}
