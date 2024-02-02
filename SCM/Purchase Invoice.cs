using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SCM
{
    public partial class Form16 : Form
    {

        SqlConnection cs = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlDataAdapter da = new SqlDataAdapter();

        StreamWriter log;


        public string autoincrement()
        {
            string last_val = null;
            int value;
            SqlCommand cmd = new SqlCommand("SELECT pinvoice_no FROM pinvoice", cs);
            cs.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read() == true)
            {
                last_val = rdr.GetString(0).ToString();
            }
            cs.Close();
            //MessageBox.Show(last_val);
            if (last_val != null)
            {
                last_val = last_val.Remove(0, 4);
                //MessageBox.Show(last_val);
                value = int.Parse(last_val);
                value += 1;
                last_val = "invo" + value.ToString().PadLeft(3, '0');
                //MessageBox.Show(last_val);
                return last_val;
            }
            else
            {
                //MessageBox.Show("db empty");
                return "invo001";
            }
        }


        public Form16()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                float x, y, z;
                x = float.Parse(textBox7.Text);
                y = float.Parse(textBox4.Text);
                z = x * y;
                label17.Text = z.ToString();

            }
            catch (Exception)
            {

            }

            try
            {
                float a, b, c;
                a = float.Parse(textBox6.Text);
                b = float.Parse(textBox9.Text);
                c = a * b;
                textBox4.Text = c.ToString();
            }
            catch (Exception)
            {

            }

            if (comboBox1.Text == "" | textBox10.Text == "" | textBox4.Text== "")
            {
                MessageBox.Show("Required field's are empty", "Info");
            }
            else
            {

                float f1;
                float f4;
                float.TryParse(textBox6.Text, out f1);
                float.TryParse(textBox9.Text, out f4);


                

                float f2 = float.Parse(textBox7.Text);

                float f5 = float.Parse(textBox4.Text);
                float d = f5 * f2;
                label17.Text = d.ToString();
                float f3 = float.Parse(label17.Text);


                float vat = float.Parse(textBox5.Text);
                float excise = float.Parse(textBox11.Text);
                float net_total=0;

                DialogResult dr;
                DateTime a = dateTimePicker1.Value;
                DateTime b = dateTimePicker2.Value;
                DateTime c = dateTimePicker3.Value;

                //logic for calculating vat and excise here, f3 is the total price
                //start

                if (radioButton1.Checked == true)
                {
                    net_total = (f3 * vat) / 100;
                    net_total += f3;
                }
                if (radioButton2.Checked == true)
                {
                    net_total = (f3 * excise) / 100;
                    net_total += f3;
                }
                if (radioButton3.Checked == true)
                {                    
                    net_total = (f3 * (vat + excise)) / 100;
                    net_total += f3;
                    //MessageBox.Show(net_total.ToString());
                }

                //end...


                dr = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    da.InsertCommand = new SqlCommand("INSERT INTO pinvoice (pinvoice_no,supplier_id,pinvoice_date,chalan_no,order_date,description,pkg_weight,pkg,total_weight,rate,vat,excise,total,pinvoice_issue,user_id,net_total) VALUES(@pinvoice_no,@supplier_id,@pinvoice_date,@chalan_no,@order_date,@description,@pkg_weight,@pkg,@total_weight,@rate,@vat,@excise,@total,@pinvoice_issue,@user_id,@net_total)", cs);
                                                                    //VALUES('" + comboBox1.Text + "','" + textBox10.Text + "','" + a + "','" + textBox2.Text + "','" + b + "','" + textBox8.Text + "','" + f1 + "','" + f4 + "','" + textBox4.Text + "','" + f2 + "','"+ textBox5.Text +"','"+ textBox11.Text +"','" + f3 + "','" + c + "','"+ label14.Text +"','" + net_total + "')", cs);

                    da.InsertCommand.Parameters.Add("@pinvoice_no", SqlDbType.NVarChar).Value = comboBox1.Text;
                    da.InsertCommand.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = textBox10.Text;
                    da.InsertCommand.Parameters.Add("@pinvoice_date", SqlDbType.DateTime).Value = a;
                    da.InsertCommand.Parameters.Add("@chalan_no", SqlDbType.NVarChar).Value = textBox2.Text;
                    da.InsertCommand.Parameters.Add("@order_date", SqlDbType.DateTime).Value = b;
                    da.InsertCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = textBox8.Text;
                    da.InsertCommand.Parameters.Add("@pkg_weight", SqlDbType.Float).Value = f1;
                    da.InsertCommand.Parameters.Add("@pkg", SqlDbType.Int).Value = f4;
                    da.InsertCommand.Parameters.Add("@total_weight", SqlDbType.Float).Value = f5;
                    da.InsertCommand.Parameters.Add("@rate", SqlDbType.Float).Value = f2;
                    da.InsertCommand.Parameters.Add("@vat", SqlDbType.Float).Value = vat;
                    da.InsertCommand.Parameters.Add("@excise", SqlDbType.Float).Value = excise;
                    da.InsertCommand.Parameters.Add("@total", SqlDbType.Float).Value = f3;
                    da.InsertCommand.Parameters.Add("@pinvoice_issue", SqlDbType.DateTime).Value = c;
                    da.InsertCommand.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = label14.Text;
                    da.InsertCommand.Parameters.Add("@net_total", SqlDbType.Float).Value = net_total;                    
                    
                    cs.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    cs.Close();
                    da.InsertCommand = new SqlCommand("INSERT INTO purchase (pinvoice_no,date,supplier_id,total,rate,vat,excise) VALUES(@pinvoice_no,@date,@supplier_id,@total,@rate,@vat,@excise)", cs);
                                             //VALUES('" + comboBox1.Text + "','" + a + "','"+ textBox10.Text +"','"+ f3 +"','" + f2 + "','" + vat + "','" + excise + "')", cs);
                    da.InsertCommand.Parameters.Add("@pinvoice_no", SqlDbType.NVarChar).Value = comboBox1.Text;
                    da.InsertCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = a;
                    da.InsertCommand.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = textBox10.Text;
                    da.InsertCommand.Parameters.Add("@total", SqlDbType.Float).Value = net_total;
                    da.InsertCommand.Parameters.Add("@rate", SqlDbType.Float).Value = f2;
                    da.InsertCommand.Parameters.Add("@vat", SqlDbType.Float).Value = vat;
                    da.InsertCommand.Parameters.Add("@excise", SqlDbType.Float).Value = excise;
                    cs.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    cs.Close();
                    da.InsertCommand = new SqlCommand("INSERT INTO inventory (item_name,qty,dilevery_date,supplier_id) VALUES(@item_name,@qty,@dilevery_date,@supplier_id)",cs);
                                                                     //VALUES('" + textBox3.Text + "','" + textBox4.Text + "','" + c + "','" + textBox10.Text + "')", cs);
                    da.InsertCommand.Parameters.Add("@item_name", SqlDbType.NVarChar).Value = textBox3.Text;
                    da.InsertCommand.Parameters.Add("@qty", SqlDbType.Float).Value = textBox4.Text;
                    da.InsertCommand.Parameters.Add("@dilevery_date", SqlDbType.DateTime).Value = c;
                    da.InsertCommand.Parameters.Add("@supplier_id", SqlDbType.NVarChar).Value = textBox10.Text;
                    cs.Open();
                    da.InsertCommand.ExecuteNonQuery();
                    cs.Close();
                    da.UpdateCommand = new SqlCommand("UPDATE quantity SET qty = qty + '"+ f5 +"' WHERE item_name='" + textBox3.Text + "';", cs);
                    cs.Open();
                    da.UpdateCommand.ExecuteNonQuery();
                    cs.Close();

                    log = File.AppendText(Form1.fileloc);
                    log.Write(DateTime.Now);
                    log.WriteLine("---User " + label14.Text + " created purchase invoice NO= " + comboBox1.Text);
                    log.Close();

                    DialogResult dr1;
                    dr1 = MessageBox.Show("Do you want to add more invoice's?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr1 == DialogResult.Yes)
                    {
                        textBox2.Text = "";
                        textBox6.Text = "";
                        
                        textBox8.Text = "";
                        textBox9.Text = "";
                        label17.Text= "";
                        textBox4.Text = "";

                        this.pinvoiceTableAdapter.Fill(this.scm_mainDataSet7.pinvoice);
                        comboBox1.Text = autoincrement();
                        textBox9.Enabled = false;
                        textBox4.Enabled = true;
                    }
                    else
                    {
                        if (dr1 == DialogResult.No)
                        {
                            this.Dispose();
                        }
                    }
                }
            }
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scm_mainDataSet7.pinvoice' table. You can move, or remove it, as needed.
            this.pinvoiceTableAdapter.Fill(this.scm_mainDataSet7.pinvoice);
            // TODO: This line of code loads data into the 'scm_mainDataSet4.item_master' table. You can move, or remove it, as needed.
            
                this.item_masterTableAdapter.Fill(this.scm_mainDataSet4.item_master);
                this.supplierTableAdapter.Fill(this.scm_mainDataSet3.supplier);

                comboBox1.Text = autoincrement();

            
                
                
            
            
            // TODO: This line of code loads data into the 'scm_mainDataSet3.supplier' table. You can move, or remove it, as needed.
            
            label14.Text = Properties.Settings.Default.usr;
            comboBox3.Text = textBox3.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            comboBox3.Text = textBox3.Text;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox4.Enabled = true;
                textBox9.Enabled = false;
            }
            else
            {
                textBox4.Enabled = false;
                textBox9.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

    }
}


        