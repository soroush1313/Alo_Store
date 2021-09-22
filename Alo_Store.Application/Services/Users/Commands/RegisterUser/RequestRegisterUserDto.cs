using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alo_Store.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<RolesInRegisterUserDto> Roles { get; set; }
    }
}
