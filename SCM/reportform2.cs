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
    public partial class reportform2 : Form
    {
        public reportform2()
        {
            InitializeComponent();
        }

        private void reportform2_Load(object sender, EventArgs e)
        {
            PReport rpt = new PReport();
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.scm_mainConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT purchase.no, purchase.date, purchase.supplier_id, supplier.supplier_name, supplier.supplier_contact, supplier.website, supplier.item_name, pinvoice.rate, pinvoice.vat, pinvoice.excise, purchase.pinvoice_no, pinvoice.order_date, pinvoice.total_weight AS weight, pinvoice.net_total, pinvoice.user_id, user_master.contact FROM purchase INNER JOIN pinvoice ON purchase.pinvoice_no = pinvoice.pinvoice_no INNER JOIN supplier ON purchase.supplier_id = supplier.supplier_id INNER JOIN item_master ON supplier.item_name = item_master.item_name INNER JOIN user_master ON pinvoice.user_id = user_master.user_id", conn);
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM sales", conn);
            DataSet ds = new DataSet();
            //da.Fill(ds, "user_master");
            //da.Fill(ds, "sinvoice");

            da.Fill(ds, "P_table");
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
