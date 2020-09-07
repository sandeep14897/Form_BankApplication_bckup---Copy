using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Form_BankApplication
{

    public partial class AddUser : Form
    {

        public AddUser()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=BankApplication;Trusted_Connection=True;");
            con.Open();

            String Query1 = "Select * from dbo.User_Data Where Username = '" + textBox1.Text + "'";

            SqlCommand cmd1 = new SqlCommand(Query1, con);
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;

            SqlDataReader sdr = cmd1.ExecuteReader();
            {
                sdr.Read();
                try
                {
                    if (sdr["Username"].ToString().Trim().Equals(textBox1.Text))
                    {
                        MessageBox.Show("User already exists !");
                    }
                }
                catch (Exception) {
                    con.Close();
                    String Query = "INSERT INTO dbo.User_Data(Username,PhoneNumber,BalanceAmount,PinNumber) VALUES (@Username,@PhoneNumber,@BalanceAmount,@PinNumber)";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Connection = con;
                    con.Open();
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Username", textBox1.Text);
                    cmd.Parameters.AddWithValue("PhoneNumber", textBox2.Text);
                    cmd.Parameters.AddWithValue("PinNumber", textBox3.Text);
                    cmd.Parameters.AddWithValue("BalanceAmount", textBox4.Text);

                    if (textBox1.Text.TrimEnd() == "" || textBox2.Text.TrimEnd() == "" || textBox3.Text.TrimEnd() == "" || textBox4.Text.TrimEnd() == "")
                    {
                        MessageBox.Show("No Fields should be empty ! Please, fill all the fields.");
                    }
                    else
                    {    
                      try
                      {
                            String Script = File.ReadAllText(@"C:\Users\HP\Documents\SQL Server Management Studio\BankApplicationUserData\BankApplicationUserData\Userdata.sql");
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User added Successfully !");
                      }
                       catch {
                            MessageBox.Show("Please, provide details in correct format");
                        }
                    }
                }
            }
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }

}
