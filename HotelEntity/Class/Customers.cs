using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntity.Class
{
   public class Customers:Entity
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "name is required ")]
        public string Customer_Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "address is required ")]
        public string Customer_Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "phoneno is required ")]
        public int Customer_PhoneNo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is required ")]

        public string Gender { get; set; }

        public int UserId { get; set; }

        public int Status { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }






    }
}
