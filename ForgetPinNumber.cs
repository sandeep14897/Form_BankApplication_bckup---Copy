using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Form_BankApplication
{
    public partial class ForgetPinNumber : Form
    {
        
        public ForgetPinNumber()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=BankApplication;Trusted_Connection=True;");
            String Query = "Select * from dbo.User_Data Where Username = '" + textBox1.Text + "' AND PhoneNumber='"+textBox2.Text+"'";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            try
            {
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    if (sdr["PhoneNumber"].ToString().TrimEnd() == textBox2.Text && sdr["Username"].ToString().TrimEnd() == textBox1.Text)
                    {
                        String PinNumber = sdr["PinNumber"].ToString();
                        MessageBox.Show("The Pin Number is : " + PinNumber);
                    }
                    else {
                        MessageBox.Show("Oops! Details provided are not correct !");
                    }
                }
            }
            catch {
                MessageBox.Show("Username or phone Number doesnot exits!");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginform = new LoginForm();
            loginform.Show();
        }
    }
}
