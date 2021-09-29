using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alo_Store.Common.Dto;

namespace Alo_Store.Application.Services.Users.Commands.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ResultDto Execute(long Id);
    }
}
