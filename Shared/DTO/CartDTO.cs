using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Shared.DTO
{
    public class CartDTO
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public int UserID { get; set; }

    }
}
