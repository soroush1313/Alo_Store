using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alo_Store.Application.Services.Users.Queries.GetRoles;
using Alo_Store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EndPoint.Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;

        public UsersController(IGetUsersService getUsersService, IGetRolesService getRolesService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
        }
        [Area("Admin")]
        public IActionResult Index(string searchKey , int page=1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page=page,
                SearchKey = searchKey
            }));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles =new SelectList(_getRolesService.Execute().Data, "Id","Name");
            return View();
        }
    }
}
