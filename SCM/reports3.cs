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
    public partial class reports3 : Form
    {
        public reports3()
        {
            InitializeComponent();
        }

        private void reports3_Load(object sender, EventArgs e)
        {
            Inventory_Report rpt = new Inventory_Report();
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.scm_mainConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT inventory.inventory_no, inventory.item_name, item_master.rate, inventory.dilevery_date, inventory.qty, quantity.qty AS qty2, inventory.supplier_id, supplier.supplier_name, supplier.supplier_contact FROM inventory INNER JOIN item_master ON inventory.item_name = item_master.item_name INNER JOIN supplier ON inventory.supplier_id = supplier.supplier_id INNER JOIN quantity ON item_master.item_name = quantity.item_name", conn);
            //SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM sales", conn);
            DataSet ds = new DataSet();
            //da.Fill(ds, "user_master");
            //da.Fill(ds, "sinvoice");

            da.Fill(ds, "Table");
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
