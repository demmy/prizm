﻿using Prizm.Domain.Entity.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizm.Data.DAL.Security
{
   public interface IRoleRepository : IRepository<Guid, Role>
   {
   }
}
