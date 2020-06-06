using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BNSManagement.SourceFile
{
    class connected
    {
        public static void Connect(string Ip, string user,string pass)
        {
            string Conn = "Server="+Ip+ "; Database=BlGame01; User Id="+ user + ";Password="+ pass + ";";
            SqlConnection CN = new SqlConnection(Conn);
            try
            {
                CN.Open();
                
                globals.uForm.cat_btn.Enabled = true;
                globals.uForm.shop_btn.Enabled = true;
                globals.uForm.button5.Enabled = true;
                globals.Server = Ip;
                globals.User = user;
                globals.Pass = pass;
                globals.statuslog = true;
                CN.Close();

                MessageBox.Show("เชื่อมต่อเซิฟเวอร์เรียบร้อย");
            }
            catch (Exception ex)
            {
                MessageBox.Show("มีปัญหาในการติดต่อ: "/*+ ex*/);
            }
        }
    }
}
