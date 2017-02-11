using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dto
{
    class SifraUplatnogSistema
    {
        private string sifra;

        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }
        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

    }
}
