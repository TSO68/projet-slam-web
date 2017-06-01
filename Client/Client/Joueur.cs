using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Joueur : Personnel
    {
        private int num;
        private float taille;
        private float poids;
        private String pied;
        private String dateVenueClub;

        private Poste lePoste;
        

        public Joueur(int num, float taille, float poids, string pied, String dateVenueClub,Poste poste, int id, String nom, String prenom, DateTime dateNaiss, String lieuNaiss, String biographie, Nationalite nationalite) : base(id, nom,prenom,dateNaiss,lieuNaiss, biographie, nationalite)
        {
            this.num = num;
            this.taille = taille;
            this.poids = poids;
            this.pied = pied;
            this.dateVenueClub = dateVenueClub;
            this.lePoste = poste;


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

        public String DateVenueClub
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

        public Poste LePoste
        {
            get
            {
                return lePoste;
            }

            set
            {
                lePoste = value;
            }
        }
    }
}