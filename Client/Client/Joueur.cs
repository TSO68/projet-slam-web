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
        private int agee;
        private DateTime dateVenueClub;
        

        public Joueur(int num, float taille, float poids, string pied, DateTime dateVenueClub) : base(num, taille, poids, pied,dateVenueClub, age)
        {
            this.num = num;
            this.taille = taille;
            this.poids = poids;
            this.pied = pied;
            this.dateVenueClub = dateVenueClub;
            
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