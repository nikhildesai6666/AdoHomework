using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace AdoHomework
{
    public partial class Form1 : Form

    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            string str = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            con = new SqlConnection(str);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "insert into student values(@nm,@city,@per)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@nm", txtname.Text);
                cmd.Parameters.AddWithValue("@city",txtcity.Text);
                cmd.Parameters.AddWithValue("@per",Convert.ToDecimal( txtpercentage.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = " update student set name=@nm,city=@city,percentage=@per where rollno=@rn";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@nm", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@per", Convert.ToDecimal(txtpercentage.Text));
                cmd.Parameters.AddWithValue("@rn", Convert.ToInt32(txtrollno.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = " delate from student where rollno=@rn";
                cmd = new SqlCommand(qry, con); 
                cmd.Parameters.AddWithValue("@rn", Convert.ToInt32(txtrollno.Text));
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageBox.Show("Record deletedd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from student where rollno=@rn";
                cmd = new SqlCommand(qry, con);
                
                cmd.Parameters.AddWithValue("@rn", Convert.ToInt32(txtrollno.Text));
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while(dr.Read())
                    {
                        txtname.Text = dr["name"].ToString();
                        txtcity.Text = dr["city"].ToString();
                        txtpercentage.Text = dr["percentage"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show( "Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnshowall_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from student";
                cmd = new SqlCommand(qry, con);
                con.Open();
                dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    DataTable table = new DataTable();
                    table.Load(dr);
                    dataGridView1.DataSource = table;
                }
                else
                {
                    MessageBox.Show( "Record not found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
