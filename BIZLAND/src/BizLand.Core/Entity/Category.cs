﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Entity
{
    public class Category:BaseEntity
    {
        public string Name {  get; set; }
        public List<Portfolio> Portfolios { get; set; }
    }
}
