﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alo_Store.Domain.Entities.Users
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }

    }
}
