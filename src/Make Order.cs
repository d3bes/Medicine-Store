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
using Medicine_Store;

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
            //DataGridViewRow row = dataGridView1.SelectedRows[0];
            //int id = (int)row.Cells[0].Value;

            //quantity = (int)row.Cells[4].Value;

            businessLayer.UpdateMedicin(id, quantity);
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            string name = Search.Text;
            List<Medicin> medicins = businessLayer.Search(name);
            dataGridView1.DataSource = medicins;
        }



        int id;
        string name;
        string description;
        decimal price;
        int quantity;

        int OrderQuantity;
        int TotalPrice = 0;

        //private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{

        //    //foreach (DataGridViewRow row in dataGridView1.SelectedRows)
        //    //{
        //    //Medicin medicin = new Medicin();

        //    //    id = (int)row.Cells[0].Value;
        //    //    name = row.Cells[1].Value.ToString();
        //    //    description = row.Cells[2].Value.ToString();
        //    //    price = (decimal)row.Cells[3].Value;
        //    //    quantity = (int)row.Cells[4].Value;


        //    //    medicin.ID = id;
        //    //    medicin.Name = name;
        //    //    medicin.Description = description;
        //    //    medicin.Price = price;
        //    //    medicin.Quantity = quantity;

        //    //    medicins.Add(medicin);



        //    //}
        //    //dataGridView2.DataSource = null;
        //    //dataGridView2.DataSource = medicins;

        //}


   
        private void Add_to_card_Click(object sender, EventArgs e)
        {

        }

        private void Total_Price_Click(object sender, EventArgs e)
        {
            textBox2.Text = TotalPrice.ToString();
        }



        private void Save_Order_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            int orderId = int.Parse(serchOrder.Text);
            int medicineID = int.Parse(medicineId.Text);
            List<retriveSales> sales = businessLayer.GetOrderById(orderId, medicineID);
            dataGridView2.DataSource = sales;

            serchOrder.Text = "";
            medicineId.Text = "";

        }



        private void Save_Reteve_Order_Click(object sender, EventArgs e)
        {
            int NewQuantity = int.Parse(textBox3.Text);

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if ((int)row.Cells[3].Value > 0)
                {
                    Sales sal = new Sales();
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

        private void Add_to_card_Click(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();    
            this.Hide();
        }

        private void Make_Order_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save_Reteve_Order_Click_1(object sender, EventArgs e)
        {
            int NewQuantity = int.Parse(textBox3.Text);

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if ((int)row.Cells[2].Value > 0)
                {
                    Sales sal = new Sales();
                    sal.Order_ID = (int)row.Cells[0].Value;
                    sal.Medicin_ID = (int)row.Cells[1].Value;
                    //price = (decimal)row.Cells[2].Value;
                    sal.quantity = (int)row.Cells[2].Value;

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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Total_price = TotalPrice;
            businessLayer.InsertNewOrder(order.Total_price, order.Order_Date);
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
        
#pragma warning disable CS0102 // The type 'Make_Order' already contains a definition for 'medicins'
        List<Medicin> medicins = new List<Medicin>();
#pragma warning restore CS0102 // The type 'Make_Order' already contains a definition for 'medicins'
        private void Add_to_card_Click_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            CheckSalesReport report = new CheckSalesReport();
            report.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InvoiceByDays invoice = new InvoiceByDays();
            invoice.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int orderId = int.Parse(serchOrder.Text);
            int medicineID = int.Parse(medicineId.Text);
            List<retriveSales> sales = businessLayer.GetOrderById(orderId, medicineID);
            dataGridView2.DataSource = sales;

            serchOrder.Text = "";
            medicineId.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
