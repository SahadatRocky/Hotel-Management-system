using HotelEntity.Class;
using HotelRepository.Class;
using HotelService.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace API.Controllers
{
    public class RoomController : ApiController
    {
        // GET api/values
        RoomService roomservice = new RoomService();

        DataContext context = new DataContext();

        
        public IHttpActionResult Get()
        {

            // List<Rooms> officeList = officeService.GetAllinformation();
            // return Ok(officeList);

            //List<Rooms> dlist = context.Set<Rooms>().ToList();
             List<Rooms> deptlist = context.Rooms.ToList();

            //List<Rooms> dlist = context.Set<Rooms>().ToList();
           // List<Rooms> deptlist = new List<Rooms>();

            //return Content(HttpStatusCode.OK, "Welcome");
            return Ok(deptlist); 

        }
        [HttpPost]
        public IHttpActionResult AddContact([FromBody]Contact con)
        {

            this.context.Set<Contact>().Add(con);
            context.SaveChanges();
            return Created("/Contacts/" + con.Id,con);

        }



    }
}