
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
    public class CustomerController : Controller
    {
        ICustomerService s;
        IRoomsService room;
        public CustomerController()
        {
            this.room = Injector.Container.Resolve<IRoomsService>();
            this.s = Injector.Container.Resolve<ICustomerService>();
        }


        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult addCustomer()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }


        [HttpPost]
        public ActionResult addCustomer(Customers Cust)
        {

            if (ModelState.IsValid)
            {
                ViewBag.message = "Successfull added";
                this.s.Insert(Cust);

                return RedirectToAction("RegisterCustomer", "Customer");
            }
            else
            {
                return View(Cust);
            }

        }

        public ActionResult RegisterCustomer(Customers cus)
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
        [HttpGet]
        public ActionResult RoomDetails(int id) {
            Customers c = s.Get(id);
            ViewBag.customerid = c.CustomerId;
            return View(s.GetAll());

        }

       



        [HttpGet]
        public ActionResult CustomerBookingRoomsDetails(int id)
        {
            Customers cust = this.s.Get(id);
            ViewBag.customerid = cust.CustomerId;

            return View(this.room.GetAllinformation());
        }

        [HttpPost,ActionName("CustomerBookingRoomsDetails")]
        public ActionResult CustomerBookingRoomsDetailss(int id)
        {
            Customers cust = this.s.Get(id);
            ViewBag.customerid = cust.CustomerId;

            ViewBag.searchdate =Convert.ToDateTime(Request.Form["Check"]);
            return View(this.room.SearchGetAll(Convert.ToDateTime(Request.Form["Check"])));
        }


        [HttpGet]
        public ActionResult ShowRoomDetails(int id, int cid)

        {
            Customers cust = this.s.Get(cid);
            ViewBag.c_id = cust.CustomerId;
            return View(this.room.Get(id));
        }

        [HttpPost]
        public ActionResult ShowRoomDetails(Rooms rome, int id, int cid)
        {
            DateTime Chekin = Convert.ToDateTime(Request.Form["CheckIn"]);
            DateTime Chekout = Convert.ToDateTime(Request.Form["Chekout"]);
            TimeSpan ts = Chekout - Chekin;
            int days = ts.Days;

            
            Customers cust = this.s.Get(cid);
            cust.Status = 1;
            // cust.RoomId = Convert.ToInt32(Request.Form["RoomId"]);
            //  cust.TotalAmount = Convert.ToInt32(Request.Form["Amount"]);

            this.s.UpdateStatus(cust);

            if (ModelState.IsValid)
            {
                ViewBag.days = days;
                this.room.UpdateAll(rome);

                return RedirectToAction("RegisterCustomer");
            }
            else
            {
                return View(rome);
            }

        }

        public ActionResult CustomerBookingRoom(Customers cust, int id)
        {

            cust = this.s.Get(id);
            ViewBag.CustomerName = cust.Customer_Name;
            return View(this.room.GetAllBookingRoom(cust, id));
        }


        public ActionResult BillGenerate() {

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