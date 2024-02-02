using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Win32;


namespace SCM
{
    
    public partial class Form1 : Form
    {

        SqlConnection cs = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            
        SqlDataAdapter da = new SqlDataAdapter();

        public static string locpath = Application.StartupPath.ToString();
        public static string fileloc = locpath + @"\logfile.txt";
        StreamWriter log;


        public static NotifyIcon ni = new NotifyIcon();
        
        

        public bool trylogin(string name, string pass)   //function for login starts
        {
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM user_master WHERE user_id=@name AND password=@pass;");
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass;            
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

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(this);            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trylogin(textBox1.Text, textBox2.Text) == true)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM user_master WHERE user_id=@id AND type='Administrator';");
                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = textBox1.Text;
                cmd.Connection = cs;
                cs.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                if (checkBox1.Checked == true)
                {
                    //Properties.Settings.Default.collection.Add(textBox1.Text);
                    //Properties.Settings.Default.Save();
                    Properties.Settings.Default.remember_me = true;
                    Properties.Settings.Default.Save();
                    RegistryKey main = Registry.CurrentUser;
                    RegistryKey software = main.OpenSubKey("SOFTWARE", true);
                    RegistryKey rememberme = software.CreateSubKey("idpwd");
                    rememberme.SetValue("id", textBox1.Text, RegistryValueKind.String);
                    rememberme.SetValue("pwd", textBox2.Text, RegistryValueKind.String);
                }

                else
                {
                    Properties.Settings.Default.remember_me = false;
                    Properties.Settings.Default.Save();
                    try
                    {
                        RegistryKey main = Registry.CurrentUser;
                        RegistryKey software = main.OpenSubKey("SOFTWARE", true);
                        RegistryKey rememberme = software.CreateSubKey("idpwd");
                        rememberme.DeleteValue("id");
                        rememberme.DeleteValue("pwd");
                    }
                    catch (Exception)
                    {

                    }
                }


                if (reader.Read() != false)
                {
                    cs.Close();

                    


                    log = File.AppendText(fileloc);
                    log.Write(DateTime.Now);
                    log.WriteLine("---User " + textBox1.Text + " Logged In successfully");
                    log.Close();
                    
                    MessageBox.Show("Hello you are Administrator", "Info",MessageBoxButtons.OK,MessageBoxIcon.Information);

                    Properties.Settings.Default.usr = textBox1.Text;

                    string user_admin = Properties.Settings.Default.usr;

                    //notifyIcon1.ShowBalloonTip(1000, "Welcome", textBox1.Text + " LogIn Successful", ToolTipIcon.Info);

                    

                    openToolStripMenuItem.Enabled = false;
                    
                    Form7 f7 = new Form7();
                    this.Hide();
                    f7.ShowDialog(this);
                    log = File.AppendText(fileloc);
                    log.Write(DateTime.Now);
                    log.WriteLine("---User " + user_admin + " Logged Out");
                    log.Close();
                    //textBox1.AutoCompleteCustomSource = Properties.Settings.Default.collection;
                   
                        this.Show();
                        if (Properties.Settings.Default.remember_me == true)
                        {

                        }
                        else
                        {
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox1.Focus();
                            checkBox1.Checked = false;
                            openToolStripMenuItem.Enabled = true;
                        }
                        
                    
                    
                    
                }
                else
                {
                    if (Properties.Settings.Default.allowgen != true)
                    {
                        MessageBox.Show("Access Denied By Administrator", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cs.Close();
                    }
                    else
                    {
                    cs.Close();                   

                    log = File.AppendText(fileloc);
                    log.Write(DateTime.Now);
                    log.WriteLine("---User " + textBox1.Text + " Logged In successfully");
                    log.Close();

                    MessageBox.Show("Hello you are general user", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Properties.Settings.Default.usr = textBox1.Text;

                    string user_gen = Properties.Settings.Default.usr;

                    //notifyIcon1.ShowBalloonTip(1000, "Welcome", textBox1.Text + " LogIn Successful", ToolTipIcon.Info);

                    

                    openToolStripMenuItem.Enabled = false;
                    Form4 f4 = new Form4();
                    this.Hide();
                    f4.ShowDialog(this);
                    log = File.AppendText(fileloc);
                    log.Write(DateTime.Now);
                    log.WriteLine("---User " + user_gen + " Logged Out");
                    log.Close();
                    //textBox1.AutoCompleteCustomSource = Properties.Settings.Default.collection;
                    this.Show();
                    if (Properties.Settings.Default.remember_me==true)
                    {
                        
                    }
                    else
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Focus();
                        checkBox1.Checked = false;
                        openToolStripMenuItem.Enabled = true;
                    }

                    }
                }

                
                

            }

            else
            {
                MessageBox.Show("Invalid User ID or Password", "Login failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                cs.Close();
            }
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form20 f20 = new Form20();
            f20.ShowDialog(this);

            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CanFocus==true)
            {
                this.Focus();
            }
            else
            {

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form13 f13 = new Form13();
            f13.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            checkBox1.Checked = Properties.Settings.Default.remember_me;

            if (Properties.Settings.Default.remember_me == true)
            {

                try
                {
                    RegistryKey main = Registry.CurrentUser;
                    RegistryKey software = main.OpenSubKey("SOFTWARE", true);
                    RegistryKey rememberme = software.CreateSubKey("idpwd");
                    if (rememberme != null)
                    {
                        textBox1.Text = rememberme.GetValue("id").ToString();
                        textBox2.Text = rememberme.GetValue("pwd").ToString();
                    }
                    else
                    {

                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show(err.ToString());
                }
            }

            ni = notifyIcon1;
            //textBox1.AutoCompleteCustomSource = Properties.Settings.Default.collection;
            notifyIcon1.Visible = Properties.Settings.Default.popup;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ni.Dispose();
        }

        
    }
}
