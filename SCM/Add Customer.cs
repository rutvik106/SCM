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
    public partial class Form6 : Form
    {

        SqlConnection cs = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlDataAdapter da = new SqlDataAdapter();

        StreamWriter log;



        public string autoincrement()
        {
            string last_val = null;
            int value;
            SqlCommand cmd = new SqlCommand("SELECT customer_id FROM customer", cs);
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
                last_val = "c" + value.ToString().PadLeft(3, '0');
                //MessageBox.Show(last_val);
                return last_val;
            }
            else
            {
                //MessageBox.Show("db empty");
                return "c001";
            }
        }



        string user = Properties.Settings.Default.usr;

        /*public bool check(string name)   //function for login starts
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM customer WHERE customer_id='" + name + "';");
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
        }*/                                         //function for login ends 

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox5.Text == "")
            {
                MessageBox.Show("Required field's are empty", "Error");
            }
            else
            {

                //if (check(comboBox1.Text) == true)
                if(checkBox1.Checked==true)
                {
                    DialogResult dr1;
                    dr1 = MessageBox.Show("Do you want to update it?", "info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr1 == DialogResult.Yes)
                    {
                        cs.Close();
                        da.UpdateCommand = new SqlCommand("UPDATE customer SET customer_name='"+textBox2.Text+"',customer_company_name='"+textBox3.Text+"',customer_add='"+textBox4.Text+"',customer_contact='"+textBox5.Text+"',email='"+textBox6.Text+"' WHERE customer_id='" + comboBox1.Text + "'", cs);
                        cs.Open();
                        da.UpdateCommand.ExecuteNonQuery();
                        cs.Close();

                        log = File.AppendText(Form1.fileloc);
                        log.Write(DateTime.Now);
                        log.WriteLine("---User " + user + " updated customer ID= " + comboBox1.Text);
                        log.Close();

                        comboBox1.Text = "";
                        
                        
                        this.customerTableAdapter.Fill(this.scm_mainDataSet2.customer);
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        checkBox1.Checked = false;
                        comboBox1.Enabled = false;
                        textBox2.Focus();
                        
                        


                    }

                }
                else
                {

                    DialogResult dr;

                    dr = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        cs.Close();
                        da.InsertCommand = new SqlCommand("INSERT INTO customer (customer_id,customer_name,customer_company_name,customer_add,customer_contact,email) VALUES('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", cs);
                        cs.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        cs.Close();

                        log = File.AppendText(Form1.fileloc);
                        log.Write(DateTime.Now);
                        log.WriteLine("---User " + user + " added customer ID= " + comboBox1.Text);
                        log.Close();

                        DialogResult dr1;
                        dr1 = MessageBox.Show("Do you want to add more Customer's?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr1 == DialogResult.Yes)
                        {
                            comboBox1.Text = "";
                            
                            //comboBox1.Focus();
                            this.customerTableAdapter.Fill(this.scm_mainDataSet2.customer);
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";

                            checkBox1.Checked = false;
                            comboBox1.Enabled = false;
                            comboBox1.Text = autoincrement();
                            textBox2.Focus();
                        }
                        else
                        {
                            if (dr1 == DialogResult.No)
                            {
                                this.Dispose();
                            }
                        }
                    }
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scm_mainDataSet2.customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.scm_mainDataSet2.customer);
            comboBox1.Text = autoincrement();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar !=' ')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '@' && e.KeyChar !='_' && e.KeyChar !='.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '@' && (sender as TextBox).Text.IndexOf('@') > -1)
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar) | char.IsDigit(e.KeyChar) | char.IsLetter(e.KeyChar) | char.IsWhiteSpace(e.KeyChar) | char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Text = "Update";
                this.customerTableAdapter.Fill(this.scm_mainDataSet2.customer);
                comboBox1.Enabled = true;
            }
            else
            {
                button1.Text = "Add";
                comboBox1.Text = autoincrement();
                comboBox1.Enabled = false;
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";                
            }
        }
    }
}

