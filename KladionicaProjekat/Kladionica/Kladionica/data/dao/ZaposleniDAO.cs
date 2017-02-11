using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;

namespace Kladionica.data.dao
{
    public interface ZaposleniDAO
    {
        int insert(ZaposleniDTO zaposleni);
        ZaposleniDTO getByImeISifra(string ime, string sifra);
    }
}
