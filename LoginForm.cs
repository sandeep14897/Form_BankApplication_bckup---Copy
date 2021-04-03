using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Windows;

//[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]

namespace Form_BankApplication
{

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            label3.Visible = false;
            label4.Visible = false;

        }
        public Image UserImage;

        private void button2_Click_1(object sender, EventArgs e)
        {
            AddUser form2 = new AddUser();
            form2.Tag = this;
            form2.Show(this);
            Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Hide();
            ForgetPinNumber FrgtPinForm = new ForgetPinNumber();
            FrgtPinForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
            String Query = "Select * from dbo.User_Data Where Username = '" + textBox1.Text + "'";
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

                        EnquiryForm eForm = new EnquiryForm();
                        eForm.passingvalue = textBox1.Text;
                        eForm.Show();
                        Hide();
                        con.Close();
                    }

                    else
                    {
                        if (sdr["PinNumber"].ToString().TrimEnd() != textBox2.Text && sdr["Username"].ToString().TrimEnd() == textBox1.Text)
                        {
                            con.Close();
                            label4.Visible = true;
                        }
                        else
                        {
                            con.Close();
                            label3.Visible = true;
                        }
                    }
                }
                catch (Exception)
                {
                    con.Close();
                    label3.Visible = true;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExitApplication ea = new ExitApplication();
            ea.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar=false;
            System.Threading.Thread.Sleep(3000);
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
