using HotelEntity.Class;
using HotelRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Class
{
    public class UserRepository : Repository<User>, IUserRepository
    {
       public DataContext context = new DataContext();

        public User check_pass(User us)
        {
            return context.Set<User>().SingleOrDefault(u => u.Username == us.Username && u.Password == us.Password);
        }

        public int DeleteUser(int id)
        {
            User Delete = this.context.Users.SingleOrDefault(d => d.UserId== id);
            this.context.Users.Remove(Delete);
            return this.context.SaveChanges();
        }

        public int UpdateUserInformation(User rm)
        {

            User user = this.context.Users.SingleOrDefault(d => d.UserId == rm.UserId);

            user.UserType = rm.UserType;
            return this.context.SaveChanges();
        }

        public List<User> GetAllinformation()
        {
            return this.context.Users.ToList();
        }

        public int UpdateAllUsersBookingRoom(Rooms rm)
        {
            Rooms rome = this.context.Rooms.SingleOrDefault(d => d.RoomId == rm.RoomId);
            rome.Status = rm.Status;
            rome.CheckIn = rm.CheckIn;
            rome.Checkout = rm.Checkout;
            rome.UserID = rm.UserID;
            return this.context.SaveChanges();
        }

        public int UpdateStatus(User user)
        {
            User users = this.context.Users.SingleOrDefault(d => d.UserId == user.UserId);
            users.Status = user.Status;
            return this.context.SaveChanges();
        }


        public List<Rooms> GetAllinformationRooms()
        {
            return this.context.Rooms.ToList();
        }


    }
}
