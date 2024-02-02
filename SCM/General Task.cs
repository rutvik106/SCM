using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SCM
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "This feature will provide advanced search which can be used to search materials,batches,customers and imp dates.";
        }
        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Hover the mouse on a button for Task Details";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.ShowDialog(this);
        }

        private void Form4_MouseHover(object sender, EventArgs e)
        {
            label1.Text = "Hover the mouse on a button for Task Details";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "Hover the mouse on a button for Task Details";
        }
    }
}
