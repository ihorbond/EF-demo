using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Address
    {
        public Address()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
