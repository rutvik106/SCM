using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SCM
{
    public partial class Form20 : Form
    {

        SqlConnection cn = new SqlConnection(Properties.Settings.Default.scm_mainConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();


        public bool check1(string id)   //function for login starts
        {

            SqlCommand cmd = new SqlCommand("SELECT question FROM user_master WHERE user_id='" + id + "';",cn);
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


        public string getq(string id)   //function for login starts
        {

            SqlCommand cmd = new SqlCommand("SELECT question FROM user_master WHERE user_id='" + id + "';", cn);
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetString(0);
        }                                         //function for login ends


        public bool check2(string id, string q, string ans)   //function for login starts
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM user_master WHERE user_id='" + id + "' AND question='" + q + "' AND answer='" + ans + "';", cn);
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



        public string getpass(string id)   //function for login starts
        {

            SqlCommand cmd = new SqlCommand("SELECT password FROM user_master WHERE user_id='" + id + "';", cn);
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            return reader.GetString(0);
        }                                         //function for login ends


        public Form20()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string question;
                bool chk1;
                chk1 = check1(textBox1.Text);
                if (chk1 == true)
                {
                    cn.Close();
                    question = getq(textBox1.Text);
                    groupBox2.Enabled = true;
                    label2.Text = question;
                    cn.Close();

                }
                else
                {
                    label2.Text = "";
                    textBox2.Text = "";
                    groupBox2.Enabled = false;
                    cn.Close();
                    MessageBox.Show("User ID does not exist");

                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);

            }

            

        }

        private void Form20_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string password;
                bool chk2;
                chk2 = check2(textBox1.Text, label2.Text, textBox2.Text);
                if (chk2 == true)
                {
                    cn.Close();
                    password = getpass(textBox1.Text);
                    MessageBox.Show("Your password is:- " + password);
                    cn.Close();

                }
                else
                {
                    cn.Close();
                    MessageBox.Show("Wrong answer");

                }
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);

            }
        }
    }
}
