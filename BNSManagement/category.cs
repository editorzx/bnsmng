using BNSManagement.SourceFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BNSManagement
{
    public partial class category : Form
    {
        int global = 0;
        static string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
        SqlConnection CN = new SqlConnection(Conn);
        SqlDataAdapter adapt;

        public category()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            try
            {
                CN.Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select a.CategoryId,b.CategoryDisplayName,a.IsDisplayable from Categories a JOIN CategoryDisplay b ON a.CategoryId=b.CategoryId and b.LanguageCode=11", Conn);

                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].HeaderText = "ไอดี";
                dataGridView1.Columns[1].HeaderText = "ชื่อ";
                dataGridView1.Columns[2].HeaderText = "การแสดงผล";

                CN.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                name_box.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                checkBox1.Checked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                global = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
           
        }

        private void change_btn_Click(object sender, EventArgs e)
        {
            if (name_box.Text != "" && global != 0)
            {

                string qry = "update CategoryDisplay SET CategoryDisplayName=@Name where CategoryId=@ID and LanguageCode=11";
                string qry2 = "update Categories SET IsDisplayable=@Display where (CategoryId=@ID)";

                SqlCommand SqlCom = new SqlCommand(qry, CN);
                SqlCom.Parameters.Add(new SqlParameter("@Name", name_box.Text));
                SqlCom.Parameters.Add(new SqlParameter("@ID", global));

                SqlCommand SqlCom2 = new SqlCommand(qry2, CN);
                SqlCom2.Parameters.Add(new SqlParameter("@Display", checkBox1.Checked.ToString()));
                SqlCom2.Parameters.Add(new SqlParameter("@ID", global));

                try
                {
                    CN.Open();
                    SqlCom.ExecuteNonQuery();
                    SqlCom2.ExecuteNonQuery();
                    CN.Close();
                    init();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User ct = new User();
            ct.Show();
            this.Hide();
        }
    }
}
