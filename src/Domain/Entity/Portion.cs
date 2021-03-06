﻿using Prizm.Domain.Entity.Construction;
using Prizm.Domain.Entity.Mill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizm.Domain.Entity
{
   public class Portion
   {
      public Portion()
      {
         if (Id == Guid.Empty)
            Id = Guid.NewGuid();
         Pipes = new List<Pipe>();
         Joints = new List<Joint>();
         Components = new List<Component>();
      }

      public virtual Guid Id { get; set; }
      public virtual DateTime ExportDateTime { get; set; }
      public virtual bool IsExport { get; set; }
      public virtual Project Project { get; set; }
      public virtual int PortionNumber { get; set; }
      public virtual IList<Pipe> Pipes { get; set; }
      public virtual IList<Joint> Joints { get; set; }
      public virtual IList<Component> Components { get; set; }
   }
}
