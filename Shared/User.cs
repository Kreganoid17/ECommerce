using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Shared
{
    public class User
    {

        [Key]
        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

    }
}
