using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Design
{
    public partial class Forget_Password : Form
    {
        BusinessLayer businessLayer = new BusinessLayer();
        public Forget_Password()
        {
            InitializeComponent();
        }

        #region update
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    List<Admin> admins = businessLayer.GetAdmin();
        //    LogIn logIn = new LogIn();
        //    int id = Convert.ToInt32(textBox1.Text), flag = 0;
        //    string password = textBox2.Text;
        //    foreach(Admin admin in admins)
        //    {
        //        if (admin.Username == logIn.username)
        //        {
        //            if(admin.ID == id)
        //            {
        //                businessLayer.UpdatAdmin(password, id);
        //                MessageBox.Show("Password is Updated");
        //                break;
        //            }   
        //        }else{ MessageBox.Show("This Username Not Found!"); break; }
        //        flag++;
        //    } if(flag == admins.Count) MessageBox.Show("ID Not Corrected");

        //}



        #endregion

        #region Event
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(33, 116, 144);
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            textBox2.ForeColor = Color.Black;
        }
        #endregion

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void Forget_Password_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
