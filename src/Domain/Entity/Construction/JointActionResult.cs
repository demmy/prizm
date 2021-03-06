﻿using Prizm.Domain.Entity.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizm.Domain.Entity.Construction
{
    public class JointActionResult : Item
    {
        public virtual bool IsCompleted { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual Joint Joint { get; set; }
        public virtual JointOperation Operation { get; set; }

        public override Guid OwnerId
        {
            get
            {
                return (Joint == null)? this.Id : Joint.Id;
            }
            set
            {
                base.OwnerId = value;
            }
        }
    }
}
