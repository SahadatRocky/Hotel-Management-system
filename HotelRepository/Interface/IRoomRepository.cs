using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Interface
{
    public interface IRoomRepository : IRepository<Rooms>
    {
        int UpdateRomeInformation(Rooms rm);
        List<Rooms> GetAllinformation();

        int DeleteRoom(int id);

        List<Rooms> SearchGetAll(DateTime date);

         int UpdateAll(Rooms rm);

        List<Rooms> GetAllBookingRoom(Customers cust, int id);
    }
}
