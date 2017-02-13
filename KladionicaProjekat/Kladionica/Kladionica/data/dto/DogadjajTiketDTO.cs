using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dto
{
    public class DogadjajTiketDTO
    {
        private DogadjajDTO dogadjaj;

        public DogadjajDTO Dogadjaj
        {
          get { return dogadjaj; }
          set { dogadjaj = value; }
        }

        private TiketDTO tiket;

        public TiketDTO Tiket
        {
            get { return tiket; }
            set { tiket = value; }
        }

        private TipIgreDTO tipIgre;

        public TipIgreDTO TipIgre
        {
            get { return tipIgre; }
            set { tipIgre = value; }
        }
    }
}
