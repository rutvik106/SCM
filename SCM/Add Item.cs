using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SCM
{
    public partial class Form10 : Form
    {
        
        SqlConnection cn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlDataAdapter da = new SqlDataAdapter();

        StreamWriter log;

        string user = Properties.Settings.Default.usr;

        public bool check(string name)   //function for login starts
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM item_master WHERE item_name='" + name + "';");
            cmd.Connection = cn;
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() != false)
            {
                if (reader.IsDBNull(0) == true)
                {
                    cmd.Connection.Close();
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
                else
                {
                    cmd.Connection.Close();
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }                                         //function for login ends 


        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" | textBox3.Text == "")
            {
                MessageBox.Show("Required field's are empty", "Error");
            }
            else
            {
                float f = float.Parse(textBox3.Text);
                if (check(comboBox1.Text) == true)
                {
                    DialogResult dr2;
                    dr2 = MessageBox.Show("Item already exist do you want to update it?", "info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr2 == DialogResult.Yes)
                    {
                        cn.Close();
                        da.UpdateCommand = new SqlCommand("UPDATE item_master SET item_desc='" + textBox2.Text + "',rate='" + f + "',vat='" + textBox1.Text + "',excise='" + textBox4.Text + "' WHERE item_name='" + comboBox1.Text + "'", cn);
                        cn.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        cn.Close();

                        log = File.AppendText(Form1.fileloc);
                        log.Write(DateTime.Now);
                        log.WriteLine("---User " + user + " updated item= " + comboBox1.Text);
                        log.Close();

                        comboBox1.Text="";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox1.Text = "";
                        textBox4.Text = "";
                        comboBox1.Focus();
                        this.item_masterTableAdapter.Fill(this.scm_mainDataSet1.item_master);

                    }

                }
                else
                {

                    DialogResult dr;

                    dr = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        cn.Close();
                        da.InsertCommand = new SqlCommand("INSERT INTO item_master(item_name,item_desc,rate,vat,excise) VALUES('" + comboBox1.Text + "','" + textBox2.Text + "','" + f + "','" + textBox1.Text + "','" + textBox4.Text + "')", cn);

                        cn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        cn.Close();
                        da.InsertCommand = new SqlCommand("INSERT INTO quantity(item_name,qty) VALUES('" + comboBox1.Text + "',0.0)", cn);
                        cn.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        cn.Close();

                        log = File.AppendText(Form1.fileloc);
                        log.Write(DateTime.Now);
                        log.WriteLine("---User " + user + " added new item= " + comboBox1.Text);
                        log.Close();

                        DialogResult dr1;
                        dr1 = MessageBox.Show("Do you want to add more Items's?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr1 == DialogResult.Yes)
                        {
                            comboBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox1.Text = "";
                            textBox4.Text = "";
                            comboBox1.Focus();

                            this.item_masterTableAdapter.Fill(this.scm_mainDataSet1.item_master);
                        }
                        else
                        {
                            if (dr1 == DialogResult.No)
                            {
                                this.Dispose();
                            }
                        }
                    }
                    else
                    {
                        cn.Close();
                    }
                }
            }

            
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scm_mainDataSet1.item_master' table. You can move, or remove it, as needed.
            
                //this.item_masterTableAdapter.Fill(this.scm_mainDataSet1.item_master);
                this.item_masterTableAdapter.Fill(this.scm_mainDataSet1.item_master);
            
            

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form7.f19.ShowDialog(this);
        }
    }
}
