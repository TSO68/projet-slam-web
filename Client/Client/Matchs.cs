using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Matchs
    {
        private int id;
        private DateTime dateMatch;
        private DateTime heure;
        private Boolean exterieurON;

        public Matchs(int id, DateTime dateMatch, DateTime heure, bool exterieurON)
        {
            this.id = id;
            this.dateMatch = dateMatch;
            this.heure = heure;
            this.exterieurON = exterieurON;
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

        public DateTime DateMatch
        {
            get
            {
                return dateMatch;
            }

            set
            {
                dateMatch = value;
            }
        }

        public DateTime Heure
        {
            get
            {
                return heure;
            }

            set
            {
                heure = value;
            }
        }

        public bool ExterieurON
        {
            get
            {
                return exterieurON;
            }

            set
            {
                exterieurON = value;
            }
        }
    }
}
