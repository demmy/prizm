﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.Construction
{
    public enum PartConstructionStatus
    {
        Pending = 1,
        AlongTrench = 2,
        Welded = 3,
        Lowered = 4,
        Filled = 5,

        Undefined = 0
    }
}