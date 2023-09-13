using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Medicin
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public int company_Id { set; get; }
        public static List<Medicin> Medicins = new List<Medicin>();
    }
}
