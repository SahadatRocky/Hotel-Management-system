using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Interface
{
   public interface IRoomsService:IService<Rooms>
    {
        int UpdateRomeInformation(Rooms rm);
        List<Rooms> GetAllinformation();
        int DeleteRoom(int id);

        List<Rooms> SearchGetAll(DateTime date);
        int UpdateAll(Rooms rm);

        List<Rooms> GetAllBookingRoom(Customers cust, int id);
    }
}
