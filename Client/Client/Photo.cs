using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Photo
    {
        private int id;
        private String lien;

        public Photo(int id, string lien)
        {
            this.id = id;
            this.lien = lien;
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

        public string Lien
        {
            get
            {
                return lien;
            }

            set
            {
                lien = value;
            }
        }
    }
}
