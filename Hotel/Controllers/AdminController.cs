using Hotel.App_Start;
using HotelEntity.Class;
using HotelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class AdminController : Controller
    {
        ICustomerService s;
        public AdminController()
        {
            this.s = Injector.Container.Resolve<ICustomerService>();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdminPage() {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else {

                return RedirectToAction("Login", "User");
            }

            
        }

        public ActionResult BillGenerate()
        {

            if (Session["UserId"] != null)
            {
                return View(this.s.GetAll());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }



    }
}