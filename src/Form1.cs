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
    public partial class Form1 : Form
    {
       BusinessLayer businessLayer = new BusinessLayer();
        public Form1()
        {
            InitializeComponent();
            List<Company_medicin> companies = businessLayer.GetCompany_Medicins();
            dataGridView1.DataSource = companies;

            Add.FlatAppearance.BorderColor = Color.FromArgb(33, 116, 144);
            Delete.FlatAppearance.BorderColor = Color.FromArgb(33, 116, 144);
            Update.FlatAppearance.BorderColor = Color.FromArgb(33, 116, 144);

            panel1.BackColor = Color.FromArgb(139, 217, 234);
            dataGridView1.BackgroundColor= Color.FromArgb(139, 217, 234);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            int id = (int)Id.Value;
            string name = Name.Text;
            string address = Address.Text;
            string phone_number = Phone.Text;

            businessLayer.InsertCompanyMedicine(id, name, address, phone_number);

            List<Company_medicin> companies = businessLayer.GetCompany_Medicins();
            dataGridView1.DataSource = companies;

            Clear();
        }

        public void Clear()
        {
            Name.Text = string.Empty;
            Address.Text = string.Empty;
            Phone.Text = string.Empty;

        }
        private void Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Id_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];


            if (dataGridView1.SelectedRows.Count > 0)
            {
                row.Cells[0].Value = (int)Id.Value;
                row.Cells[1].Value = Name.Text;
                row.Cells[2].Value = Address.Text;
                row.Cells[3].Value = Phone.Text;
                dataGridView1.Refresh();

                businessLayer.UpdateCompanyMedicine((int)Id.Value, Name.Text, Address.Text, Phone.Text);

                dataGridView1.DataSource = "";
                dataGridView1.DataSource = businessLayer.GetCompany_Medicins();

            }
            else
                MessageBox.Show("please select Row");


            Clear();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                Id.Value = int.Parse(row.Cells[0].Value.ToString());
                Name.Text = row.Cells[1].Value.ToString();
                Address.Text = row.Cells[2].Value.ToString();
                Phone.Text = row.Cells[3].Value.ToString();




            }



        }

        private void Delete_Click(object sender, EventArgs e)
        {



            DataGridViewRow row = dataGridView1.SelectedRows[0];


            if (dataGridView1.SelectedRows.Count > 0)
            {
                row.Cells[0].Value = 0;
                row.Cells[1].Value = "";
                row.Cells[2].Value = "";
                row.Cells[3].Value = 0;
                dataGridView1.Refresh();

                businessLayer.DeleteCompanyMedicine((int)Id.Value);

                dataGridView1.DataSource = "";
                dataGridView1.DataSource = businessLayer.GetCompany_Medicins();

            }
            else
                MessageBox.Show("please select Row");

            Clear();


        }

        private void Add_MouseHover(object sender, EventArgs e)
        {
            Add.BackColor = Color.FromArgb(33, 116, 144);
            Add.ForeColor = Color.White;
        }

        private void Add_MouseLeave(object sender, EventArgs e)
        {
            Add.BackColor = Color.White;
            Add.ForeColor = Color.Black;
        }


        private void Delete_MouseHover(object sender, EventArgs e)
        {
            Delete.BackColor = Color.FromArgb(33, 116, 144);
            Delete.ForeColor = Color.White;
        }

        private void Delete_MouseLeave(object sender, EventArgs e)
        {
            Delete  .BackColor = Color.White;
            Delete.ForeColor = Color.Black;
        }

        private void Update_MouseHover(object sender, EventArgs e)
        {
            Update.BackColor = Color.FromArgb(33, 116, 144);
            Update.ForeColor = Color.White;
        }

        private void Update_MouseLeave(object sender, EventArgs e)
        {
            Update.BackColor = Color.White;
            Update.ForeColor = Color.Black;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {   
            Home home = new Home();
            home.Show();    
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
