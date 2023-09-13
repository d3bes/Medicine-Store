using BLL;
using Final_Design;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Medicine_Store
{
    public partial class medicine : Form
    {
        BusinessLayer businessLayer = new BusinessLayer();
        public medicine()
        {
           
            InitializeComponent();


            Displaymadicin();

            button1.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;
            numeric_ID.Text = "";


            button1.FlatAppearance.BorderColor = Color.FromArgb(33, 116, 144);
            button2.FlatAppearance.BorderColor = Color.FromArgb(33, 116, 144);
            button4.FlatAppearance.BorderColor = Color.FromArgb(33, 116, 144);

            panel1.BackColor = Color.FromArgb(139, 217, 234);
            dataGridView1.BackgroundColor = Color.FromArgb(139, 217, 234);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numeric_ID.Text = "";
            Name_Medicin_text.Text = "";
            _price_text.Text = "";
            _description_text.Text = "";
            numeric_quantity.Text = "";
            numeric_Company_ID.Text = "";
        }
        private void Displaymadicin()
        {
            List<Medicin> medicine = businessLayer.getMsdicin();
            dataGridView1.DataSource = medicine;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            numeric_ID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Name_Medicin_text.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            _description_text.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            _price_text.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            numeric_quantity.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            numeric_Company_ID.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();



            button1.Enabled = false;
            button2.Enabled = true;
            button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int _id =Convert.ToInt32(numeric_ID.Text);
            string _name = Name_Medicin_text.Text;
            string _description = _description_text.Text;
            decimal _price = Convert.ToInt32(_price_text);
            int _quantity = (int)numeric_quantity.Value;
            int _company_Id = (int)numeric_Company_ID.Value;


            businessLayer.Insertmesicin(_name, _description, _price, _quantity, _company_Id);

            Displaymadicin();
            numeric_ID.Text = "";
            Name_Medicin_text.Text = "";
            _price_text.Text = "";
            _description_text.Text = "";
            _price_text.Value = 0;
            numeric_quantity.Value = 0;
            numeric_Company_ID.Value = 0;

            MessageBox.Show("The item has been added successfully");
            button1.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selection = int.Parse(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());

            businessLayer.DeleteMsdicin(selection);

            Displaymadicin();
            numeric_ID.Text = "";
            Name_Medicin_text.Text = "";
            _price_text.Text = "";
            _description_text.Text = "";
            _price_text.Value = 0;
            numeric_quantity.Value = 0;
            numeric_Company_ID.Value = 0;

            MessageBox.Show("The row has been deleted successfully");
            button1.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;

        }
        private void button4_Click(object sender, EventArgs e)
        {
            int _id = int.Parse(numeric_ID.Text);
            string _name = Name_Medicin_text.Text;
            string _description = _description_text.Text;
            decimal _price = (int)_price_text.Value;
            int _quantity = (int)numeric_quantity.Value;
            int _company_Id = (int)numeric_Company_ID.Value;

            businessLayer.Updatemedicine(_id, _name, _description, _price, _quantity, _company_Id);
            Displaymadicin();
            numeric_ID.Text = "";
            Name_Medicin_text.Text = "";
            _price_text.Text = "";
            _description_text.Text = "";
            _price_text.Value = 0;
            numeric_quantity.Value = 0;
            numeric_Company_ID.Value = 0;

            button1.Enabled = true;
            button2.Enabled = false;
            button4.Enabled = false;
            MessageBox.Show("The data has been changed and saved successfully");

        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void medicine_Load(object sender, EventArgs e)
        {

        }

        private void numeric_ID_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numeric_quantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {

        }
    }
}
