using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Shared
{
    public class Cart
    {

        public int Id { get; set; }

        public User user { get; set; }

        public string CartItems { get; set; }

        public string CartQauntity { get; set; }

        public float Price { get; set; }

    }
}
