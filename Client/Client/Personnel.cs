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
        private int age;
        private String biographie;

        public Personnel(int id, string nom, string prenom, DateTime dateNaiss, string lieuNaiss, int age, string biographie)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaiss = dateNaiss;
            this.lieuNaiss = lieuNaiss;
            this.age = age;
            this.biographie = biographie;
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
    }
}
