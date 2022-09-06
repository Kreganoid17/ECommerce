using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Shared.DTO
{
    public class OrderDetailsDTO
    {

        public string orderno { get; set; }

        public List<string> orderproducts { get; set; }

        public List<int> quantities { get; set; }

        public List<float> prices { get; set; }

        public DateTime orderdate { get; set; }

    }
}
