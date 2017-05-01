using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Joueur
    {
        private int id;
        private String nom;
        private String prenom;
        private DateTime dateNaiss;
        private String lieuNaiss;
        private int age;
        private String biographie;
        private int num;
        private float taille;
        private float poids;
        private String pied;
        private DateTime dateVenueClub;

        public Joueur(int id, string nom, string prenom, DateTime dateNaiss, string lieuNaiss, int age, string biographie, int num, float taille, float poids, string pied, DateTime dateVenueClub)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaiss = dateNaiss;
            this.lieuNaiss = lieuNaiss;
            this.age = age;
            this.biographie = biographie;
            this.num = num;
            this.taille = taille;
            this.poids = poids;
            this.pied = pied;
            this.dateVenueClub = dateVenueClub;
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

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
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

        public int Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }
        }

        public float Taille
        {
            get
            {
                return taille;
            }

            set
            {
                taille = value;
            }
        }

        public float Poids
        {
            get
            {
                return poids;
            }

            set
            {
                poids = value;
            }
        }

        public string Pied
        {
            get
            {
                return pied;
            }

            set
            {
                pied = value;
            }
        }

        public DateTime DateVenueClub
        {
            get
            {
                return dateVenueClub;
            }

            set
            {
                dateVenueClub = value;
            }
        }
        

    }
}