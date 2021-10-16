﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alo_Store.Domain.Entities.Commons;

namespace Alo_Store.Domain.Entities.Users
{
    public class UserInRole:BaseEntity
    {
        public long Id { get; set; }


        public long UserId { get; set; }
        public virtual User User { get; set; }


        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
