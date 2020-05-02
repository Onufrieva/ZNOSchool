using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using System.Threading;
using System.Security.Claims;
using ZNOSchool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;


namespace ZNOSchool.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Authorize]
        public ActionResult Index()
        {
            #region New недописано
            //IList<string> roles = new List<string> { "Роль не определена" };
            //ApplicationUserManager userManager = HttpContext.GetOwinContext()
            //                                        .GetUserManager<ApplicationUserManager>();
            //ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            //if (user != null)
            //    roles = userManager.GetRoles(user.Id);
            #endregion
            return View();
        }

        public string GetAge()
        {
            var indentity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var age = indentity.Claims.Where(c => c.Type == "age").Select(c => c.Value).SingleOrDefault();
            return age;
        }

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}