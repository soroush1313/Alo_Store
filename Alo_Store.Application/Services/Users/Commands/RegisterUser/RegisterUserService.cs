using Alo_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alo_Store.Application.Interfaces.Contexts;
using Alo_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Storage;

namespace Alo_Store.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDatabaseContext _context;

        public RegisterUserService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            User user = new User()
            {
                Email = request.Email,
                FullName = request.FullName
            };

            List<UserInRole> userInRoles = new List<UserInRole>();
            foreach (var item in request.Roles)
            {
                var roles = _context.Roles.Find(item.Id);
                userInRoles.Add(new UserInRole
                {
                    Role = roles,
                    RoleId = roles.Id,
                    User = user,
                    UserId = user.Id
                });
            }

            user.UserInRoles = userInRoles;
            _context.Users.Add(user);
            _context.SaveChanges();
            return new ResultDto<ResultRegisterUserDto>()
            {
                Data = new ResultRegisterUserDto()
                {
                    UserId = user.Id
                },
                IsSuccess = true,
                Message = "ثبت نام با موفقیت انجام شد"
            };
        }
    }
}
