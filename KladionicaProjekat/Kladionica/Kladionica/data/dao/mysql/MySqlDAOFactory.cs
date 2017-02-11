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
    }
}
