using BNSManagement.SourceFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BNSManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string User = textBox1.Text;
            string Pass = textBox2.Text;

            if (User == "kdxr" && Pass == "1234")
            {
                MessageBox.Show("เข้าสู่ระบบสำเร็จ! ");
                User ct = new User();
                ct.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("ข้อมูลไม่ถูกต้อง! ");
            }
        }
    }
}
