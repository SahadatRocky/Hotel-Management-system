using HotelEntity.Class;
using HotelRepository.Class;
using HotelService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Class
{
    public class RoomService:Service<Rooms>, IRoomsService
    {
        RoomsRepository repo = new RoomsRepository();

        public int UpdateRomeInformation(Rooms rm)
        {
            return repo.UpdateRomeInformation(rm);
        }
        public List<Rooms> GetAllinformation()
        {
            return repo.GetAllinformation();
        }

         public int DeleteRoom(int id)
        {
            
            return this.repo.DeleteRoom(id);
        }

        public List<Rooms> SearchGetAll(DateTime date)
        {
            return this.repo.SearchGetAll(date);
        }


        public int UpdateAll(Rooms rm) {
            return this.repo.UpdateAll(rm);
        }

        public List<Rooms> GetAllBookingRoom(Customers cust, int id)
        {
            return this.repo.GetAllBookingRoom(cust, id);
        }

    }
}
