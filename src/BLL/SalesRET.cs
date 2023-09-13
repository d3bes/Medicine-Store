using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SalesRET
    {
        public int Order_ID { set; get; }
        public int Medicin_ID { set; get;}
        public decimal Price { set; get; }
        public int quantity { set; get; }
    }
}
