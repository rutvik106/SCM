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
    public partial class Form12 : Form5
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("data grid empty","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                
                if (dataGridView1.RowCount==0)
                {
                    MessageBox.Show("Table empty","Info",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    int i = dataGridView1.CurrentRow.Index;
                    if (comboBox1.SelectedIndex == 0)
                    {

                        da.DeleteCommand = new SqlCommand("DELETE FROM customer WHERE customer_id=@id", cn);
                        da.DeleteCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i][0];
                        cn.Open();
                        try
                        {
                            da.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot Delete Violating Forign Key");
                        }
                        cn.Close();
                        ds.Clear();
                        da.Fill(ds);
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        da.DeleteCommand = new SqlCommand("DELETE FROM inventory WHERE inventory_no=@no", cn);
                        da.DeleteCommand.Parameters.Add("@no", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i][0];
                        cn.Open();
                        try
                        {
                            da.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot Delete Violating Forign Key");
                        }
                        cn.Close();
                        ds.Clear();
                        da.Fill(ds);
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        da.DeleteCommand = new SqlCommand("DELETE FROM sinvoice WHERE sinvoice_no=@no", cn);
                        da.DeleteCommand.Parameters.Add("@no", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i][0];
                        cn.Open();
                        try
                        {
                            da.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot Delete Violating Forign Key");
                        }
                        cn.Close();
                        ds.Clear();
                        da.Fill(ds);
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        da.DeleteCommand = new SqlCommand("DELETE FROM item_master WHERE item_name=@name", cn);
                        da.DeleteCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i][0];
                        cn.Open();
                        try
                        {
                            da.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot Delete Violating Forign Key");
                        }
                        cn.Close();
                        ds.Clear();
                        da.Fill(ds);
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        da.DeleteCommand = new SqlCommand("DELETE FROM supplier WHERE supplier_id=@id", cn);
                        da.DeleteCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i][0];
                        cn.Open();
                        try
                        {
                            da.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot Delete Violating Forign Key");
                        }
                        cn.Close();
                        ds.Clear();
                        da.Fill(ds);
                    }
                    if (comboBox1.SelectedIndex == 5)
                    {
                        if (ds.Tables[0].Rows[i][0].ToString() == SCM.Properties.Settings.Default.usr)
                        {
                            MessageBox.Show("cannot delete current user");
                        }
                        else
                        {
                            da.DeleteCommand = new SqlCommand("DELETE FROM user_master WHERE user_id=@id", cn);
                            da.DeleteCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i][0];
                            cn.Open();
                            try
                            {
                                da.DeleteCommand.ExecuteNonQuery();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Cannot Delete Violating Forign Key");
                            }
                            cn.Close();
                            ds.Clear();
                            da.Fill(ds);
                        }
                    }
                    if (comboBox1.SelectedIndex == 6)
                    {

                        da.DeleteCommand = new SqlCommand("DELETE FROM sales WHERE no=@no", cn);
                        da.DeleteCommand.Parameters.Add("@no", SqlDbType.Int).Value = ds.Tables[0].Rows[i][0];
                        cn.Open();
                        try
                        {
                            da.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot Delete Violating Forign Key");
                        }
                        cn.Close();
                        ds.Clear();
                        da.Fill(ds);

                    }
                    if (comboBox1.SelectedIndex == 7)
                    {

                        da.DeleteCommand = new SqlCommand("DELETE FROM pinvoice WHERE pinvoice_no=@no", cn);
                        da.DeleteCommand.Parameters.Add("@no", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i][0];
                        cn.Open();
                        try
                        {
                            da.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot Delete Violating Forign Key");
                        }
                        cn.Close();
                        ds.Clear();
                        da.Fill(ds);

                    }

                    if (comboBox1.SelectedIndex == 8)
                    {

                        da.DeleteCommand = new SqlCommand("DELETE FROM purchase WHERE no=@no", cn);
                        da.DeleteCommand.Parameters.Add("@no", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i][0];
                        cn.Open();
                        try
                        {
                            da.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot Delete Violating Forign Key");
                        }
                        cn.Close();
                        ds.Clear();
                        da.Fill(ds);

                    }

                    if (comboBox1.SelectedIndex == 9)
                    {

                        da.DeleteCommand = new SqlCommand("DELETE FROM quantity WHERE no=@no", cn);
                        da.DeleteCommand.Parameters.Add("@no", SqlDbType.NVarChar).Value = ds.Tables[0].Rows[i][0];
                        cn.Open();
                        try
                        {
                            da.DeleteCommand.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Cannot Delete Violating Forign Key");
                        }
                        cn.Close();
                        ds.Clear();
                        da.Fill(ds);

                    }

                }
            }
        }
    }
}
