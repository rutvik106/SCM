using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;



namespace SCM
{
    public partial class Form7 : Form4
    {

        System.Timers.Timer timer1 = null;
        public static Form19 f19 = new Form19();
        //private static Form15 f15 = new Form15();
        SqlConnection sql_conn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public void chk_db1()
        {

            //string connection_1;

            //connection_1 = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=False";

            //SqlConnection sql_con = new SqlConnection(connection_1);

            string exe_File_Path;

            exe_File_Path = ConfigurationSettings.AppSettings["location"];

            try
            {

                string minval = "";

                Configuration app_config = ConfigurationManager.OpenExeConfiguration(exe_File_Path);

                //minval = config.AppSettings.Settings["min_val"].Value;

                minval = app_config.AppSettings.Settings["min_val"].Value;

                string str = "";

                SqlCommand sql_cmd = new SqlCommand("SELECT item_name FROM inventory WHERE qty<='" + minval + "';", sql_conn);

                sql_conn.Open();

                SqlDataReader sql_rdr = sql_cmd.ExecuteReader();

                while (sql_rdr.Read() != false)
                {

                    str += sql_rdr.GetValue(0).ToString() + ", ";

                }

                app_config.AppSettings.Settings["low_item"].Value = str;

                //con.Close();

                app_config.Save();

                sql_conn.Close();

                //MessageBox.Show("database checked");

            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry(this.ServiceName, "error:rutvik " + ex.ToString() + "conn=" + sql_con.ToString() + "path=" + exe_File_Path.ToString(), System.Diagnostics.EventLogEntryType.Warning);
                sql_conn.Close();
                MessageBox.Show( ex+"some error occured in chk_db function");

            }


        }
        public void chk_db()
        {

            //string connection_1;

            //connection_1 = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=False";

            //SqlConnection sql_con = new SqlConnection(connection_1);

            

            try
            {

                string minval = "";

                
                //minval = config.AppSettings.Settings["min_val"].Value;

                minval = Properties.Settings.Default.min_val;

                string str = "";

                SqlCommand sql_cmd = new SqlCommand("SELECT item_name FROM quantity WHERE qty<='" + float.Parse(minval) + "';", sql_conn);

                sql_conn.Open();

                SqlDataReader sql_rdr = sql_cmd.ExecuteReader();

                while (sql_rdr.Read() != false)
                {

                    str += sql_rdr.GetValue(0).ToString() + ", ";

                }

                Properties.Settings.Default.low_item = str;

                //app_config.AppSettings.Settings["low_item"].Value = str;

                //con.Close();

                Properties.Settings.Default.Save();

                //app_config.Save();

                sql_conn.Close();

                //MessageBox.Show("database checked");

            }
            catch (Exception ex)
            {
                //EventLog.WriteEntry(this.ServiceName, "error:rutvik " + ex.ToString() + "conn=" + sql_con.ToString() + "path=" + exe_File_Path.ToString(), System.Diagnostics.EventLogEntryType.Warning);
                sql_conn.Close();
                MessageBox.Show(ex.ToString() + "some error occured in chk_db function");

            }


        }
        public void chk_inventory()
        {
            try
            {
                //Configuration config = ConfigurationManager.OpenExeConfiguration(exeFilePath);
                if (Properties.Settings.Default.popup == true)
                {
                    string str1 = Properties.Settings.Default.low_item;
                    if (str1 != "")
                    {
                        //MessageBox.Show("Quantity of " + str1 + "are getting low please check inventory");
                        Form1.ni.ShowBalloonTip(5000, "Alert", "Quantuiy of " + str1 + "are getting low please check inventory", ToolTipIcon.Warning);
                    }
                    else
                    {
                        Form1.ni.ShowBalloonTip(2000, "Info", "Stock Up To Date", ToolTipIcon.Info);
                        //MessageBox.Show("inventory checked");
                        //Form1.ni.Visible = true;
                        //Form1.ni.ShowBalloonTip(5000, "Alert", "Ok, The else part", ToolTipIcon.Warning);
                        //MessageBox.Show("lollollol");
                        //Form1.ni.ShowBalloonTip(1000, "Info", "hello its done", ToolTipIcon.Info);
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString() + "some error occured in chk_inventory function");
            }

            

        }
        void ni_BalloonTipClicked(object sender, EventArgs e)
        {
            try
            {
                f19.ShowDialog(this);
            }
            catch (Exception)
            {
                
            }
                //MessageBox.Show("hello you clicked it");
        }
        public void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            chk_db();
            chk_inventory();
        }

        public Form7()
        {
            InitializeComponent();
            //timer1 = new System.Timers.Timer(300000);
            timer1 = new System.Timers.Timer((double.Parse(Properties.Settings.Default.timer_value))*10000);
            timer1.Elapsed +=new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.Start();
            Form1.ni.BalloonTipClicked += new EventHandler(ni_BalloonTipClicked);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 f8=new Form8();
            f8.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            select_rpt sel_rpt = new select_rpt();
            sel_rpt.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.ShowDialog(this);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Add or Update customers to database.";            
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Add or Update suppliers to database.";
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Create sales invoice for customers.";
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Allows you to generate Sales, Purchase and Stock reports.";
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Add or Update items and it's details(VAT, Excise, etc) to database. Also view Stock details";
        }

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Hover the mouse on a button for Task Details"; 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.ShowDialog(this);
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "It will allow you to search item details, customer details, sales and purchase details etc from database.";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.ShowDialog(this);
            
            //timer1 = new System.Timers.Timer((double.Parse(Properties.Settings.Default.timer_value)) * 100000);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Do you want to update the Rate, VAT and Excise of item's?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                Form11 f11 = new Form11();
                f11.ShowDialog(this);
            }
            Form16 f16 = new Form16();
            f16.ShowDialog(this);
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Add purchase invoices to database to achive Traceability.";
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Settings Related Autorun on startup, Allowing general users, Notification alerts, Set MIN INVENTORY LVL, Change password, Send feedback etc.";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.ShowDialog(this);
        }

        private void button10_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Send E-Mail to customer,Supplier or User using quick mail feature.";
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "View Logs generated(View user activities).";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //FileStream fileStream = new FileStream(, FileMode.Open);
            //StreamReader streamReader = new StreamReader();
            //string text = streamReader.ReadToEnd();
            //streamReader.Close();            
            //System.Diagnostics.Process.Start(Form1.fileloc);
            Form22 f22 = new Form22();
            f22.Show();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sCM_System_main.user_master' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'sCM_System_main.sinvoice' table. You can move, or remove it, as needed.
            //this.sinvoiceTableAdapter.Fill(this.sCM_System_main.sinvoice);
            // TODO: This line of code loads data into the 'sCM_System_main.customer' table. You can move, or remove it, as needed.
            //this.customerTableAdapter.Fill(this.sCM_System_main.customer);
            label4.Text = Properties.Settings.Default.usr;
            chk_db();
            chk_inventory();
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form7_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Hover the mouse on a button for Task Details";
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Hover the mouse on a button for Task Details";
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Hover the mouse on a button for Task Details";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Form18 f18 = new Form18();
            //f18.ShowDialog(this);
        }
    }
}