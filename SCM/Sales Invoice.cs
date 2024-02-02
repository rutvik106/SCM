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

    public partial class Form8 : Form
    {
        
        SqlConnection cs = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\SCM_Database\\scm_main.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        StreamWriter log;

        public static Label[] lbl = new Label[] { };
        public static TextBox[] txt_box = new TextBox[] { };

        public static string[] items = new string[] { };

        public static int query_loop = 0;

        public void details()
        {

            da.SelectCommand = new SqlCommand("SELECT item_name FROM item_master", cs);
            cs.Open();
            da.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            
            SqlDataReader rdr = da.SelectCommand.ExecuteReader();
            string[] items_array = new string[count];
            int cnt = 0;
            while (rdr.Read() != false)
            {

                items_array[cnt] = rdr.GetValue(0).ToString();
                cnt++;
            }
            cnt--;
            lbl = new Label[count + 1];
            txt_box = new TextBox[count + 1];

            for (int i = 0; i <= count; i++)
            {
                lbl[i] = new Label();
                txt_box[i] = new TextBox();
                lbl[i].Name = "lbl" + i.ToString();
                lbl[i].AutoSize = true;
                txt_box[i].Name = "txt_box" + i.ToString();
                txt_box[i].Size = new System.Drawing.Size(40, 20);
                txt_box[i].Text = "0.0";
                if (i < count)
                {
                    lbl[i].Text = items_array[i].ToString();
                }

                try
                {
                    

                    lbl[i].Location = new Point(lbl[i - 1].Location.X, 50 + lbl[i - 1].Location.Y);
                    txt_box[i].Location = new Point(txt_box[i - 1].Location.X, 50 + txt_box[i - 1].Location.Y);
                    
                }
                catch (Exception)
                {
                }
              
                try
                {
                  
                    lbl[i].Location = new System.Drawing.Point(lbl[i - 1].Location.X, 20 + lbl[i - 1].Location.Y);
                    txt_box[i].Location = new System.Drawing.Point(txt_box[i - 1].Location.X + 10, 20 + txt_box[i - 1].Location.Y);

                    
                }
                catch (Exception)
                {
                    lbl[i].Location = new System.Drawing.Point(groupBox2.Location.X + 10, groupBox2.Location.Y + 15);
                    txt_box[i].Location = new System.Drawing.Point(lbl[0].Location.X + 2, lbl[0].Location.Y - 5);

                }

                flowLayoutPanel1.Controls.Add(lbl[i]);
                if (i == count)
                {

                }
                else
                {
                    flowLayoutPanel1.Controls.Add(txt_box[i]);
                }

            }


            items = new string[count];
            cs.Close();
            ds.Tables[0].Clear();
            items_array.CopyTo(items, 0);
            query_loop = count - 1;


        }


        public string autoincrement()
        {
            string last_val = null;
            int value;
            SqlCommand cmd = new SqlCommand("SELECT sinvoice_no FROM sinvoice", cs);
            cs.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read() == true)
            {
                last_val = rdr.GetString(0).ToString();
            }
            cs.Close();
            //MessageBox.Show(last_val);
            if (last_val != null )
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


        public Form8()
        {
            
            InitializeComponent();
        }

        

        private void Form8_Load(object sender, EventArgs e)
        {
            
            
            // TODO: This line of code loads data into the 'scm_mainDataSet4.item_master' table. You can move, or remove it, as needed.
            
            label14.Text = Properties.Settings.Default.usr;
            //try
            //{
            //this.customerBindingSource.Clear();
            //this.sinvoiceBindingSource.Clear();
            //this.itemmasterBindingSource.Clear();

                //this.item_masterTableAdapter.Fill(this.scm_mainDataSet4.item_master);
                this.sinvoiceTableAdapter.Fill(this.scm_mainDataSet.sinvoice);
                this.customerTableAdapter.Fill(this.scm_mainDataSet2.customer);

               
            
            //}
            //catch (Exception)
            //{
                
            //}

                comboBox1.Text = autoincrement();
                


            
        }

        
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                DialogResult dr;
                MessageBox.Show("You have not added the quantity of items used for this order/batch.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dr = MessageBox.Show("Add quantity of Items first and then save invoice", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(dr == DialogResult.OK)
                {
                    checkBox1.Checked = true;
                }
            }
            else
            {
                try
                {
                    float x, y, z;
                    x = float.Parse(textBox7.Text);
                    y = float.Parse(textBox13.Text);
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
                    textBox13.Text = c.ToString();
                }
                catch (Exception)
                {
                }

                if (comboBox1.Text == "" | textBox10.Text == "" | textBox3.Text == "" | textBox7.Text == "" | textBox13.Text == "" | textBox11.Text == "" | textBox12.Text == "")
                {
                    MessageBox.Show("Required field's are empty", "Info");
                }
                else
                {


                    /*if (textBox9.Enabled == true)
                    {
                        float f1 = float.Parse(textBox6.Text);
                        int f4 = int.Parse(textBox9.Text);
                    
                    }*/
                    float f1;
                    float f4;
                    float.TryParse(textBox6.Text, out f1);
                    float.TryParse(textBox9.Text, out f4);




                    float f2 = float.Parse(textBox7.Text);

                    float f5 = float.Parse(textBox13.Text);
                    float d = f5 * f2;
                    label17.Text = d.ToString();
                    float f3 = float.Parse(label17.Text);


                    float vat = float.Parse(textBox11.Text);
                    float excise = float.Parse(textBox12.Text);
                    float net_total = 0;


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



                    DialogResult dr;
                    DateTime a = dateTimePicker1.Value;
                    DateTime b = dateTimePicker2.Value.Date;
                    DateTime c = dateTimePicker3.Value.Date;

                    dr = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        //MessageBox.Show(a.ToString());
                        //MessageBox.Show(b.ToString());
                        da.InsertCommand = new SqlCommand("INSERT INTO sinvoice (sinvoice_no,customer_id,sinvoice_date,chalan_no,order_no,order_date,mode_of_transport,vehical_reg_no,description,pkg_weight,pkg,total_weight,rate,vat,excise,total,sinvoice_issue,user_id,net_total) VALUES(@sinvoice_no,@customer_id,@sinvoice_date,@chalan_no,@order_no,@order_date,@mode_of_transport,@vehical_reg_no,@description,@pkg_weight,@pkg,@total_weight,@rate,@vat,@excise,@total,@sinvoice_issue,@user_id,@net_total)", cs);
                        //VALUES('" + comboBox1.Text + "','" + textBox10.Text + "','" + a + "','" + textBox2.Text + "','" + textBox3.Text + "','" + b + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox8.Text + "','" + f1 + "','" + f4 + "','" + textBox13.Text + "','" + f2 + "','" + vat + "','" + excise + "','" + f3 + "','" + c + "','"+ label14.Text +"','" + net_total + "')", cs);

                        da.InsertCommand.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar).Value = comboBox1.Text;
                        da.InsertCommand.Parameters.Add("@customer_id", SqlDbType.NVarChar).Value = textBox10.Text;
                        da.InsertCommand.Parameters.Add("@sinvoice_date", SqlDbType.DateTime).Value = a;
                        da.InsertCommand.Parameters.Add("@chalan_no", SqlDbType.NVarChar).Value = textBox2.Text;
                        da.InsertCommand.Parameters.Add("@order_no", SqlDbType.NVarChar).Value = textBox3.Text;
                        da.InsertCommand.Parameters.Add("@order_date", SqlDbType.DateTime).Value = b;
                        da.InsertCommand.Parameters.Add("@mode_of_transport", SqlDbType.VarChar).Value = textBox4.Text;
                        da.InsertCommand.Parameters.Add("vehical_reg_no", SqlDbType.NVarChar).Value = textBox5.Text;
                        da.InsertCommand.Parameters.Add("@description", SqlDbType.VarChar).Value = textBox8.Text;
                        da.InsertCommand.Parameters.Add("@pkg_weight", SqlDbType.Float).Value = f1;
                        da.InsertCommand.Parameters.Add("@pkg", SqlDbType.Int).Value = f4;
                        da.InsertCommand.Parameters.Add("@total_weight", SqlDbType.Float).Value = f5;
                        da.InsertCommand.Parameters.Add("@rate", SqlDbType.Float).Value = f2;
                        da.InsertCommand.Parameters.Add("@vat", SqlDbType.Float).Value = vat;
                        da.InsertCommand.Parameters.Add("@excise", SqlDbType.Float).Value = excise;
                        da.InsertCommand.Parameters.Add("@total", SqlDbType.Float).Value = f3;
                        da.InsertCommand.Parameters.Add("@sinvoice_issue", SqlDbType.DateTime).Value = c;
                        da.InsertCommand.Parameters.Add("@user_id", SqlDbType.NVarChar).Value = label14.Text;
                        da.InsertCommand.Parameters.Add("@net_total", SqlDbType.Float).Value = net_total;

                        cs.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        cs.Close();
                        da.InsertCommand = new SqlCommand("INSERT INTO sales (sinvoice_no,date,customer_id,total,rate,vat,excise) VALUES(@sinvoice_no,@date,@customer_id,@total,@rate,@vat,@excise)", cs);
                        //VALUES('" + comboBox1.Text + "','" + a + "','" + textBox10.Text + "','" + f3 + "','" + textBox7.Text + "','"+ textBox11.Text +"','"+ textBox12.Text +"')", cs);

                        da.InsertCommand.Parameters.Add("@sinvoice_no", SqlDbType.NVarChar).Value = comboBox1.Text;
                        da.InsertCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = a;
                        da.InsertCommand.Parameters.Add("@customer_id", SqlDbType.NVarChar).Value = textBox10.Text;
                        da.InsertCommand.Parameters.Add("@total", SqlDbType.Float).Value = net_total;
                        da.InsertCommand.Parameters.Add("@rate", SqlDbType.Float).Value = f2;
                        da.InsertCommand.Parameters.Add("@vat", SqlDbType.Float).Value = vat;
                        da.InsertCommand.Parameters.Add("@excise", SqlDbType.Float).Value = excise;

                        cs.Open();
                        da.InsertCommand.ExecuteNonQuery();
                        cs.Close();

                        for (int j = 0; j <= query_loop; j++)
                        {
                            da.UpdateCommand = new SqlCommand("UPDATE quantity SET qty=qty - '" + float.Parse(txt_box[j].Text) + "' WHERE item_name='" + lbl[j].Text + "';", cs);
                            cs.Open();
                            da.UpdateCommand.ExecuteNonQuery();
                            cs.Close();
                        }

                        log = File.AppendText(Form1.fileloc);
                        log.Write(DateTime.Now);
                        log.WriteLine("---User " + label14.Text + " created sales invoice NO= " + comboBox1.Text);
                        log.Close();

                        DialogResult dr1;
                        dr1 = MessageBox.Show("Do you want to add more invoice's?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr1 == DialogResult.Yes)
                        {
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox9.Text = "";
                            label17.Text = "";
                            textBox13.Text = "";

                            //this.item_masterTableAdapter.Fill(this.scm_mainDataSet4.item_master);
                            this.sinvoiceTableAdapter.Fill(this.scm_mainDataSet.sinvoice);
                            comboBox1.Text = autoincrement();
                            textBox9.Enabled = false;
                            textBox13.Enabled = true;

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
            
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

            // only allow one decimal point
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
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
                textBox13.Enabled = true;
                textBox9.Enabled = false;
            }
            else
            {
                textBox13.Enabled = false;
                textBox9.Enabled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form18 f18 = new Form18();
            //f18.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.Size = new System.Drawing.Size(983, 375);
                details();
            }
            if (checkBox1.Checked == false)
            {
                this.Size = new System.Drawing.Size(692, 375);
                flowLayoutPanel1.Controls.Clear();
            }
        }

        
        
    }
}
