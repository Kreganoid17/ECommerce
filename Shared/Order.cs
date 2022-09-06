using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Shared
{
    public class Order
    {

        [Key]
        public int ID { get; set; }

        public string OrderNo { get; set; }

        public User Userid { get; set; }

        public string Products { get; set; }

        public string Quantities { get; set; }

        public string Prices { get; set; }

        public DateTime date { get; set; }

    }
}
