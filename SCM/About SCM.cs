using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace SCM
{
    public partial class Form13 : Form
    {

        string videoloc = Form1.locpath + @"\SCM.mp4";

        public Form13()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(videoloc);            
        }

        private void Form13_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Dispose();
        }

        private void Form13_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void Form13_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
