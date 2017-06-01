using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Staff : Personnel
    {
        private int id;
        private Role idRole;
        public Staff(String role, int id, string nom, string prenom, DateTime dateNaiss, string lieuNaiss, string biographie, Nationalite nationalite, Role Role) : base(id, nom, prenom, dateNaiss, lieuNaiss, biographie, nationalite)
        {
            this.idRole = Role;
        }

        public Role Role
        {
            get
            {
                return idRole;
            }

            set
            {
                idRole = value;
            }
        }
    }
}
