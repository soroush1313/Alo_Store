using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alo_Store.Application.Services.Users.Commands.RegisterUser;
using Alo_Store.Application.Services.Users.Commands.RemoveUser;
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
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;

        public UsersController(IGetUsersService getUsersService, IGetRolesService getRolesService, IRegisterUserService registerUserService, IRemoveUserService removeUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
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

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        Id = RoleId
                    }
                },
                Password = Password,
                RePassword = RePassword
            });
            return Json(result);
        }
        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }
    }
}
