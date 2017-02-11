using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dto
{
    public class IgracDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private string prezime;

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        private string sifra;

        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        private DateTime datumRodjenja;

        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }
    }
}
