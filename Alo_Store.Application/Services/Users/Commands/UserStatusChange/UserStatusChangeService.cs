using Alo_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alo_Store.Application.Interfaces.Contexts;

namespace Alo_Store.Application.Services.Users.Commands.UserStatusChange
{
    public class UserStatusChangeService : IUserStatusChangeService
    {
        private readonly IDatabaseContext _context;

        public UserStatusChangeService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
