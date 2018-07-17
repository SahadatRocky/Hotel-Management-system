using HotelEntity.Class;
using HotelRepository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Class
{
    public class RoomsRepository:Repository<Rooms>, IRoomRepository
    {
        public DataContext context = new DataContext();

        public int UpdateRomeInformation(Rooms rm)
        {

          Rooms rome = this.context.Rooms.SingleOrDefault(d => d.RoomId == rm.RoomId);
            rome.RoomNumber = rm.RoomNumber;
           rome.Description = rm.Description;
           rome.Amount = rm.Amount;
           rome.Capacity = rm.Capacity;
            rome.Status = rm.Status;
            rome.Type = rm.Type;
            return this.context.SaveChanges();
        }

        public List<Rooms> GetAllinformation()
        {
            return this.context.Rooms.ToList();
        }

        public int DeleteRoom(int id)
        {
            Rooms deptToDelete = this.context.Rooms.SingleOrDefault(d => d.RoomId == id);
            this.context.Rooms.Remove(deptToDelete);
            return this.context.SaveChanges();
        }

        public List<Rooms> SearchGetAll(DateTime date)
        {
                  return this.context.Rooms.Where(d => d.Status == 1 && (d.CheckIn >date || d.Checkout <date)).ToList();

        }

        public int UpdateAll(Rooms rm)
        {
            Rooms rome = this.context.Rooms.SingleOrDefault(d => d.RoomId == rm.RoomId);
            rome.Status = rm.Status;
            rome.CheckIn = rm.CheckIn;
            rome.Checkout = rm.Checkout;
            rome.C_Id = rm.C_Id;
            return this.context.SaveChanges();
        }

        public List<Rooms> GetAllBookingRoom(Customers cust, int id)
        {
            return this.context.Rooms.Include("Customer").Where(c => c.C_Id == id).ToList();
        }


    }
}
