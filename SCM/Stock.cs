using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace SCM
{
    public partial class Form19 : Form
    {


        SqlConnection cn = new SqlConnection(Properties.Settings.Default.scm_mainConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        public static string id = null;
        public static string sub = null;
        public static string msg = null;

        public void fetch_mailid()
        {
            textBox3.Text = "";
            da.SelectCommand = new SqlCommand("SELECT email FROM supplier WHERE item_name='" + textBox1.Text + "' AND supplier_name='" + comboBox1.Text + "'", cn);
            cn.Open();
            SqlDataReader rdr = da.SelectCommand.ExecuteReader();
            while (rdr.Read() == true)
            {
                textBox3.Text = rdr.GetString(0);
            }
            cn.Close();

        }


        public void fill_supplier()
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            da.SelectCommand = new SqlCommand("SELECT supplier_name FROM supplier WHERE item_name='" + textBox1.Text + "'", cn);
            cn.Open();
            SqlDataReader rdr = da.SelectCommand.ExecuteReader();
            while (rdr.Read() == true)
            {
                comboBox1.Items.Add(rdr.GetValue(0));
            }
            cn.Close();
            rdr.Dispose();
            
            try
            {
                textBox3.Text = "";
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception)
            {
                comboBox1.Items.Clear();
            }
        }


        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

            

            // TODO: This line of code loads data into the 'qty_details.quantity' table. You can move, or remove it, as needed.
            da.SelectCommand = new SqlCommand("SELECT * FROM quantity", cn);
            ds.Clear();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            bs.DataSource = ds.Tables[0];
            try
            {
                textBox1.DataBindings.Add(new Binding("Text", bs, "item_name"));
                textBox2.DataBindings.Add(new Binding("Text", bs, "qty"));
            }
            catch (Exception)
            {
                
            }
            fill_supplier();

        }

        private void Form19_FormClosing(object sender, FormClosingEventArgs e)
        {

            id = "";
            sub = "";
            msg = "";
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            this.Hide();
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                bs.MoveNext();
                dataGridView1.ClearSelection();
                dataGridView1.Rows[bs.Position].Selected = true;
                fill_supplier();
            }
            catch (Exception)
            {

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                bs.MovePrevious();
                dataGridView1.ClearSelection();
                dataGridView1.Rows[bs.Position].Selected = true;
                fill_supplier();
            }
            catch (Exception)
            {

            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.SetToolTip(button1, "Send Order request using quick mail service");
            toolTip1.Show("Send Order request using quick mail service", button1, 2000);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fetch_mailid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" | comboBox1.Text=="")
            {
                MessageBox.Show("Select Supplier and Enter E-mail address");
            }
            else
            {
                try
                {
                    if (float.Parse(textBox2.Text) <= float.Parse(Properties.Settings.Default.min_val))
                    {
                        Form17 f17 = new Form17();
                        id = textBox3.Text;
                        sub = "alert about low inventory levels";
                        msg = "this is to inform you that the quantity of " + textBox1.Text + " is LOW(" + textBox2.Text + " Kg)";
                        f17.ShowDialog(this);
                    }

                    else
                    {
                        DialogResult dr;
                        dr = MessageBox.Show("Quantity is ok. Do you still want to place an order?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            Form17 f17 = new Form17();
                            id = textBox3.Text;
                            sub = "Order request from shankar chemicals";
                            f17.ShowDialog(this);
                        }
                        else
                        {

                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
