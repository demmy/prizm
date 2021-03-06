﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prizm.Domain.Entity.Mill;
using FluentNHibernate.Mapping;

namespace Prizm.Data.DAL.Mapping
{
    public class HeatMap: SubclassMap<Heat>
    {
        public HeatMap()
        {
            Map(x => x.Number).Column("number");
            Map(x => x.SteelGrade).Column("steelGrade");
            References(x => x.PlateManufacturer).Column("plateManufacturer").Cascade.All();

            HasMany(x => x.Plates).KeyColumn("heatId");
        }
    }
}
