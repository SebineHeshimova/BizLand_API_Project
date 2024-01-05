﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Core.Entity
{
    public class AppUser:IdentityUser
    {
        public string FullName {  get; set; }
    }
}
