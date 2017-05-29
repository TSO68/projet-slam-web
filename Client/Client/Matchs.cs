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
        private int scoreDom;
        private int scoreExt;
        private Boolean exterieurON;
        private Adversaire lAdversaire;
        private Stade leStade;

        public Matchs(int id, DateTime dateMatch, int sd, int se, bool exterieurON, Adversaire a, Stade s)
        {
            this.id = id;
            this.dateMatch = dateMatch;
            this.scoreDom = sd;
            this.scoreExt = se;
            this.exterieurON = exterieurON;
            this.lAdversaire = a;
            this.leStade = s;
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

        public int ScoreDom
        {
            get
            {
                return scoreDom;
            }

            set
            {
                scoreDom = value;
            }
        }

        public int ScoreExt
        {
            get
            {
                return scoreExt;
            }

            set
            {
                scoreExt = value;
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
        public Stade LeStade
        {
            get
            {
                return leStade;
            }

            set
            {
                leStade = value;
            }
        }
        public Adversaire LAdversaire
        {
            get
            {
                return lAdversaire;
            }

            set
            {
                lAdversaire = value;
            }
        }
    }
}
