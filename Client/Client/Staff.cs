using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Staff : Personnel
    {
        private string role;
        public Staff(String role, int id, string nom, string prenom, DateTime dateNaiss, string lieuNaiss, string biographie) : base(id, nom, prenom, dateNaiss, lieuNaiss, biographie)
        {
            this.Role = role;
        }

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }
    }
}
