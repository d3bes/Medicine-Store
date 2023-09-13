using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Order
    {
        public int Order_ID { set; get; }
        public decimal Total_price { set; get; }
        public DateTime Order_Date { set; get; } = DateTime.Now;
    }
}
