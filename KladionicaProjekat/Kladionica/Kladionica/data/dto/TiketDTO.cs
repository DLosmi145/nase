using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dto
{
    class TiketDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime vrijemeUplate;

        public DateTime VrijemeUplate
        {
            get { return vrijemeUplate; }
            set { vrijemeUplate = value; }
        }

        private string kontrolniBrojTiketa;

        public string KontrolniBrojTiketa
        {
            get { return kontrolniBrojTiketa; }
            set { kontrolniBrojTiketa = value; }
        }

        private float iznosUplate;

        public float IznosUplate
        {
            get { return iznosUplate; }
            set { iznosUplate = value; }
        }

        private int sistem;

        public int Sistem
        {
            get { return sistem; }
            set { sistem = value; }
        }

        private SifraUplatnogMjestaDTO sifraUplatnogMjesta;

        internal SifraUplatnogMjestaDTO SifraUplatnogMjesta
        {
            get { return sifraUplatnogMjesta; }
            set { sifraUplatnogMjesta = value; }
        }

        private ZaposleniDTO zaposleni;

        public ZaposleniDTO Zaposleni
        {
            get { return zaposleni; }
            set { zaposleni = value; }
        }

        private IgracDTO igrac;

        public IgracDTO Igrac
        {
            get { return igrac; }
            set { igrac = value; }
        }
    }
}
