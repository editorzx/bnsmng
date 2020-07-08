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
    public partial class Addcategory : Form
    {
        public class ComboboxItem
        {
            public string Name { get; set; }
            public object ID { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public Addcategory()
        {
            InitializeComponent();
        }

        private void Addcategory_Load(object sender, EventArgs e)
        {
            initcat();
        }

        private void initcat()
        {
            comboBox1.Items.Clear();
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);
            try
            {
                CN.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter("select a.CategoryId,b.CategoryDisplayName from Categories a JOIN CategoryDisplay b ON a.CategoryId=b.CategoryId and b.LanguageCode=11 and ParentCategoryId=48 and CategoryData='{\"CategoryType\":[\"01\"]}'", Conn);
                adapt.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ComboboxItem item = new ComboboxItem();
                    item.ID = dr[0];
                    item.Name = dr[1].ToString();
                    comboBox1.Items.Add(item);
                }
                CN.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comitproduce.CategoryMainAdd(textBox1.Text);
            initcat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comitproduce.CategoryMainAdd(Convert.ToInt32((comboBox1.SelectedItem as ComboboxItem).ID), textBox2.Text);
        }

        private void ย้อนกลับ_Click(object sender, EventArgs e)
        {
            User ct = new User();
            ct.Show();
            this.Hide();
        }
    }
}
