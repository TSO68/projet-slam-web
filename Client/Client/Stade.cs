using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Stade
    {
        private int id;
        private String libelle;
        private int nbPlaces;

        public Stade(int id, string libelle, int nbPlaces)
        {
            this.id = id;
            this.libelle = libelle;
            this.nbPlaces = nbPlaces;
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

        public string Libelle
        {
            get
            {
                return libelle;
            }

            set
            {
                libelle = value;
            }
        }

        public int NbPlaces
        {
            get
            {
                return nbPlaces;
            }

            set
            {
                nbPlaces = value;
            }
        }
    }
}
