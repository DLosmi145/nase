using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dto
{
    public class ZaposleniDTO
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

        private string brojTelefona;

        public string BrojTelefona
        {
            get { return brojTelefona; }
            set { brojTelefona = value; }
        }

        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        private string sifra;

        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        private string nivoPristupa;

        public string NivoPristupa
        {
            get { return nivoPristupa; }
            set { nivoPristupa = value; }
        }
    }
}
