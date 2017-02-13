﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kladionica.data.dto;

namespace Kladionica.data.dao
{
    public interface TipIgreDAO
    {
        int insert(TipIgreDTO tipIgre);
        TipIgreDTO getByVrstaIgre(string vrsta);
    }
}
