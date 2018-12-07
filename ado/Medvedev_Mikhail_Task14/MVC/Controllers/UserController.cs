using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;


namespace MVC.Controllers
{
    public class UserController:Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index");
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

        public ActionResult Edit(int userId)
        {
            // var user = data.GetUserById(userId);
            // return View("CreateEdit", user);
            return View();
        }

        public ActionResult Edit(Users user)
        {
            // data.EditUser(user);
            // return RedirectToAction("Index");
            return View();
        }

        public ActionResult Create()
        {
            // return View("CreateEdit");
            return View();
        }

        public ActionResult Create(Users user)
        {
            // data.CreateUser(user);
            // return RedirectToAction("Index");
            return View();
        }

        public ActionResult Delete(int userId)
        {
            // data.DeleteUser(userId);
            // return RedirectToAction("Index");
            return View();
        }
    }
}