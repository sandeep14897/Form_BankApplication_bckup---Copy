using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.IO;

namespace Form_BankApplication
{
    
    public partial class EnquiryForm : Form
    {
        public String Username;
        public Exception e;
        public string passingvalue {
            get { return Username; }
            set { Username = value;  }
        }

        public EnquiryForm()
        {
            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        // Amount Deposit function
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=BankApplication;Trusted_Connection=True;");
            try
            {
                String Query1 = "Select * from dbo.User_Data Where Username = '" + Username + "'";
            SqlCommand cmd1 = new SqlCommand(Query1, con);
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = con;
            con.Open();
            int j = cmd1.ExecuteNonQuery();

                using (SqlDataReader sdr = cmd1.ExecuteReader())
                {
                sdr.Read();
                    if (textBox2.Text != "")
                    {
                        String Str_BankBalance = sdr["BalanceAmount"].ToString();
                        BigInteger BankBalance = BigInteger.Parse(Str_BankBalance);
                        BigInteger AmountDeposit = BigInteger.Parse(textBox2.Text) + BankBalance;
                        String Query2 = "Update dbo.User_Data SET BalanceAmount= " + AmountDeposit + " Where Username = '" + Username + "'";
                        SqlCommand cmd2 = new SqlCommand(Query2, con);
                        cmd2.Parameters.AddWithValue("BalanceAmount", Convert.ToString(AmountDeposit));
                        //String Script = File.ReadAllText(@"C:\Users\HP\Documents\SQL Server Management Studio\BankApplicationUserData\BankApplicationUserData\Userdata.sql");
                        sdr.Close();
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Amount : " + textBox2.Text + " Deposited succesfully");
                        textBox2.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Exception occured");
            }

            con.Close();
        }

        // Balance Amount Display Function
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=BankApplication;Trusted_Connection=True;");
            try
            {
                String Query = "Select * from dbo.User_Data Where Username = '" + Username + "'";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    textBox1.Text = sdr["BalanceAmount"].ToString();
                    textBox2.Text = "";
                }
            }
            catch (Exception)
            {
               MessageBox.Show("Exception occured");
            }

            con.Close();
        }


        // Logout Function
        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginform = new LoginForm();
            loginform.Show();
        }


        // Go to user details page function
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=BankApplication;Trusted_Connection=True;");
            String Query = "Select * from dbo.User_Data Where Username = '" + Username + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            try
            {
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    GetUserDetails eForm = new GetUserDetails();
                    
                    eForm.passingvalue = Username; 
                    eForm.passingvalue1 = sdr["PhoneNumber"].ToString();
                    eForm.passingvalue2 = sdr["PinNumber"].ToString();
                    eForm.passingvalue3= sdr["BalanceAmount"].ToString();
                    eForm.Show();

                    Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("User not exits !");
            }

            con.Close();
        }
        //Transfer Amount Form
        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=BankApplication;Trusted_Connection=True;");
            String Query = "Select * from dbo.User_Data Where Username = '" + Username + "'";
            //MessageBox.Show(Username);
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            try
            {
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();

                    TransferAmount TForm = new TransferAmount();
                    TForm.Show();
                    TForm.passingvalue = sdr["Username"].ToString();
                    TForm.passingvalue1 = sdr["PhoneNumber"].ToString();
                    TForm.passingvalue2 = sdr["PinNumber"].ToString();
                    TForm.passingvalue3 = sdr["BalanceAmount"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("User not exits !");
            }

            con.Close();
        }
    }
}

