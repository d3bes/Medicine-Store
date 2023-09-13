using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using System.Net;
using System.IO;

namespace BLL
{
    public class BusinessLayer
    {
        DataLayer dataLayer = new DataLayer();

        #region sales
        public List<Medicin> GetMedicins()
        {
            DataTable dataTable = dataLayer.GetMedicin();

            List<Medicin> medicins = new List<Medicin>();
            foreach (DataRow medicin in dataTable.Rows)
            {
                int id;
                decimal price;
                int quantity;
                Medicin med = new Medicin();
                
                bool res1 = int.TryParse(medicin["id"].ToString(), out id);
                bool res2 = decimal.TryParse(medicin["price"].ToString(), out price);
                bool res3 = int.TryParse(medicin["quantity"].ToString(), out quantity);
                med.ID = res1 ? id : 0;
                med.Price = res2 ? price : 0M;
                med.Quantity = res3 ? quantity : 0;
                med.Name = medicin["name"].ToString();
                med.Description = medicin["description"].ToString();

                medicins.Add(med);

            }
            return medicins;
        }

        public List<Medicin> Search(string Name)
        {
            DataTable dataTable = dataLayer.Search(Name);

            List<Medicin> medicins = new List<Medicin>();
            foreach (DataRow medicin in dataTable.Rows)
            {
                int id;
                decimal price;
                int quantity;
                Medicin med = new Medicin();

                bool res1 = int.TryParse(medicin["id"].ToString(), out id);
                bool res2 = decimal.TryParse(medicin["price"].ToString(), out price);
                bool res3 = int.TryParse(medicin["quantity"].ToString(), out quantity);
                med.ID = res1 ? id : 0;
                med.Price = res2 ? price : 0M;
                med.Quantity = res3 ? quantity : 0;
                med.Name = medicin["name"].ToString();
                med.Description = medicin["description"].ToString();

                medicins.Add(med);

            }
            return medicins;
        }


        public int UpdateMedicin(int id, int quantity)
        {
            int count = dataLayer.UpdateMedicin(id , quantity);
            return count;
        }

        public int UpdateRetreveMedicin(int id, int quantity)
        {
            int count = dataLayer.UpdateRetreveMedicin(id, quantity);
            return count;
        }


        public int UpdateOrderMedicin(int medicine_id, int order_id, int quantity)
        {
            int count = dataLayer.UpdateOrderMedicin(medicine_id, order_id , quantity);
            return count;
        }


        public int InsertNewOrder(decimal total_price)
        {
            int count = dataLayer.InsertNewOrder(total_price);
            return count;
        }


        public int InsertOrderMedicin(int medicine_id, int order_id, int quantity )
        {
            int count = dataLayer.InsertOrderMedicin(medicine_id, order_id , quantity );
            return count;
        }


        public List<Order> GetOrderId()
        {
            DataTable dataTable = dataLayer.GetOrderId();

            List<Order> orders = new List<Order>();
            foreach (DataRow Order in dataTable.Rows)
            {
                int id;
                Order order = new Order();
                //bool res1 = int.TryParse(Order["id"].ToString(), out id);
                order.Order_ID = (int)Order["id"];//res1 ? id : 0;

                orders.Add(order);

            }
            return orders;
        }


        public List<SalesRET> GetOrderById(int orderId , int medicinId)
        {
            DataTable dataTable = dataLayer.GetOrderById(orderId , medicinId);

            List<SalesRET> sales = new List<SalesRET>();
            foreach (DataRow order in dataTable.Rows)
            {
                
                SalesRET sal = new SalesRET();

                sal.Medicin_ID = (int)order["medicine_id"];
                sal.Order_ID = (int)order["order_id"];
                sal.quantity = (int)order["quantity"]; 

                sales.Add(sal);
            }
            return sales;
        }
        #endregion

        #region admin
        public List<Admin> GetAdmin()
        {
            DataTable dataTable = dataLayer.getAdmin();
            List<Admin> admins = new List<Admin>();
            foreach (DataRow admin in dataTable.Rows)
            {
                Admin c = new Admin();
                c.ID = Convert.ToInt32(admin["id"]);
                c.Username = admin["username"].ToString();
                c.Password = Convert.ToString(admin["password"]);

                admins.Add(c);
            }
            return admins;
        }
        public int UpdatAdmin(string Password, int id)
        {
            int count = dataLayer.UpdatAdmin(Password, id);
            return count;
        }
        #endregion

        #region medicin
        public List<Medicin> getMsdicin()
        {
            DataTable dataTable = dataLayer.getMsdicin();
            List<Medicin> medicins = new List<Medicin>();
            foreach (DataRow medici in dataTable.Rows)
            {

                decimal pric;
                int qunti;
                int i;

                Medicin _medicin = new Medicin();

                _medicin.ID = Convert.ToInt32(medici["id"]);
                _medicin.Name = medici["name"].ToString();
                _medicin.Description = medici["description"].ToString();
                bool res1 = int.TryParse(medici["quantity"].ToString(), out qunti);
                bool res = decimal.TryParse(medici["Price"].ToString(), out pric);
                bool res2 = int.TryParse(medici["medicine_company_id"].ToString(), out i);


                _medicin.Price = res ? pric : 0M;
                _medicin.Quantity = res1 ? qunti : 0;
                _medicin.company_Id = res2 ? i : 0;


                medicins.Add(_medicin);

            }
            return medicins;
        }
        public int Insertmesicin(string _name, string _description, decimal _price, int _quantity, int _company_Id)
        {
            int count = dataLayer.Insertmesicin(_name, _description, _price, _quantity, _company_Id);

            return count;
        }
        public int Updatemedicine(int _id, string _name, string _description, decimal _price, int _quantity, int _company_Id)
        {
            int count = dataLayer.Updatemedicine(_id, _name, _description, _price, _quantity, _company_Id);
            return count;
        }
        public int DeleteMsdicin(int _id)
        {

            int count = dataLayer.DeleteMsdicin(_id);
            return count;
        }
        #endregion

        #region company
        public List<Company_medicin> GetCompany_Medicins()
        {
            DataTable dataTable = dataLayer.GetCompanyMedicin();
            List<Company_medicin> companys = new List<Company_medicin>();
            foreach (DataRow company in dataTable.Rows)
            {
                Company_medicin c = new Company_medicin();
                c.ID = Convert.ToInt32(company["id"]);
                c.Name = company["name"].ToString();
                c.Address = company["address"].ToString();
                c.PhoneNumber =company["phone_number"].ToString();

                companys.Add(c);
            }
            return companys;
        }

        public int InsertCompanyMedicine(string name, string address, string phone_number)
        {
            int count = dataLayer.InsertCompanyMedicin(name, address, phone_number);
            return count;
        }


        public int UpdateCompanyMedicine(int id, string name, string address, string phone_number
            )
        {
            int count = dataLayer.UpdateCompanyMedicin(id, name, address, phone_number);
            return count;
        }
        public int DeleteCompanyMedicine(int id)

        {
            int count = dataLayer.DeleteCompanyMedicin(id);
            return count;
        }
        #endregion

        #region Reports

        public List<Company> GetCompany(string id)
        {
            DataTable dataTable = dataLayer.GetCompany(id);

            List<Company> companys = new List<Company>();
            foreach (DataRow company in dataTable.Rows)
            {
                Company c = new Company();

                c.ID = Convert.ToInt32(company["Company Id"]);
                c.Name = company["Company Name"].ToString();
                c.Address = company["address"].ToString();
                c.PhoneNumber = company["Phone_Number"].ToString();
                c.quantity = Convert.ToInt32(company["In Stock"]);
                c.Item = company["Item"].ToString();

                companys.Add(c);
            }
            return companys;
        }

        public ReportDocument CompanyReport()
        {

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"E:\C#\Final Design\Final Design\BLL\Reports\CompanyReport.rpt");
            return cryRpt;

        }

        public List<ItemDetails> GetItemDetails(string itemName)
        {
            DataTable dataTable = dataLayer.GetItemDetails(itemName);

            List<ItemDetails> items = new List<ItemDetails>();
            foreach (DataRow item in dataTable.Rows)
            {
                ItemDetails c = new ItemDetails();

                c.Name = item["Item"].ToString();
                c.Latest_Order_Date = Convert.ToDateTime(item["Latest_Order_Date"]);
                c.Description = item["Description"].ToString();
                c.company = item["Supplier Co."].ToString();
                c.Price = Convert.ToDecimal(item["Unit Price"]);
                c.Quantity = Convert.ToInt32(item["In Stock"]);
                c.sold = Convert.ToInt32(item["sold"]);

                items.Add(c);
            }
            return items;
        }




        public ReportDocument ItemDetails()
        {

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"E:\C#\Final Design\Final Design\BLL\Reports\ItemReport.rpt");

            return cryRpt;

        }


        public ReportDocument MedicineReport()
        {

            ReportDocument report = new ReportDocument();
            report.Load(@"E:\C#\Final Design\Final Design\BLL\Reports\MedicineReport.rpt");

            return report;
        }

        public ReportDocument SalesReport()
        {

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"E:\C#\Final Design\Final Design\BLL\Reports\SalesReport.rpt");

            return cryRpt;

        }

        public ReportDocument All_CompniesReport()
        {
            //WebClient client = new WebClient();
            //Stream stream = client.OpenRead("https://drive.google.com/file/d/1HXePty1SPBZ2OkZbyhZRxMCiV5XhD96K/view?usp=share_link"");
            //StreamReader reader = new StreamReader(stream);
            //String content = reader.ReadToEnd();
            //ReportDocument cryRpt = new ReportDocument();
            //cryRpt.Load(content);
            //cryRpt.Load(@"https://drive.google.com/file/d/1HXePty1SPBZ2OkZbyhZRxMCiV5XhD96K/view?usp=share_link");
            // Set the URL of the report file

            //string reportUrl = "https://drive.google.com/uc?id=1HXePty1SPBZ2OkZbyhZRxMCiV5XhD96K";

            //// Create a new instance of the WebClient class
            //WebClient client = new WebClient();
            //ReportDocument report = new ReportDocument();

            //    string tempPath = Path.GetTempFileName();
            //    client.DownloadFile(reportUrl, tempPath);

            //    report.Load(tempPath);

            ReportDocument report = new ReportDocument();
                report.Load(@"E:\C#\Final Design\Final Design\BLL\Reports\All_CompaniesReport.rpt");
            return report;

        }


        public List<Sales> invoiceDetails(int OrderId)
        {
            DataTable dataTable = dataLayer.getInvoice(OrderId);

            List<Sales> items = new List<Sales>();
            foreach (DataRow item in dataTable.Rows)
            {
                Sales c = new Sales();

                c.Item_Name = item["Item"].ToString();
                c.Order_Date = Convert.ToDateTime(item["Order Date"]);
                c.Customer_Name = item["Customer Name"].ToString();
                c.Order_ID = Convert.ToInt32(item["Order Id"]);
                c.Price = Convert.ToDecimal(item["Unit Price"]);
                c.quantity = Convert.ToInt32(item["Quantity"]);
                c.Total_price = Convert.ToInt32(item["price"]);
                c.Customer_ID = Convert.ToInt32(item["Customer Id"]);

                items.Add(c);
            }
            return items;
        }



        public ReportDocument InvoiceReport()
        {

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"E:\C#\Final Design\Final Design\BLL\Reports\InvoiceReport.rpt");

            return cryRpt;

        }

        public ReportDocument LastInvoiceReport()
        {

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"E:\C#\Final Design\Final Design\BLL\Reports\LastInvoiceReport.rpt");

            return cryRpt;

        }


        public ReportDocument All_invoiceByTime()
        {

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"E:\C#\Final Design\Final Design\BLL\Reports\GetInvoicesPeriod.rpt");
           

            return cryRpt;

        }
        #endregion


    }
}
