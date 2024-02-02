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
    public partial class Form14 : Form
    {

        SqlConnection cs = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlDataAdapter da = new SqlDataAdapter();

        StreamWriter log;



        public string autoincrement()
        {
            string last_val = null;
            int value;
            SqlCommand cmd = new SqlCommand("SELECT supplier_id FROM supplier", cs);
            cs.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read() == true)
            {
                last_val = rdr.GetString(0).ToString();
            }
            cs.Close();
            //MessageBox.Show(last_val);
            if (last_val != null)
            {
                last_val = last_val.Remove(0, 1);
                //MessageBox.Show(last_val);
                value = int.Parse(last_val);
                value += 1;
                last_val = "s" + value.ToString().PadLeft(3, '0');
                //MessageBox.Show(last_val);
                return last_val;
            }
            else
            {
                //MessageBox.Show("db empty");
                return "s001";
            }
        }



        string user = Properties.Settings.Default.usr;

        /*public bool check(string name)   //function for login starts
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM supplier WHERE supplier_id='" + name + "';");
            cmd.Connection = cs;
            cs.Open();
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
        }*/                                        //function for login ends 

        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scm_mainDataSet3.supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.scm_mainDataSet3.supplier);
            // TODO: This line of code loads data into the 'scm_mainDataSet1.item_master' table. You can move, or remove it, as needed.
            this.item_masterTableAdapter.Fill(this.scm_mainDataSet1.item_master);

            comboBox1.Text = autoincrement();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" | textBox1.Text == "" | textBox2.Text == "" | textBox4.Text=="" | comboBox2.Text=="")
            {
                MessageBox.Show("Required field's are empty", "Error");
            }
            else
            {

                //if (check(comboBox1.Text) == true)
                if (checkBox1.Checked == true)
                {
                    DialogResult dr1;
                    dr1 = MessageBox.Show("Do you want to update it?", "info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr1 == DialogResult.Yes)
                    {
                        cs.Close();
                        da.UpdateCommand = new SqlCommand("UPDATE supplier SET supplier_name='" + textBox1.Text + "',supplier_company_name='" + textBox2.Text + "',supplier_add='" + textBox3.Text + "',supplier_contact='" + textBox4.Text + "',email='" + textBox5.Text + "',website='"+textBox6.Text+"' WHERE supplier_id='" + comboBox1.Text + "'", cs);
                        cs.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        cs.Close();

                        log = File.AppendText(Form1.fileloc);
                        log.Write(DateTime.Now);
                        log.WriteLine("---User " + user + " updated supplier ID= " + comboBox1.Text);
                        log.Close();

                        comboBox1.Text = "";

                        this.supplierTableAdapter.Fill(this.scm_mainDataSet3.supplier);
                        
                        
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";

                        checkBox1.Checked = false;
                        comboBox1.Enabled = false;

                        textBox1.Focus();

                    }

                }
                else
                {

                    DialogResult dr;

                    dr = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        cs.Close();
                        da.InsertCommand = new SqlCommand("INSERT INTO supplier (supplier_id,supplier_name,supplier_company_name,supplier_add,supplier_contact,email,website,item_name) VALUES('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox2.Text + "')", cs);
                        cs.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        cs.Close();

                        log = File.AppendText(Form1.fileloc);
                        log.Write(DateTime.Now);
                        log.WriteLine("---User " + user + " added supplier ID= " + comboBox1.Text);
                        log.Close();

                        DialogResult dr1;
                        dr1 = MessageBox.Show("Do you want to add more Customer's?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr1 == DialogResult.Yes)
                        {
                            comboBox1.Text = "";

                            this.supplierTableAdapter.Fill(this.scm_mainDataSet3.supplier);
                            
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";


                            checkBox1.Checked = false;
                            comboBox1.Enabled = false;
                            comboBox1.Text = autoincrement();
                            textBox1.Focus();
                            
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
                        cs.Close();
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar !=' ')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '_' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '@' && (sender as TextBox).Text.IndexOf('@') > -1)
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Text = "Update";
                this.supplierTableAdapter.Fill(this.scm_mainDataSet3.supplier);
                comboBox1.Enabled = true;
            }
            else
            {
                button1.Text = "Add";
                comboBox1.Text = autoincrement();
                comboBox1.Enabled = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) | char.IsDigit(e.KeyChar) | char.IsLetter(e.KeyChar) | char.IsWhiteSpace(e.KeyChar) | char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
