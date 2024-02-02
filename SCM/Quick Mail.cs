using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Configuration;

namespace SCM
{
    public partial class Form17 : Form
    {

        


        StreamWriter log;

        string user = Properties.Settings.Default.usr;

        public void yahoo()
        {
            try
            {
                string mail_id = ConfigurationSettings.AppSettings["mailid"];
                string mail_pwd = ConfigurationSettings.AppSettings["mailpwd"];

                SmtpClient client = new SmtpClient("smtp.mail.yahoo.com", 25);
                client.Credentials = new NetworkCredential(mail_id,mail_pwd);
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(comboBox3.Text));
                mail.From = (new MailAddress(mail_id));
                mail.Subject = textBox2.Text;
                mail.Body = textBox1.Text;
                client.Send(mail);

                log = File.AppendText(Form1.fileloc);
                log.Write(DateTime.Now);
                log.WriteLine("---User " + user + " sent mail to ID= " + comboBox3.Text);
                log.Close();

                MessageBox.Show("Mail sent successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                //MessageBox.Show(exc.Message);
                //DialogResult dr;
                //dr = MessageBox.Show("You are not connected to Internet", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                //if (dr == DialogResult.Retry)
                //{
                hotmail();
                //}
            }
        }

        public void hotmail()
        {
            try
            {
                string mail_id = ConfigurationSettings.AppSettings["mailid"];
                string mail_pwd = ConfigurationSettings.AppSettings["mailpwd"];

                SmtpClient client = new SmtpClient("smtp.live.com", 25);
                client.Credentials = new NetworkCredential(mail_id, mail_pwd);
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(comboBox3.Text));
                mail.From = (new MailAddress(mail_id));
                mail.Subject = textBox2.Text;
                mail.Body = textBox1.Text;
                client.EnableSsl = true;
                client.Send(mail);

                log = File.AppendText(Form1.fileloc);
                log.Write(DateTime.Now);
                log.WriteLine("---User " + user + " sent mail to ID= " + comboBox3.Text);
                log.Close();

                MessageBox.Show("Mail sent successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                //DialogResult dr;
                //dr = MessageBox.Show("You are not connected to Internet", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                //if (dr == DialogResult.Retry)
                //{
                gmail();
                //}
            }
        }

        /*public void sendmail()
        {

            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                client.Credentials = new NetworkCredential("rutvik106@live.com","vistaultimate");
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(comboBox3.Text));
                mail.From = (new MailAddress("rutvik106@live.com"));
                mail.Subject = textBox2.Text;
                mail.Body = textBox1.Text;
                client.EnableSsl = true;
                client.Send(mail);

                log = File.AppendText(Form1.fileloc);
                log.Write(DateTime.Now);
                log.WriteLine("---User " + user + " sent mail to ID= " + comboBox3.Text);
                log.Close();

                MessageBox.Show("Mail sent successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DialogResult dr;
                dr = MessageBox.Show(ex+"Make sure you are connected to Internet", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Retry)
                {
                    sendmail();
                }
            }

        }*/

        public void gmail()
        {
            try
            {
                string mail_id = ConfigurationSettings.AppSettings["mailid"];
                string mail_pwd = ConfigurationSettings.AppSettings["mailpwd"];

                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                client.Credentials = new NetworkCredential(mail_id, mail_pwd);
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(comboBox3.Text));
                mail.From = (new MailAddress(mail_id));
                mail.Subject = textBox2.Text;
                mail.Body = textBox1.Text;
                client.EnableSsl = true;
                client.Send(mail);

                log = File.AppendText(Form1.fileloc);
                log.Write(DateTime.Now);
                log.WriteLine("---User " + user + " sent mail to ID= " + comboBox3.Text);
                log.Close();

                MessageBox.Show("Mail sent successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                DialogResult dr;
                dr = MessageBox.Show("You are not connected to Internet", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Retry)
                {
                    yahoo();
                }
            }
            
        }

        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {

            if (ConfigurationSettings.AppSettings["mailid"] == "" | ConfigurationSettings.AppSettings["mailpwd"] == "")
            {
                MessageBox.Show("Mail ID and Password Credential was not set while Setting up SCM System. Sorry, you cannot use Quick Mail facility.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();

            }
            else
            {

                // TODO: This line of code loads data into the 'scm_mainDataSet6.user_master' table. You can move, or remove it, as needed.
                this.user_masterTableAdapter.Fill(this.scm_mainDataSet6.user_master);
                // TODO: This line of code loads data into the 'scm_mainDataSet2.customer' table. You can move, or remove it, as needed.
                this.customerTableAdapter.Fill(this.scm_mainDataSet2.customer);
                this.supplierTableAdapter.Fill(this.scm_mainDataSet3.supplier);
                // TODO: This line of code loads data into the 'scm_mainDataSet3.supplier' table. You can move, or remove it, as needed.

                try
                {
                    comboBox3.Text = Form19.id;
                    textBox2.Text = Form19.sub;
                    textBox1.Text = Form19.msg;
                }
                catch (Exception)
                {

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.DataSource = usermasterBindingSource;
                comboBox2.DisplayMember = "fname";
                comboBox3.DataSource = usermasterBindingSource;
                comboBox3.DisplayMember = "email";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.DataSource = supplierBindingSource;
                comboBox2.DisplayMember="supplier_name";
                comboBox3.DataSource = supplierBindingSource;
                comboBox3.DisplayMember = "email";                
            }
            if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.DataSource = customerBindingSource;
                comboBox2.DisplayMember = "customer_name";
                comboBox3.DataSource = customerBindingSource;
                comboBox3.DisplayMember = "email";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("To, Subject And Message are required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                yahoo();

                /*if (Form18.gmail.Checked == true)
                {
                    gmail();
                }
                if (Form18.yahoo.Checked == true)
                {
                    yahoo();
                }
                if (Form18.hotmail.Checked == true)
                {
                    hotmail();
                }*/
            }
        }
    }
}
