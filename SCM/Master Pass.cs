using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace SCM
{
    public partial class Form2 : Form
    {

        string master_pass = ConfigurationSettings.AppSettings["Param1"];
        //public static string pass;
        
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == master_pass)
            {
                textBox1.Text = "";
                Form3 f3 = new Form3();
                this.Hide();
                f3.ShowDialog();
                this.Dispose();
            }
            else
            {
                
                MessageBox.Show("Master Password incorrect contact Owner for more Details","Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
