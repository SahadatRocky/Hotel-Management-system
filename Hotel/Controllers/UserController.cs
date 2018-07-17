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
    public class UserController : Controller
    {

        IUserService service;
        IRoomsService room;
        ICustomerService s;

        //  ICustomerService sp;
        public UserController()
        {
            this.service = Injector.Container.Resolve<IUserService>();
            this.room = Injector.Container.Resolve<IRoomsService>();
            this.s = Injector.Container.Resolve<ICustomerService>();
            // this.sp = Injector.Container.Resolve<ICustomerService>();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
           // return View(this.service.GetAll());
        }
        public ActionResult RoomsDetails() {

            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Restaurent()
        {

            return View();
        }
        public ActionResult Gallery()
        {

            return View();
        }



        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {

            if (ModelState.IsValid)
            {

                ViewBag.message = "Registration Successfull";
                this.service.Insert(user);
                return RedirectToAction("Registration");
            }
            else
            {
                return View(user);
            }
            // ViewBag.Message = us.FirstName + " " + us.LastName + " Successfully Registered";

        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var usr = service.check_pass(user);
            if (usr != null)
            {
                if (usr.UserType == "Admin")
                {
                    Session["UserType"] = usr.UserType.ToString();
                    Session["UserID"] = usr.UserId.ToString();
                    Session["Username"] = usr.Username.ToString();
                    Session["Firstname"] = usr.FirstName.ToString();
                    return RedirectToAction("AdminPage", "Admin");
                }
                else if (usr.UserType == "User")
                {
                    Session["UserType"] = usr.UserType.ToString();
                    Session["UserID"] = usr.UserId.ToString();
                    Session["Username"] = usr.Username.ToString();
                     Session["Firstname"] = usr.FirstName.ToString();
                    return RedirectToAction("UserHomepage", "User");
                }
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is Wrong!");
            }

            return View();
        }

        [HttpGet]
        public ActionResult LoggedIn()
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


        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "User");
        }

        //reservation
        public ActionResult UserHomepage() {

            if (Session["UserId"] != null)
            {
                
                ViewBag.customerid =Session["UserID"];

                return View(this.room.GetAllinformation());

            }
            else
            {
                return RedirectToAction("Login", "User");
            }

        }

        [HttpPost, ActionName("UserHomepage")]
        public ActionResult UserHomepages()
        {
            // User users = this.service.Get(id);
            ViewBag.customerid = Session["UserID"];
            ViewBag.searchdate = Convert.ToDateTime(Request.Form["Check"]);
            return View(this.room.SearchGetAll(Convert.ToDateTime(Request.Form["Check"])));
        }

        [HttpGet]
        public ActionResult ShowRoomDetails(int id, int cid)

        {
            ViewBag.customerid = Session["UserID"];
            return View(this.room.Get(id));
        }

        [HttpPost]
        public ActionResult ShowRoomDetails(Rooms rome, int id, int cid)
        {
            User user = this.service.Get(cid);
            user.Status = 1;
            this.service.UpdateStatus(user);

            if (ModelState.IsValid)
            {
                this.service.UpdateAllUsersBookingRoom(rome);

                return RedirectToAction("UserHomepages");
            }
            else
            {
                return View(rome);
            }

        }


        [HttpGet]
        public ActionResult UserDetails()
        {
            return View(this.service.GetAll().ToList());

        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            return View(this.service.Get(id));
        }


        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteConfirmedUSer(int id)
        {
            
            this.service.DeleteUser(id);
            return RedirectToAction("UserDetails", "User");
        }

        [HttpGet]
        public ActionResult EditUserDetails(int id)
        {
            return View(this.service.Get(id));

        }


        [HttpPost]
        public ActionResult EditUserDetails(User Us)
        {

            if (ModelState.IsValid)
            {
                this.service.UpdateUserInformation(Us);
                return RedirectToAction("UserDetails", "User");
            }
            else
            {
                return View(Us);
            }

        }



    }
}