using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dao
{
    public abstract class DAOFactory
    {
        public abstract ZaposleniDAO getZaposleniDAO();
        public abstract IgracDAO getIgracDAO();
        public abstract LigaDAO getLigaDAO();
        public abstract SportDAO getSportDAO();
        public abstract ParDAO getParDAO();
    }
}