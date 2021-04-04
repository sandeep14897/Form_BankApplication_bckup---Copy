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
            SuccessLabel.Visible = false;
            EmptyFields.Visible = false;
            textBox4.UseSystemPasswordChar = true;
            validCredentials.Visible = false;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
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
                        SuccessLabel.Visible = false;
                        EmptyFields.Visible = true;
                        validCredentials.Visible = false;
                        EmptyFields.Text = "Username already exists !";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                }
                catch (Exception)
                {
                    try{
                        con.Close();
                        String Query = "INSERT INTO dbo.User_Data(Username,PhoneNumber,BalanceAmount,PinNumber) VALUES (@Username,@PhoneNumber,@BalanceAmount,@PinNumber)";
                        SqlCommand cmd = new SqlCommand(Query, con);
                        cmd.Connection = con;
                        con.Open();
                        string strpass = encryptpass(textBox3.Text);
                        cmd.Parameters.AddWithValue("Username", textBox1.Text);
                        cmd.Parameters.AddWithValue("PhoneNumber", textBox2.Text);
                        cmd.Parameters.AddWithValue("PinNumber", strpass);
                        cmd.Parameters.AddWithValue("BalanceAmount", textBox4.Text);
                        Console.WriteLine(textBox3.Text.TrimEnd().Length);
                        Console.WriteLine(textBox3.Text.TrimEnd().Length != 6);

                        if (textBox1.Text.TrimEnd() == "" || textBox2.Text.TrimEnd() == "" || textBox3.Text.TrimEnd() == "" || textBox4.Text.TrimEnd() == "" || textBox2.Text.TrimEnd().Length != 10 || textBox3.Text.TrimEnd().Length != 6)

                        {
                            SuccessLabel.Visible = false;
                            EmptyFields.Visible = true;
                            validCredentials.Visible = true;
                            EmptyFields.Text = "Please, provide all the fields in correct format!";
                            validCredentials.Text = "Phone number should have 10 digits Or Pin Number should have 6 digits !";
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                        }
                        else
                        {
                            try
                            {
                               // String Script = File.ReadAllText(@"C:\Users\HP\Documents\SQL Server Management Studio\BankApplicationUserData\BankApplicationUserData\Userdata.sql");
                                cmd.ExecuteNonQuery();
                                EmptyFields.Visible = false;
                                SuccessLabel.Visible = true;
                                validCredentials.Visible = false;
                                SuccessLabel.Text = "User added Successfully";
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                EmptyFields.Visible = false;
                                SuccessLabel.Visible = false;
                                validCredentials.Visible = false;
                                SuccessLabel.Text = "Sorry!!! Error While registering the data of user. Please, try after sometime";
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                            }
                        }
                    }
                    catch (Exception E){
                        EmptyFields.Text = "Please, provide all the fields in correct format!";
                        validCredentials.Text = "Phone number should have 10 digits Or Pin Number should have 6 digits !";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        //MessageBox.Show(E.Message);
                    }
                }
            }
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = false;
            System.Threading.Thread.Sleep(2000);
            textBox3.UseSystemPasswordChar = true;
        }

        public string encryptpass(string password)
        {
            //string msg = "";
            //int pass_Length = password.Length;
            //byte[] encode = new byte[pass_Length];
            byte[] encode = Encoding.UTF8.GetBytes(password);
            string msg = Convert.ToBase64String(encode);
            return msg;
        }
    }

}
