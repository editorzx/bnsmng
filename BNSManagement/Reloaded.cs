using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace BNSManagement
{
    public partial class Reloaded : Form
    {
        public Reloaded()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User ct = new User();
            ct.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            var values = new NameValueCollection();
            values["pass"] = "okxmsk#ppkoxmjs";
            values["data"] = "shopxyz";

            var response = client.UploadValues("http://154.202.3.61:81/svscript/reloaded.php", values);

            var responseString = Encoding.Default.GetString(response);

            MessageBox.Show(responseString);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            var values = new NameValueCollection();
            values["pass"] = "okxmsk#ppkoxmjs";
            values["data"] = "authxyz";

            var response = client.UploadValues("http://154.202.3.61:81/svscript/reloaded.php", values);

            var responseString = Encoding.Default.GetString(response);

            MessageBox.Show(responseString);
        }
    }
}
