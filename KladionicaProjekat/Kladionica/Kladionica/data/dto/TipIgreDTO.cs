using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dto
{
    public class TipIgreDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string vrstaIgre;

        public string VrstaIgre
        {
            get { return vrstaIgre; }
            set { vrstaIgre = value; }
        }
    }
}
