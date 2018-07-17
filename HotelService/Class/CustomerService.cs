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
    public class CustomerService: Service<Customers>, ICustomerService
    {
        CustomerRepository crepo = new CustomerRepository();

       

        public int UpdateStatus(Customers customer)
        {
           
            return this.crepo.UpdateStatus(customer);
        }





    }
}
