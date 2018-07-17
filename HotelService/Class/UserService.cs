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
    public class UserService : Service<User>, IUserService
    {
        UserRepository repo = new UserRepository();

        public User check_pass(User us)
        {
            return repo.check_pass(us);
        }

        public int DeleteUser(int id)
        {
            return this.repo.DeleteUser(id);
        }

        public int UpdateUserInformation(User rm)
        {
            return this.repo.UpdateUserInformation(rm);
        }

        public List<User> GetAllinformation()
        {
            return this.repo.GetAllinformation();
        }

        public int UpdateAllUsersBookingRoom(Rooms rm)
        {
            return this.repo.UpdateAllUsersBookingRoom(rm);
        }

        public int UpdateStatus(User user)
        {
            return this.repo.UpdateStatus(user);
        }

        public List<Rooms> GetAllinformationRooms()
        {
            return this.GetAllinformationRooms();
        }
    }
}
