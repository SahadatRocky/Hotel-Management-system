using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Interface
{
    public interface IUserService: IService<User>
    {
        User check_pass(User us);

        int DeleteUser(int id);
        int UpdateUserInformation(User rm);

        int UpdateAllUsersBookingRoom(Rooms rm);
        List<User> GetAllinformation();
        int UpdateStatus(User user);

        List<Rooms> GetAllinformationRooms();
    }
}
