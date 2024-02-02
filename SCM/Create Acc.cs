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
    public partial class Form3 : Form
    {

        SqlConnection cs = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlDataAdapter da=new SqlDataAdapter();

        


        public bool check(string name)   //function for login starts
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM user_master WHERE user_id='" + name + "';");
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
        }                                         //function for login ends 

        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "General";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" | textBox3.Text=="" | textBox4.Text=="" | textBox6.Text=="" | textBox8.Text=="" | comboBox2.Text=="")
            {
                MessageBox.Show("Name, User ID, Password, Secret Question and ContactNo are required","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);                
            }
            
                else
                {
                if (textBox4.Text != textBox5.Text)
                {
                    MessageBox.Show("Password does not match","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    if (check(textBox3.Text) == true)
                    {
                        cs.Close();
                        MessageBox.Show("User ID already exist","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        cs.Close();
                        if (radioButton1.Checked == true)
                        {
                            da.InsertCommand = new SqlCommand("INSERT INTO user_master (fname,lname,user_id,password,gender,type,contact,email,question,answer) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + radioButton1.Text + "','" + comboBox1.SelectedItem + "','" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox2.Text + "','" + textBox8.Text + "')", cs);
                        }
                        else
                        {
                            da.InsertCommand = new SqlCommand("INSERT INTO user_master (fname,lname,user_id,password,gender,type,contact,email,question,answer) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + radioButton2.Text + "','" + comboBox1.SelectedItem + "','" + textBox6.Text + "','" + textBox7.Text + "','"+comboBox2.Text+"','"+textBox8.Text+"')", cs);
                        }
                        cs.Open();
                        da.InsertCommand.ExecuteNonQuery();


                        //MessageBox.Show(Form1.fileloc);

                        StreamWriter log;

                        if (!File.Exists(Form1.fileloc))
                        {
                            //MessageBox.Show("if part");
                            log = new StreamWriter(Form1.fileloc);
                            File.SetAttributes(Form1.fileloc,FileAttributes.Hidden);
                            log.WriteLine("PLEASE DONOT MESS WITH IT");
                        }
                        else
                        {
                            //MessageBox.Show("else part");
                            log = File.AppendText(Form1.fileloc);
                        }

                        // Write to the file:
                        log.Write(DateTime.Now);
                        log.WriteLine("---New account created for "+ textBox1.Text + " ID= " + textBox3.Text);
                        // Close the stream:
                        log.Close();

                        MessageBox.Show("Account created successfully", "Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        cs.Close();
                        this.Dispose();
                    }
                }
            }
        }

        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '_' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '@' && e.KeyChar != '_' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            
            if (e.KeyChar == '@' && (sender as TextBox).Text.IndexOf('@') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
