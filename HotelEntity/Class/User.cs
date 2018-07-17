using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelEntity.Class
{
   public class User : Entity
    {
        [Key]
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required ")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required ")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required ")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "User name is required ")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required ")]
        [Compare("Password", ErrorMessage = "Please Confirm your Password")]
        [notmapped]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }

        public string ImagePath { get; set; }
        public string UserType { get; set; }

        public int Status { get; set; }

    }
}
