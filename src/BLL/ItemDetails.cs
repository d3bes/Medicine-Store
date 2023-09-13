using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemDetails
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public string company { set; get; }
        public int sold { set; get; }
        public DateTime Latest_Order_Date { set; get; }
    }
}
