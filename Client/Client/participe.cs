using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class participe
    {
        private Matchs leMatch;
        private Joueur leJoueur;
        private int butMarques;
        private int passeDecisives;
        private Boolean cartonJauneON;
        private Boolean cartonRougeON;
        private int minutesJouees;

        public participe(Matchs m, Joueur j, int butMarques, int passeDecisives, bool cartonJauneON, bool cartonRougeON, int minutesJouees)
        {
            this.leMatch = m;
            this.leJoueur = j;
            this.butMarques = butMarques;
            this.passeDecisives = passeDecisives;
            this.cartonJauneON = cartonJauneON;
            this.cartonRougeON = cartonRougeON;
            this.minutesJouees = minutesJouees;
        }

        public int ButMarques
        {
            get
            {
                return butMarques;
            }

            set
            {
                butMarques = value;
            }
        }

        public int PasseDecisives
        {
            get
            {
                return passeDecisives;
            }

            set
            {
                passeDecisives = value;
            }
        }

        public bool CartonJauneON
        {
            get
            {
                return cartonJauneON;
            }

            set
            {
                cartonJauneON = value;
            }
        }

        public bool CartonRougeON
        {
            get
            {
                return cartonRougeON;
            }

            set
            {
                cartonRougeON = value;
            }
        }

        public int MinutesJouees
        {
            get
            {
                return minutesJouees;
            }

            set
            {
                minutesJouees = value;
            }
        }
        public Joueur LeJoueur
        {
            get
            {
                return leJoueur;
            }

            set
            {
                leJoueur = value;
            }
        }
        public Matchs LeMatch
        {
            get
            {
                return leMatch;
            }

            set
            {
                leMatch = value;
            }
        }
    }
}
