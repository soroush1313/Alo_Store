using System.Collections.Generic;
using System.Linq;
using Alo_Store.Application.Interfaces.Contexts;
using Alo_Store.Common;

namespace Alo_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDatabaseContext _context;

        public GetUsersService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }
            int rowsCount;
            var usersList= users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDto
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id
            }).ToList();

            return new ResultGetUserDto
            {
                Rows = rowsCount,
                Users = usersList
            };
        }
    }
}