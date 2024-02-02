using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SCM
{
    public partial class Form5 : Form
    {
        public SqlConnection cn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public DataSet ds = new DataSet();
        public SqlDataAdapter da=new SqlDataAdapter();
        //public BindingSource bs = new BindingSource();
        
        
        public Form5()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select from where you want to Search", "Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox1.Text == "")
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM customer", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    //bs.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM customer WHERE customer_id like '%" + textBox1.Text + "%'", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (textBox1.Text == "")
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM inventory", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM inventory WHERE inventory_no like '%" + textBox1.Text + "%'", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (textBox1.Text == "")
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM sinvoice", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM sinvoice WHERE sinvoice_no like '%" + textBox1.Text + "%'", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (textBox1.Text == "")
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM item_master", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM item_master WHERE item_name like '%" + textBox1.Text + "%'", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }
            if (comboBox1.SelectedIndex == 4)
            {
                if (textBox1.Text == "")
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM supplier", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM supplier WHERE supplier_id like '%" + textBox1.Text + "%'", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }
            if (comboBox1.SelectedIndex == 5)
            {
                if (this.Name=="Form5")
                {
                    MessageBox.Show("Access Denied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (textBox1.Text == "")
                    {
                        ds.Tables.Clear();
                        da = new SqlDataAdapter("SELECT user_id,fname,lname,gender,type,contact,email FROM user_master", cn);
                        ds.Clear();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.Refresh();
                    }
                    else
                    {
                        ds.Tables.Clear();
                        da = new SqlDataAdapter("SELECT user_id,fname,lname,gender,type,contact,email FROM user_master WHERE user_id like '%" + textBox1.Text + "%'", cn);
                        ds.Clear();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        dataGridView1.Refresh();
                    }
                }
            }
            if (comboBox1.SelectedIndex == 6)
            {
                if (textBox1.Text == "")
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM sales", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM sales WHERE sinvoice_no like '%" + textBox1.Text + "%'", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }
            if (comboBox1.SelectedIndex == 7)
            {
                if (textBox1.Text == "")
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM pinvoice", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM pinvoice WHERE pinvoice_no like '%" + textBox1.Text + "%'", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }



            if (comboBox1.SelectedIndex == 8)
            {
                if (textBox1.Text == "")
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM purchase", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM purchase WHERE pinvoice_no like '%" + textBox1.Text + "%'", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }


            if (comboBox1.SelectedIndex == 9)
            {
                if (textBox1.Text == "")
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM quantity", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
                else
                {
                    ds.Tables.Clear();
                    da = new SqlDataAdapter("SELECT * FROM quantity WHERE item_name like '%" + textBox1.Text + "%'", cn);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Refresh();
                }
            }
            


        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scm_mainDataSet.user_master' table. You can move, or remove it, as needed.
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}
