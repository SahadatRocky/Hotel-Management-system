using HotelEntity.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRepository.Interface
{
   public interface ICustomerRepository: IRepository<Customers>
    {
      

        int UpdateStatus(Customers customer);


    }
}
