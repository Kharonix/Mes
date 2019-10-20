using Mes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mes.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            var role = (from r in context.Roles where r.Name.Contains("User") select r).FirstOrDefault();
            var users = context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();

            var userVM = users.Select(user => new UserViewModel
            {
                Username = user.UserName,
                RoleName = "User"
            }).ToList();


            var role2 = (from r in context.Roles where r.Name.Contains("Admin") select r).FirstOrDefault();
            var admins = context.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role2.Id)).ToList();

            var adminVM = admins.Select(user => new UserViewModel
            {
                Username = user.UserName,
                RoleName = "Admin"
            }).ToList();


            var model = new GroupedUserViewModel { Users = userVM, Admins = adminVM };
            return View(model);
        }
    }
}