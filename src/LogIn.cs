
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
    public partial class LogIn : Form
    {

        public string username { set; get; }
        public LogIn()
        {
            InitializeComponent();
        }

        #region login
        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        #endregion



        #region Events
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(33, 116, 144);
        }
        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(53, 237, 205);
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor =  Color.White;
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

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            Application.Exit();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            username = this.textBox1.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Forget_Password forget = new Forget_Password();
            forget.ShowDialog();    
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
