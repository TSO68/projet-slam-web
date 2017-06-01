using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Staff : Personnel
    {

        private Role leRole;
        public Staff(Role r, int id, string nom, string prenom, string dateNaiss, string lieuNaiss, string biographie, Nationalite n, Photo p) : base(id, nom, prenom, dateNaiss, lieuNaiss, biographie, n, p)
        {
            this.leRole = r;
        }

        public Role LeRole
        {
            get
            {
                return leRole;
            }

            set
            {
                leRole = value;
            }
        }

        public Role LeRole
        {
            get
            {
                return leRole;
            }

            set
            {
                leRole = value;
            }
        }
    }
}
