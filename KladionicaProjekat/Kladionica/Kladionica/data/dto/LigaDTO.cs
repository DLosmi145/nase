using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dto
{
    public class LigaDTO
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string vrstaLige;

        public string VrstaLige
        {
            get { return vrstaLige; }
            set { vrstaLige = value; }
        }
    }
}