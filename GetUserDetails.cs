﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_BankApplication
{
    public partial class GetUserDetails : Form
    {
        public String GetUsername;
        public String GetPhoneNumber;
        public String GetPinNumber;
        public String GetBalanceAmount;
        public byte[] GetUserImage;
        
        public string passingvalue
        {
            get { return GetUsername; }
            set { GetUsername = value; }
        }
        public string passingvalue1
        {
            get { return GetPhoneNumber; }
            set { GetPhoneNumber = value; }
        }
        public string passingvalue2
        {
            get { return GetPinNumber; }
            set { GetPinNumber = value; }
        }
        public string passingvalue3
        {
            get { return GetBalanceAmount; }
            set { GetBalanceAmount = value; }
        }
        public GetUserDetails()
        {
            InitializeComponent();
            label5.Visible = false;
            label6.Visible = false;
            //label7.Visible = false;
            label8.Visible = false;
            button3.Enabled = false;
            pictureBox4.Visible = true;
        }

        String password = "";

        private void GetUserDetails_Load(object sender, EventArgs e)
        {
            try
            {
                EnquiryForm e1 = new EnquiryForm();
                textBox1.Text = GetUsername.TrimEnd();
                textBox2.Text = GetPhoneNumber.TrimEnd();
                //password = encryptpass(GetPinNumber);
                textBox3.Text = GetPinNumber.TrimEnd();
                textBox4.Text = "Rs. "+GetBalanceAmount.TrimEnd();
                button2.Enabled = true;
                //label3.Visible = false;
                SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
                String Query = "Select UserImage from dbo.User_Data Where Username = '" + GetUsername + "'";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                try
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        byte[] data = (byte[])sdr[0];
                        if (data == null)
                        {
                            UserImage.Image = null;
                        }
                        else
                        {
                            MemoryStream ms = new MemoryStream(data);
                            UserImage.Image = System.Drawing.Bitmap.FromStream(ms);
                        }
                        sdr.Close();
                        Hide();
                        con.Close();
                    }
                }
                catch
                {
                }
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hide();
            EnquiryForm enquiryForm = new EnquiryForm();
            enquiryForm.Username = textBox1.Text;
            enquiryForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            label5.Visible = false;
            label6.Visible = false;
            //label7.Visible = false;
            label8.Visible = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
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
                    password = encryptpass(textBox3.Text);
                    if (sdr["Username"].ToString().Trim().Equals(textBox1.Text) && sdr["PhoneNumber"].ToString().Trim().Equals(textBox2.Text) && sdr["PinNumber"].ToString().Trim().Equals(password))
                    {
                        label6.Visible = false;
                        label8.Visible = false;
                        label5.Visible = true;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox1.Enabled = false;
                        button3.Enabled = false;
                    }
                    else 
                    {
                        con.Close();
                        String Query = "Update dbo.User_Data SET Username = '" + textBox1.Text + "',PhoneNumber='" + textBox2.Text + "', PinNumber='" + password + "' WHERE Username = '" + GetUsername + "'";
                        SqlCommand cmd = new SqlCommand(Query, con);
                        cmd.Connection = con;
                        con.Open();
                       // password = encryptpass(textBox3.Text);
                        cmd.Parameters.AddWithValue("Username", textBox1.Text);
                        cmd.Parameters.AddWithValue("PhoneNumber", textBox2.Text);
                        cmd.Parameters.AddWithValue("PinNumber", password);

                        if (textBox1.Text.TrimEnd() == "" || textBox2.Text.TrimEnd() == "" || textBox3.Text.TrimEnd() == "" || textBox2.Text.TrimEnd().Length != 10 || textBox3.Text.TrimEnd().Length != 6)
                        {
                            label5.Visible = false;
                            label6.Visible = false;
                            label8.Visible = true;
                            //label7.Visible = true;
                            label8.Text = "No fields should be empty! Phone number must be 10 digits and pin number must be 6 digits";
                        }
                        else
                        {
                            try
                            {
                                //String Script = File.ReadAllText(@"C:\Users\HP\Documents\SQL Server Management Studio\BankApplicationUserData\BankApplicationUserData\Userdata.sql");
                                cmd.ExecuteNonQuery();
                                label5.Visible = false;
                                //label7.Visible = false;
                                label8.Visible = false;
                                label6.Visible = true;
                                textBox2.Enabled = false;
                                textBox3.Enabled = false;
                                textBox1.Enabled = false;
                                EnquiryForm enquiryForm = new EnquiryForm();
                                enquiryForm.Username = textBox1.Text;
                                button3.Enabled = false;
                            }
                            catch
                            {
                                label5.Visible = false;
                                label6.Visible = false;
                                //label7.Visible = false;
                                label8.Visible = true;
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //MessageBox.Show("999999999999");
                    con.Close();
                    String Query = "Update dbo.User_Data SET Username = '" + textBox1.Text + "',PhoneNumber='" + textBox2.Text + "', PinNumber='" + password + "' WHERE Username = '" + GetUsername + "'";
                    SqlCommand cmd = new SqlCommand(Query, con);
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("Username", textBox1.Text);
                    cmd.Parameters.AddWithValue("PhoneNumber", textBox2.Text);
                    cmd.Parameters.AddWithValue("PinNumber", password);

                    if (textBox1.Text.TrimEnd() == "" || textBox2.Text.TrimEnd() == "" || textBox3.Text.TrimEnd() == "" || textBox2.Text.TrimEnd().Length != 10 || textBox3.Text.TrimEnd().Length != 6)
                    {
                        label5.Visible = false;
                        label6.Visible = false;
                        label8.Visible = true;
                        //label7.Visible = true;
                        label8.Text = "No fields should be empty! Phone number must be 10 digits and pin number must be 6 digits";
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                    else
                    {
                        try
                        {
                            String Script = File.ReadAllText(@"C:\Users\HP\Documents\SQL Server Management Studio\BankApplicationUserData\BankApplicationUserData\Userdata.sql");
                            cmd.ExecuteNonQuery();
                            label5.Visible = false;
                            //label7.Visible = false;
                            label8.Visible = false;
                            label6.Visible = true;
                            EnquiryForm enquiryForm = new EnquiryForm();
                            enquiryForm.Username = textBox1.Text;
                            button3.Enabled = false;
                        }
                        catch
                        {
                            label5.Visible = false;
                            label6.Visible = false;
                            //label7.Visible = false;
                            label8.Visible = true;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                        }
                    }
                }
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExitApplication e1 = new ExitApplication();
            e1.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
            textBox4.UseSystemPasswordChar = false;
            System.Threading.Thread.Sleep(3000);
            textBox4.UseSystemPasswordChar = true;
        }
        public string encryptpass(string password)
        {
            byte[] encode = Encoding.UTF8.GetBytes(password);
            string msg = Convert.ToBase64String(encode);
            return msg;
        }
    }
}
