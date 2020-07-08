using BNSManagement.SourceFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BNSManagement
{
    public partial class User : Form
    {
        SystemMenuManager menuManager;
        public User()
        {
            InitializeComponent();
            string text = File.ReadAllText("sqlpass.txt");
            if (text != null)
                pass_tx.Text = text;
            this.menuManager = new SystemMenuManager(this, false);
            globals.uForm = this;
            if(globals.statuslog)
            {
                globals.uForm.cat_btn.Enabled = true;
                globals.uForm.shop_btn.Enabled = true;
                globals.uForm.connect_btn.Enabled = false;
                globals.uForm.button5.Enabled = true;
                globals.uForm.button2.Enabled = true;
            }
        }

        private void connect_btn_Click(object sender, EventArgs e)
        {
            connected.Connect(ip_tx.Text,user_tx.Text,pass_tx.Text);
        }

        private void cat_btn_Click(object sender, EventArgs e)
        {
            category ct = new category();
            ct.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("EXIT");
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Shop ct = new Shop();
            ct.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reloaded ct = new Reloaded();
            ct.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Addcategory ct = new Addcategory();
            ct.Show();
            this.Hide();
        }
    }
}
