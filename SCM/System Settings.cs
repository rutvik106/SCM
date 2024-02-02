using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;



namespace SCM
{
    public partial class Form15 : Form
    {

        SqlConnection cn = new SqlConnection(Properties.Settings.Default.scm_mainConnectionString);
        

        string FilePath = ConfigurationSettings.AppSettings["location"];

        public Form15()
        {
            InitializeComponent();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked != true)
            {
                Properties.Settings.Default.chk = false;
                Properties.Settings.Default.popup = false;
                groupBox2.Enabled = false;
                Properties.Settings.Default.Save();
                Form1.ni.Visible = false;
            }
            else
            {
                Properties.Settings.Default.chk = true;
                Properties.Settings.Default.popup = true;
                groupBox2.Enabled = true;
                Properties.Settings.Default.Save();
                Form1.ni.Visible = true;
            }   
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            //Configuration configfile = ConfigurationManager.OpenExeConfiguration(FilePath);

            min_lvl_set.Value = decimal.Parse(Properties.Settings.Default.min_val);
            numericUpDown1.Value = decimal.Parse(Properties.Settings.Default.timer_value);

            checkBox3.Checked = Properties.Settings.Default.chk;
            checkBox2.Checked = Properties.Settings.Default.chk1;
            checkBox1.Checked = Properties.Settings.Default.chk2;
            
            if (checkBox3.Checked == true)
            {
                groupBox2.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked != true)
            {
                Properties.Settings.Default.chk1 = false;
                Properties.Settings.Default.allowgen = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.chk1 = true;
                Properties.Settings.Default.allowgen = true;
                Properties.Settings.Default.Save();
            }
                   
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            
            if (checkBox1.Checked != true)
            {
                Properties.Settings.Default.chk2 = false;
                rk.DeleteValue("SCM", false);
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.chk2 = true;
                rk.SetValue("SCM", Application.ExecutablePath.ToString());
                Properties.Settings.Default.Save();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" || textBox2.Text != "")
            {
                try
                {
                    string user = Properties.Settings.Default.usr.ToString();
                    string pwd_old = textBox1.Text;
                    string pwd_new = textBox2.Text;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM user_master WHERE password='" + pwd_old + "' AND user_id='" + user + "'", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read() == true)
                    {
                        if (textBox2.Text == textBox3.Text)
                        {

                            cn.Close();

                            SqlCommand cmd2 = new SqlCommand("UPDATE user_master SET password='" + pwd_new + "' WHERE user_id='" + user + "' AND password='" + pwd_old + "'", cn);

                            //da.UpdateCommand = new SqlCommand("UPDATE user_master SET user_id='" + pwd_new + "' WHERE password='" + pwd_old + "' AND user_id='" + user + "'", cn);
                            cn.Open();
                            cmd2.ExecuteNonQuery();
                            cn.Close();


                            MessageBox.Show("Password changed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                        }
                        else
                        {
                            cn.Close();
                            MessageBox.Show("New password does not match");
                        }
                    }
                    else
                    {
                        cn.Close();
                        MessageBox.Show("Old password incorrect","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
            {

            }
        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string str = null;
                bool chk;
                SqlCommand cmd = new SqlCommand("SELECT item_name FROM inventory WHERE qty<=20", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                
                    while (rdr.Read()==true)
                    {
                        
                        str += rdr.GetString(0) + ", ";

                        //MessageBox.Show(rdr.GetString(0));
                    }
                
                
                MessageBox.Show(str);
                //MessageBox.Show(chk.ToString());
                /*rdr.Read();
                rdr.GetValues(obj);
                str=obj.GetValue(0).ToString();
                MessageBox.Show(str);
                cn.Close();

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
                cn.Close();
            }
        }*/

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string exeFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // + "\\SCM.exe";//.GetName().CodeBase);
            //string pth = System.IO.Path.GetDirectoryName(exeFilePath);
            
            MessageBox.Show(exeFilePath);
        }

        /*private void min_lvl_set_ValueChanged(object sender, EventArgs e)
        {
            Configuration configfile = ConfigurationManager.OpenExeConfiguration(FilePath);

            configfile.AppSettings.Settings["min_val"].Value = min_lvl_set.Value.ToString();

            configfile.Save();


            min_lvl_set.Value = decimal.Parse(ConfigurationSettings.AppSettings["min_val"]);

        }*/

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form21 f21 = new Form21();
            f21.ShowDialog(this);
        }

        private void min_lvl_set_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.min_val = min_lvl_set.Value.ToString();
            Properties.Settings.Default.Save();

            min_lvl_set.Value = decimal.Parse(Properties.Settings.Default.min_val);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.timer_value = numericUpDown1.Value.ToString();
            Properties.Settings.Default.Save();

            numericUpDown1.Value = decimal.Parse(Properties.Settings.Default.timer_value);
        }

        

        
    }
}
