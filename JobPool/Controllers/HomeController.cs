using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace JobPool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            //var roles = SignInManager.UserManager.GetRoles(userId);
            //if (User.Identity.IsAuthenticated)
            //{
            //    var authenticationManager = HttpContext.GetOwinContext().Authentication;
            //    if (User.Identity is ClaimsIdentity identity)
            //    {
            //        foreach (var role in roles)
            //        {
            //            identity.AddClaim(new Claim(ClaimTypes.Role, role));
            //        }
            //        authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(
            //            new ClaimsIdentity(identity), new AuthenticationProperties
            //            { IsPersistent = true }
            //            );
            //    }
            //}
            if (User.IsInRole("Recruiter"))
            {
                return RedirectToAction("DashBoard", "Recruiter");
            }
            else
                return RedirectToAction("Index", "User");
        }
        public ActionResult IndexNew()
        {
            return View();
        }

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