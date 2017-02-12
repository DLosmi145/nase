using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kladionica.data.dao.mysql
{
    class MySqlDAOFactory : DAOFactory
    {
        public override ZaposleniDAO getZaposleniDAO()
        {
            return new MySqlZaposleniDAO();
        }

        public override IgracDAO getIgracDAO()
        {
            return new MySqlIgracDAO();
        }

        public override LigaDAO getLigaDAO()
        {
            return new MySqlLigaDAO();
        }

        public override SportDAO getSportDAO()
        {
            return new MySqlSportDAO();
        }

        public override ParDAO getParDAO()
        {
            return new MySqlParDAO();
        }

        public override DogadjajDAO getDogadjajDAO()
        {
            return new MySqlDogadjajDAO();
        }

        public override TiketDAO getTiketDAO()
        {
            return new MySqlTiketDAO();
        }
    }
}
