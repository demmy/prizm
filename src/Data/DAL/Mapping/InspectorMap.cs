﻿using Domain.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL.Mapping
{
    public class InspectorMap : SubclassMap<Inspector>
    {
        public InspectorMap()
        {
            Table("Inspector");

            Component<PersonName>(x => x.Name, m =>
               {
                  m.Map(_ => _.FirstName).Column("firstName");
                  m.Map(_ => _.LastName).Column("lastName");
                  m.Map(_ => _.MiddleName).Column("middleName");
               });
            Map(_ => _.Certificate).Column("certificate");
            Map(_ => _.CertificateExpiration).Column("certificateExpiration");
            HasManyToMany(_ => _.TestResults)
      .Cascade.All()
      .Inverse()
      .Table("TestResult_Inspector");
        }
    }
}
