using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace SCM
{
    public partial class Form21 : Form
    {


        public void yahoo()
        {
            try
            {
                string mail_id = ConfigurationSettings.AppSettings["mailid"];
                string mail_pwd = ConfigurationSettings.AppSettings["mailpwd"];

                SmtpClient client = new SmtpClient("smtp.mail.yahoo.com", 25);
                client.Credentials = new NetworkCredential(mail_id, mail_pwd);
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress("rutvik106@live.com"));
                mail.From = (new MailAddress(mail_id));
                if (radioButton1.Checked == true)
                {
                    mail.Subject = "SCM Bug Report";
                }
                if (radioButton2.Checked == true)
                {
                    mail.Subject = "SCM Feature Request";
                }
                if (radioButton3.Checked == true)
                {
                    mail.Subject = "SCM Feedback";
                }
                mail.Body = "My name is " + textBox2.Text + " mail id is " + textBox3.Text + " i am using this software on " + comboBox1.Text + " Message: " + textBox1.Text;
                client.Send(mail);



                MessageBox.Show("Form submitted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                mail.To.Add(new MailAddress("rutvik106@live.com"));
                mail.From = (new MailAddress(mail_id));
                if (radioButton1.Checked == true)
                {
                    mail.Subject = "SCM Bug Report";
                }
                if (radioButton2.Checked == true)
                {
                    mail.Subject = "SCM Feature Request";
                }
                if (radioButton3.Checked == true)
                {
                    mail.Subject = "SCM Feedback";
                }
                mail.Body = "My name is " + textBox2.Text + " mail id is " + textBox3.Text + " i am using this software on " + comboBox1.Text + " Message: " + textBox1.Text;
                client.EnableSsl = true;
                client.Send(mail);



                MessageBox.Show("Form submitted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        public void gmail()
        {
            try
            {
                string mail_id = ConfigurationSettings.AppSettings["mailid"];
                string mail_pwd = ConfigurationSettings.AppSettings["mailpwd"];

                SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
                client.Credentials = new NetworkCredential(mail_id, mail_pwd);
                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress("rutvik106@live.com"));
                mail.From = (new MailAddress(mail_id));
                if (radioButton1.Checked == true)
                {
                    mail.Subject = "SCM Bug Report";
                }
                if (radioButton2.Checked == true)
                {
                    mail.Subject = "SCM Feature Request";
                }
                if (radioButton3.Checked == true)
                {
                    mail.Subject = "SCM Feedback";
                }
                client.EnableSsl = true;
                mail.Body = "My name is " + textBox2.Text + " mail id is " + textBox3.Text + " i am using this software on " + comboBox1.Text + " Message: " + textBox1.Text;
                client.Send(mail);

                

                MessageBox.Show("Form submitted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                DialogResult dr;
                dr = MessageBox.Show("Cannot submit form check your internet connection.", "Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Retry)
                {
                    yahoo();
                }
            }

        }



        public Form21()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            textBox1.Text = "******BUG******\r\nConcise problem statement:\r\nSteps to reproduce bug:\r\n1.\r\n2.\r\n3.\r\nResults:\r\nExpected results";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            textBox1.Text = "*******Enhancement / FMR*********\r\nBrief title for your desired feature:\r\nHow would you like the feature to work?\r\nWhy is this feature important to you?";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            textBox1.Text = "Your Likes and Dislikes about the software";
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | comboBox1.Text == "")
                {

                    MessageBox.Show("Required fields are empty", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (ConfigurationSettings.AppSettings["mailid"] == "" | ConfigurationSettings.AppSettings["mailpwd"] == "")
                    {
                        MessageBox.Show("Mail Credential was not set while Setting up SCM System. Cannot send Form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Dispose();

                    }
                    else
                    {

                        yahoo();
                    }

                }
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            groupBox2.Enabled = false;
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
