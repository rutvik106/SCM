using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SCM
{
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            StreamReader reader;
            reader = new StreamReader(Form1.fileloc);

            richTextBox1.Text = reader.ReadToEnd();
            reader.Close();
        }
    }
}
