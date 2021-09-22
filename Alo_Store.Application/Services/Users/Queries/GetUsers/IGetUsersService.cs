using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Alo_Store.Domain.Entities.Users;

namespace Alo_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
}
