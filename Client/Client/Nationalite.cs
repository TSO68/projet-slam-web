using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Nationalite
    {
        private int id;
        private String libelle;

        public Nationalite(int id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
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
    }
}
