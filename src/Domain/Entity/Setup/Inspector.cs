﻿using System;
using System.Collections.Generic;
using Domain.Entity.Mill;
using Domain.Entity.Setup;

namespace Domain.Entity
{
    public class Inspector : Item
    {
        public virtual PersonName Name { get; set; }
        public virtual Certificate Certificate { get; set; }
    }
}