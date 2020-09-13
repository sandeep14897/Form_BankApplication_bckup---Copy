﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Numerics;
using System.IO;
using System.Diagnostics;

namespace Form_BankApplication
{
    public partial class TransferAmount : Form
    {
        public String Username;
        public String PhoneNumber;
        public String PinNumber;
        public String BalanceAmount;
        public string passingvalue
        {
            get { return Username; }
            set { Username = value; }
        }
        public string passingvalue1
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }
        public string passingvalue3
        {
            get { return BalanceAmount; }
            set { BalanceAmount = value; }
        }
        public string passingvalue2
        {
            get { return PinNumber; }
            set { PinNumber = value; }
        }

        public TransferAmount()
        {
            InitializeComponent();
            SuccessTrans.Visible = false;
            notAllowed.Visible = false;
            WrongDetails.Visible = false;
            success.Visible = false;
            insufficientLabel.Visible = false;
            Allrequired.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            notAllowed.Visible = false;
            WrongDetails.Visible = false;
            success.Visible = false;
            insufficientLabel.Visible = false;
            Allrequired.Visible = false;
            SqlConnection con = new SqlConnection(@"Server=localhost;Database=BankApplication;Trusted_Connection=True;");
            String Query = "Select * from dbo.User_Data Where Username = '" + textBox1.Text + "' AND PhoneNumber = '" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
                {
                    Allrequired.Visible = true;
                    notAllowed.Visible = false;
                    WrongDetails.Visible = false;
                    success.Visible = false;
                    insufficientLabel.Visible = false;
                    // MessageBox.Show("Please, fill all the input fields !");
                }
                else
                {
                    if (Username.TrimEnd() == textBox1.Text.TrimEnd())
                    {
                        notAllowed.Visible = true;
                        WrongDetails.Visible = false;
                        success.Visible = false;
                        insufficientLabel.Visible = false;
                        Allrequired.Visible = false;
                    }
                    else
                    {
                        if (BigInteger.Parse(textBox3.Text.Trim()) <= BigInteger.Parse(BalanceAmount.TrimEnd()) && Username.TrimEnd() != textBox1.Text.TrimEnd())
                        {
                            using (SqlDataReader sdr = cmd.ExecuteReader())
                            {
                                sdr.Read();
                                String Str_BankBalance = sdr["BalanceAmount"].ToString();
                                BigInteger BankBalance = BigInteger.Parse(Str_BankBalance);
                                BigInteger AmountDeposit = BigInteger.Parse(textBox3.Text) + BankBalance;
                                BigInteger FinalBalance = BigInteger.Parse(BalanceAmount) - BigInteger.Parse(textBox3.Text);
                                String Query2 = "Update dbo.User_Data SET BalanceAmount= " + AmountDeposit + " Where Username = '" + textBox1.Text + "'";
                                String updateBalanceQuery = "Update dbo.User_Data SET BalanceAmount= " + FinalBalance + " Where Username = '" + Username + "'";
                                SqlCommand cmd2 = new SqlCommand(Query2, con);
                                SqlCommand cmd3 = new SqlCommand(updateBalanceQuery, con);
                                cmd2.Parameters.AddWithValue("BalanceAmount", Convert.ToString(AmountDeposit));
                                String Script = File.ReadAllText(@"C:\Users\HP\Documents\SQL Server Management Studio\BankApplicationUserData\BankApplicationUserData\Userdata.sql");
                                sdr.Close();
                                cmd2.ExecuteNonQuery();
                                cmd3.ExecuteNonQuery();
                                success.Visible = true;
                                // MessageBox.Show("Amount : " + textBox3.Text + " Transffered succesfully");
                                textBox2.Text = "";
                                textBox3.Text = "";
                                SuccessTrans.Visible = true;
                                notAllowed.Visible = false;
                                WrongDetails.Visible = false;
                                success.Visible = false;
                                insufficientLabel.Visible = false;
                                Allrequired.Visible = false;
                            }
                        }
                        else
                        {
                            if (BigInteger.Parse(textBox3.Text.Trim()) > BigInteger.Parse(BalanceAmount.TrimEnd()))
                            {
                                insufficientLabel.Visible = true;
                                notAllowed.Visible = false;
                                WrongDetails.Visible = false;
                                success.Visible = false;
                                Allrequired.Visible = false;
                                textBox3.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                WrongDetails.Visible = true;
            }
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Hide();
            GetUserDetails eForm1 = new GetUserDetails();
            EnquiryForm eForm = new EnquiryForm();
            eForm.Username = Username;
            eForm1.GetUsername = Username;
            eForm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ExitApplication loginForm = new ExitApplication();
            loginForm.Show();
        }
    }
}
