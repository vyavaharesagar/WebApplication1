using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

        //public ActionResult Show()
        //{
        //    var students = DBManager.GetAllStudents();

        //    return View(students);
        //}

        public ActionResult Show()
        {
            if (Session["Login"] == null)
            {
                return Redirect("~/user/login");
            }
            var products = DBManager.GetProducts();
            return View(products);
        }

        public ActionResult Logout()
        {
            Session["Login"] = null;
            Session.Abandon();

            return Redirect("~/User/Logout");
        }
    }
}