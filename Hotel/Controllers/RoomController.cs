using Hotel.App_Start;
using Hotel.Models;
using HotelEntity.Class;
using HotelService.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class RoomController : Controller
    {
        IRoomsService room;
        ICustomerService s;
        public RoomController()
        {
            this.s = Injector.Container.Resolve<ICustomerService>();

            this.room = Injector.Container.Resolve<IRoomsService>();
        }

        // GET: Room
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddRoom()
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
        public ActionResult AddRoom(Images imageModel,Rooms rom)
        {
             if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                rom.ImagePath = "/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                imageModel.ImageFile.SaveAs(fileName);
               
                this.room.Insert(rom);
                return RedirectToAction("ManageRoom", "Room");
            }
            else
            {
                return View(rom);
            }
        }

        public ActionResult ManageRoom(Rooms rm)
        {
            return View(this.room.GetAllinformation());
        }

        [HttpGet]
        public ActionResult Edit(int id)

        {
            return View(this.room.Get(id));

        }
        [HttpPost]
        public ActionResult Edit(Rooms rom)
        {
            if (ModelState.IsValid)
            {

                this.room.UpdateRomeInformation(rom);
                return RedirectToAction("ManageRoom", "Room");
            }
            else
            {
                return View(rom);
            }
      
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(this.room.Get(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(this.room.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.room.DeleteRoom(id);
            return RedirectToAction("ManageRoom", "Room");
        }

        public ActionResult AvailableRoom(Rooms rm)
        {
            return View(this.room.GetAllinformation());
        }

      







    }
}