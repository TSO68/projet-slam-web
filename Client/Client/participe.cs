using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class participe
    {
        private int id;
        private int butMarques;
        private int passeDecisives;
        private Boolean cartonJauneON;
        private Boolean cartonRougeON;
        private int minutesJouees;

        public participe(int id, int butMarques, int passeDecisives, bool cartonJauneON, bool cartonRougeON, int minutesJouees)
        {
            this.id = id;
            this.butMarques = butMarques;
            this.passeDecisives = passeDecisives;
            this.cartonJauneON = cartonJauneON;
            this.cartonRougeON = cartonRougeON;
            this.minutesJouees = minutesJouees;
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
    }
}
