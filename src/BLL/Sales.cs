using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Sales
    {
        public int Order_ID { set; get; }
        public int Customer_ID { set; get; }
        public decimal Total_price { set; get; }
        public decimal Price { set; get; }
        public DateTime Order_Date { set; get; }
        public int Medicin_ID { set; get; }
        public int quantity { set; get; }
        public string Item_Name { set; get; }
        public string Customer_Name { set; get; }

    }
}
