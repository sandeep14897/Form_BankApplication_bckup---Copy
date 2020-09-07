using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Web;
using System.Security.Permissions;

//[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]

namespace Form_BankApplication
{

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            //WebBrowser.AllowWebBrowserDrop = false;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=BankApplication;Trusted_Connection=True;");
            String Query = "Select * from dbo.User_Data Where Username = '" + textBox1.Text + "' AND PinNumber='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                sdr.Read();
                try
                {
                    if (sdr["PinNumber"].ToString().TrimEnd().Equals(textBox2.Text) && sdr["Username"].ToString().TrimEnd().Equals(textBox1.Text))
                    {
                        Hide();
                        EnquiryForm eForm = new EnquiryForm();
                        eForm.passingvalue = textBox1.Text;
                        eForm.Show();
                    }
                    if (sdr["PinNumber"].ToString().TrimEnd() != textBox2.Text && sdr["Username"].ToString().TrimEnd() == textBox1.Text)
                    {
                        MessageBox.Show("Password is incorrect !");
                        Hide();
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("username : " + textBox1.Text + " doesnot exists");
                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddUser form2 = new AddUser();
            form2.Tag = this;
            form2.Show(this);
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            ForgetPinNumber FrgtPinForm = new ForgetPinNumber();
            FrgtPinForm.Show();
        }
    }
}
