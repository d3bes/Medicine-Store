
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Medicine_Store_Manger; 

namespace Final_Design
{
    public partial class Make_Order : Form
    {
        BusinessLayer businessLayer = new BusinessLayer();
        public Make_Order()
        {
            InitializeComponent();
            DisplayMedicin();
        }

        private void DisplayMedicin()
        {
            List<Medicin> medicins = businessLayer.GetMedicins();
            dataGridView1.DataSource = medicins;
        }

        public void DecreaseQuantity(int id, int quantity)
        {

            try
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                //int Id = (int)row.Cells[0].Value;

                // quantity = (int)textBox1.Text.ToString();

                businessLayer.UpdateMedicin(id, quantity);
            }
            catch
            {
                Console.WriteLine("error(0)");
            }
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string name = Search.Text;
                List<Medicin> medicins = businessLayer.Search(name);
                dataGridView1.DataSource = medicins;
            }
            catch
            {
                Console.WriteLine("error(0)");

            }
        }



        int id;
        string name;
        string description;
        decimal price;
        int quantity;

        int OrderQuantity;
        int TotalPrice = 0;

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Medicin medicin = new Medicin();

                id = (int)row.Cells[0].Value;
                name = row.Cells[1].Value.ToString();
                description = row.Cells[2].Value.ToString();
                price = (decimal)row.Cells[3].Value;
                quantity = (int)row.Cells[4].Value;


                medicin.ID = id;
                medicin.Name = name;
                medicin.Description = description;
                medicin.Price = price;
                medicin.Quantity = quantity;

                medicins.Add(medicin);



            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = medicins;

        }


        List<Medicin> medicins = new List<Medicin>();
        private void Add_to_card_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if ((int)row.Cells[4].Value > 0)
                {
                    Medicin medicin = new Medicin();

                    id = (int)row.Cells[0].Value;
                    name = row.Cells[1].Value.ToString();
                    description = row.Cells[2].Value.ToString();
                    price = (decimal)row.Cells[3].Value;
                    if (textBox1.Text.Length <= 0)
                    {
                        OrderQuantity = 1;
                    }
                    else
                    {
                        OrderQuantity = Convert.ToInt32(textBox1.Text.ToString());
                    }
                    //quantity = (int)row.Cells[4].Value;

                    medicin.ID = id;
                    medicin.Name = name;
                    medicin.Description = description;
                    medicin.Price = price;
                    medicin.Quantity = OrderQuantity;

                    medicins.Add(medicin);

                    TotalPrice += (int)(OrderQuantity * price);
                }
                else
                {
                    MessageBox.Show($"{row.Cells[1].Value.ToString()} is out of stock");
                }

            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = medicins;
            textBox1.Text = "";
            Search.Text = "";
        }

        private void Total_Price_Click(object sender, EventArgs e)
        {
            textBox2.Text = TotalPrice.ToString();
        }



        private void Save_Order_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order();
                order.Total_price = TotalPrice;
                businessLayer.InsertNewOrder(order.Total_price);
                List<Order> orders = businessLayer.GetOrderId();
                int id = 0;

                foreach (var item in orders)
                {
                    id = item.Order_ID;
                }
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    SalesRET sales = new SalesRET();


                    sales.Medicin_ID = (int)row.Cells[0].Value;
                    sales.Order_ID = id;
                    sales.quantity = (int)row.Cells[4].Value;
                    sales.Price = (decimal)row.Cells[3].Value;

                    businessLayer.InsertOrderMedicin(sales.Medicin_ID, id, sales.quantity);
                    DecreaseQuantity(sales.Medicin_ID, sales.quantity);

                }
                DisplayMedicin();
                dataGridView2.DataSource = null;
                textBox2.Text = TotalPrice.ToString();
                medicins.Clear();
                MessageBox.Show("Order done successfully");

                InvoiceForm invoiceForm = new InvoiceForm(id);  //Report
                invoiceForm.Show();
            }
            catch
            {
                Console.WriteLine("error(0)");

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                int orderId = int.Parse(serchOrder.Text);
                int medicineID = int.Parse(medicineId.Text);
                List<SalesRET> sales = businessLayer.GetOrderById(orderId, medicineID);
                dataGridView2.DataSource = sales;

                serchOrder.Text = "";
                medicineId.Text = "";
            }
            catch
            {
                Console.WriteLine("error(0)");
            }
        }
        private void Save_Reteve_Order_Click(object sender, EventArgs e)
        {
            try
            {
                int NewQuantity = int.Parse(textBox3.Text);

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if ((int)row.Cells[3].Value > 0)
                    {
                        SalesRET sal = new SalesRET();
                        sal.Order_ID = (int)row.Cells[0].Value;
                        sal.Medicin_ID = (int)row.Cells[1].Value;
                        //price = (decimal)row.Cells[2].Value;
                        //sal.quantity = (int)row.Cells[3].Value;

                        businessLayer.UpdateRetreveMedicin(sal.Medicin_ID, NewQuantity);
                        businessLayer.UpdateOrderMedicin(sal.Medicin_ID, sal.Order_ID, NewQuantity);

                        DisplayMedicin();
                        dataGridView2.DataSource = null;
                        textBox3.Text = "";
                        MessageBox.Show("Done");
                    }
                    else
                    {
                        MessageBox.Show("Sorry Can't Retreve");
                    }
                }
            }
            catch
            {
                Console.WriteLine("error(0)");
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this card?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {

            }
            else
            {
                dataGridView2.DataSource = null;
                medicins.Clear();
                MessageBox.Show("card deleted successfully.");
            }

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();    
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int orderId = int.Parse(serchOrder.Text);
            int medicineID = int.Parse(medicineId.Text);
            List<SalesRET> sales = businessLayer.GetOrderById(orderId, medicineID);
            dataGridView2.DataSource = sales;

            serchOrder.Text = "";
            medicineId.Text = "";
        }

        private void Search_TextChanged_1(object sender, EventArgs e)
        {
            string name = Search.Text;
            List<Medicin> medicins = businessLayer.Search(name);
            dataGridView1.DataSource = medicins;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Total_price = TotalPrice;
            businessLayer.InsertNewOrder(order.Total_price);
            List<Order> orders = businessLayer.GetOrderId();
            int id = 0;
            ref int idd = ref id;
            foreach (var item in orders)
            {
                id = item.Order_ID;
            }
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                Sales sales = new Sales();


                sales.Medicin_ID = (int)row.Cells[0].Value;
                sales.Order_ID = id;
                sales.quantity = (int)row.Cells[4].Value;
                sales.Price = (decimal)row.Cells[3].Value;

                businessLayer.InsertOrderMedicin(sales.Medicin_ID, id, sales.quantity);
                DecreaseQuantity(sales.Medicin_ID, sales.quantity);

            }

            id = idd;
            DisplayMedicin();
            dataGridView2.DataSource = null;
            textBox2.Text = TotalPrice.ToString();
            medicins.Clear();


            InvoiceForm invoiceForm = new InvoiceForm(id);  //Report
            invoiceForm.Show();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            InvoiceByDays invoice = new InvoiceByDays();
            invoice.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckSalesReport report = new CheckSalesReport();
            report.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Make_Order_Load(object sender, EventArgs e)
        {

        }
    }
}
