using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SCM
{
    public partial class Form11 : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlDataAdapter da = new SqlDataAdapter();

        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scm_mainDataSet1.item_master' table. You can move, or remove it, as needed.
            this.item_masterTableAdapter.Fill(this.scm_mainDataSet1.item_master);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 | textBox1.Text == "")
            {
                MessageBox.Show("Please select proper Item and enter new Rate", "Error");
            }
            else
            {
                float f1 = float.Parse(textBox1.Text);
                float f2=float.Parse(textBox2.Text);
                float f3=float.Parse(textBox3.Text);
                da.UpdateCommand = new SqlCommand("UPDATE item_master SET rate='" + f1 + "',vat='" + f2 + "',excise='" + f3 + "' WHERE item_name='" + comboBox1.Text + "'", cn);
                cn.Open();
                try
                {
                    da.UpdateCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    MessageBox.Show("Field's are empty");
                }
                cn.Close();
                this.Dispose();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        
    }
}
