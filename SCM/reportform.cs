using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SCM
{
    public partial class reportform : Form
    {
        public reportform()
        {
            InitializeComponent();
        }

        private void reportform_Load(object sender, EventArgs e)
        {
            Sales_Report rpt = new Sales_Report();
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.scm_mainConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT sales.no, sales.date, customer.customer_id, customer.customer_name, customer.customer_contact, sinvoice.sinvoice_no, sinvoice.order_date, sinvoice.rate, sinvoice.vat, sinvoice.excise, sinvoice.net_total, user_master.user_id, user_master.contact FROM sales INNER JOIN sinvoice ON sales.sinvoice_no = sinvoice.sinvoice_no INNER JOIN customer ON sales.customer_id = customer.customer_id INNER JOIN user_master ON sinvoice.user_id = user_master.user_id", conn);
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM sales", conn);
            DataSet ds = new DataSet();
            //da.Fill(ds, "user_master");
            //da.Fill(ds, "sinvoice");
            
            da.Fill(ds, "sales_report");
            //da.Fill(ds, "customer");
            //da.Fill(ds, "sales");

            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("no data");
                return;
            }
            /*SCM_System_main ds=new SCM_System_main();
            this.user_masterTableAdapter.Fill(this.sCM_System_main.user_master);
            this.customerTableAdapter.Fill(this.sCM_System_main.customer);
            this.sinvoiceTableAdapter.Fill(this.sCM_System_main.sinvoice);
            this.salesTableAdapter.Fill(this.sCM_System_main.sales);*/
            rpt.SetDataSource(ds);
          

            crystalReportViewer1.ReportSource = rpt; 
        }
    }
}
