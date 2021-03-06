using System;
using System.Collections.Generic;

namespace elad.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Orders>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
