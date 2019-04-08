using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Durian.Service.Role;
using Microsoft.AspNetCore.Mvc;
using Durian.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace Durian.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoleService _roleService;

        public HomeController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        
        public IActionResult Index()
        {
           var role = _roleService.GetRoleByGuid(Guid.NewGuid());
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}