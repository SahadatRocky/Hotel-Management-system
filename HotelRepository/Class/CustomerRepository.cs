using HotelEntity.Class;
using HotelRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Class
{
   public class CustomerRepository : Repository<Customers>,ICustomerRepository
    {
       


        public int UpdateStatus(Customers customer)
        {
            Customers cust = this.context.Customers.SingleOrDefault(d => d.CustomerId == customer.CustomerId);
            cust.Status = customer.Status;
            return this.context.SaveChanges();
        }

    }
}
