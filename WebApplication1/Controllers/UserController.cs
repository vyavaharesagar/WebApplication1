using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.ID = 1;
            ViewBag.Name = "ABC";
            ViewData["ID"] = 2;

            Student obj = new Student();
            obj.ID = "100";
            obj.Name = "XYZ";
            ViewBag.Std = obj;

            return View();
        }

        [ActionName ("Login")]
        [HttpPost]
        public ActionResult Login2(User user)
        {
            var obj = DBManager.Validate(user.txtLogin, user.txtPassword);
            if (obj!=null)
            {
                //ViewBag.Msg = "Valid User";
                Session["login"] = user.txtLogin;
                Session["isadmin"] = obj.IsAdmin;
                return Redirect("~/Home/Show");
                
            }
            else
            {
                ViewBag.Msg = "Invalid User";
                ViewBag.Login = user.txtLogin;
            }
            //String login = Request["txtLogin"];
            //String password = Request["txtPassword"];

            //String login1 = Request.Form["txtLogin"];
            //String password1 = Request.Form["txtPassword"];

            return View("Login");

        }
    }
}