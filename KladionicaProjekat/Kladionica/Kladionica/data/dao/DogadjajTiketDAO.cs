using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;

namespace Kladionica.data.dao
{
    public interface DogadjajTiketDAO
    {
        int insert(DogadjajTiketDTO dogadjajTiket);
        List<DogadjajTiketDTO> getByTiket(TiketDTO tiket);
        List<DogadjajTiketDTO> getByDogadjaj(DogadjajDTO dogadjaj);
        List<DogadjajTiketDTO> getByTipIgre(TipIgreDTO tipIgre);
    }
}
