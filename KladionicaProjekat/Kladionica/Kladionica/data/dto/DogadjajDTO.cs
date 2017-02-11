using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dto
{
    class DogadjajDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime vrijemeOdrzavanja;

        public DateTime VrijemeOdrzavanja
        {
            get { return vrijemeOdrzavanja; }
            set { vrijemeOdrzavanja = value; }
        }

        private ParDTO par;

        internal ParDTO Par
        {
            get { return par; }
            set { par = value; }
        }
    }
}
