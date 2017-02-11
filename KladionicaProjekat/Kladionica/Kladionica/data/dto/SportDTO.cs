using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dto
{
    public class SportDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string opisSporta;

        public string OpisSporta
        {
            get { return opisSporta; }
            set { opisSporta = value; }
        }

        private LigaDTO liga;

        internal LigaDTO Liga
        {
            get { return liga; }
            set { liga = value; }
        }
    }
}
