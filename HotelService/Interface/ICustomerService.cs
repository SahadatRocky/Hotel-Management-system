using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Interface
{
   public interface ICustomerService : IService<Customers>
    {
        int UpdateStatus(Customers customer);
    }
}
