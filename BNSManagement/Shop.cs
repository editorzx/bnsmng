using BNSManagement.SourceFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace BNSManagement
{
    
    public partial class Shop : Form
    {
        int idmaincat = 0;
        public class ComboboxItem
        {
            public string Name { get; set; }
            public object ID { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
        public Shop()
        {
            InitializeComponent();
            listView1.View = View.Details;

            listView1.Columns.Add("id");
            listView1.Columns.Add("alias");
            listView1.Columns.Add("name");
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void initcat()
        {
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
                    comboBox2.Items.Add(item);
                }
                CN.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        List<ListViewItem> allItems = new List<ListViewItem>();
        public void init(string isFile)
        {
            listView1.Items.Clear();

            string checkedx = checking(isFile);
            XDocument doc = XDocument.Load(checkedx);
            XDocument doc2;
            foreach (var dm in doc.Descendants("record"))
            {
                string name = "XXX";
               /* bool foundname = false;

                for (int i = 1; i < 10; i++)
                {
                    if (!foundname)
                    {
                        string datafile = "th_item" + i + ".xml";
                        if (File.Exists(datafile))
                        {
                            doc2 = XDocument.Load(datafile);
                            foreach (var dm2 in doc2.Descendants("text"))
                            {
                                if (dm.Attribute("alias").Value == dm2.Attribute("alias").Value)
                                {
                                    name = dm2.Element("replacement").Value;
                                    foundname = true;
                                    break;
                                }
                            }
                        }
                        else
                            break;
                    }
                    else
                        break;
                }*/
                    ListViewItem item = new ListViewItem(new string[]
                    {
                         dm.Attribute("id").Value,
                         dm.Attribute("alias").Value,
                         name,
                        //dm.Element("id").Value,
                     });
                     listView1.Items.Add(item);
               // break;
                 }
                this.groupBox1.Enabled = true;
                this.serach_box.Enabled = true;
            allItems.Clear();
            allItems.AddRange(listView1.Items.Cast<ListViewItem>());
        }

        private string checking(string file)
        {
            if (file == "weapon")
                return "weapon.xml";
            else if (file == "accessory")
                return "accessory.xml";
            else if (file == "costume")
                return "costume.xml";
            else if (file == "grocery")
                return "grocery.xml";
            else if (file == "pet[beta]")
                return "pet.xml";
            else
                return "unknow.xml";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            init(comboBox1.Text);
            initcat();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            this.id_tx.Text = listView1.SelectedItems[0].Text.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            // MessageBox.Show((comboBox2.SelectedItem as ComboboxItem).ID.ToString());
            idmaincat = Convert.ToInt32((comboBox2.SelectedItem as ComboboxItem).ID);
            string Conn = "Server=" + globals.Server + "; Database=GoodsDb; User Id=" + globals.User + ";Password=" + globals.Pass + ";";
            SqlConnection CN = new SqlConnection(Conn);
            try
            {
                CN.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter("select a.CategoryId,b.CategoryDisplayName from Categories a JOIN CategoryDisplay b ON a.CategoryId=b.CategoryId and b.LanguageCode=11 and ParentCategoryId="+ idmaincat+ " and IsDisplayable=1", Conn);
                adapt.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    ComboboxItem item = new ComboboxItem();
                    item.ID = dr[0];
                    item.Name = dr[1].ToString();
                    comboBox3.Items.Add(item);
                }
                CN.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox2_TextUpdate(object sender, EventArgs e)
        {
            return;
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(gname_tx.Text) || String.IsNullOrEmpty(price_tx.Text) || String.IsNullOrEmpty(id_tx.Text) || comboBox2.SelectedIndex == -1)
                return;
            else
            {
                if(comboBox3.SelectedIndex != -1)
                    comitproduce.GoodsAdd(gname_tx.Text, price_tx.Text, id_tx.Text, (comboBox2.SelectedItem as ComboboxItem).ID.ToString(), (comboBox3.SelectedItem as ComboboxItem).ID.ToString(), desc_box.Text);
                else
                    comitproduce.GoodsAdd(gname_tx.Text, price_tx.Text, id_tx.Text, (comboBox2.SelectedItem as ComboboxItem).ID.ToString(), null, desc_box.Text);
            }
        }

        private void serach_box_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (serach_box.Text != "")
            {
                var list = allItems.Cast<ListViewItem>()
                       .Where(x => x.SubItems.Cast<ListViewItem.ListViewSubItem>().Any(y => y.Text.Contains(serach_box.Text))).ToArray();
                listView1.Items.AddRange(list);
            }
            else
                listView1.Items.AddRange(allItems.ToArray());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            User ct = new User();
            ct.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void price_tx_TextChanged(object sender, EventArgs e)
        {

        }

        private void price_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
