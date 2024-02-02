using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCM
{
    public partial class select_rpt : Form
    {
        public select_rpt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                reportform s_rpt = new reportform();
                s_rpt.ShowDialog(this);
            }
            if (radioButton2.Checked == true)
            {
                reportform2 p_rpt = new reportform2();
                p_rpt.ShowDialog(this);
            }
            if (radioButton3.Checked == true)
            {
                reports3 inv_rpt = new reports3();
                inv_rpt.ShowDialog(this);
            }

        }

        private void select_rpt_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
    }
}
