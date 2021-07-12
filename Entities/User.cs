using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }


     
        //[MinLength(6, ErrorMessage = " סיסמא חייבת להכיל 6 תוים")]

        public string Email { get; set; }
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
