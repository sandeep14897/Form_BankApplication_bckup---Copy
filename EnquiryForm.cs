﻿using System;
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
using System.Drawing.Imaging;

namespace Form_BankApplication
{ 
    public partial class EnquiryForm : Form
    {
        public String Username;
        public Exception e;
        String imgLoc;
        public string passingvalue
        {
            get { return Username; }
            set { Username = value; }
        }

        public EnquiryForm()
        {
            InitializeComponent();
            TechnicalIssues.Visible = false;
            label3.Visible = false;
            pictureBox4.Visible = false;
        }


        // Amount Deposit function
        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
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
                        sdr.Close();
                        cmd2.ExecuteNonQuery();
                        label3.Text = "Amount: "+textBox2.Text+" Deposit successfully!";
                        label3.Visible = true;
                        textBox2.Text = "";
                    }
                    sdr.Close();
                }
            }
            catch (Exception)
            {
                textBox2.Text = "";
            }

            con.Close();
        }

        // Balance Amount Display Function
        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
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
                    textBox1.Enabled = true;
                    //textBox1.Focus();
                    textBox1.BackColor = Color.White;
                    textBox1.Text = "Rs. "+sdr["BalanceAmount"].ToString();
                    pictureBox4.Visible = true;
                    textBox2.Text = "";
                    sdr.Close();
                }
            }
            catch (Exception)
            {
                TechnicalIssues.Visible = true;
            }
            con.Close();
        }


        // Logout Function
        private void button3_Click(object sender, EventArgs e)
        {
            label3.Visible = false;

            ExitApplication loginform = new ExitApplication();
            loginform.Show();
        }


        // Go to user details page function
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
            String Query = "Select * from dbo.User_Data Where Username = '" + Username + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            try
            {
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    label3.Visible = false;
                    sdr.Read();
                    GetUserDetails eForm = new GetUserDetails();
                    eForm.passingvalue = Username;
                    eForm.passingvalue1 = sdr["PhoneNumber"].ToString();
                    eForm.passingvalue2 = sdr["PinNumber"].ToString();
                    eForm.passingvalue3 = sdr["BalanceAmount"].ToString();
                    sdr.Close();
                    Hide();
                    con.Close();
                    eForm.Show();
                }
            }

            catch { 
                
            }
            con.Close();
        }
    
        //Transfer Amount Form
        private void button5_Click(object sender, EventArgs e)
        {
            
            Hide();
            SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
            String Query = "Select * from dbo.User_Data Where Username = '" + Username + "'";
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
                    label3.Visible = false;
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
               
            }

            con.Close();
        }


        private void EnquiryForm_Load(object sender, EventArgs e)
        {
            TechnicalIssues.Visible = false;
            label3.Visible = false;
            SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
            String Query = "Select UserImage from dbo.User_Data Where Username = '" + Username + "'";
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
                        pictureBox2.Image = null;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(data);
                        pictureBox2.Image = System.Drawing.Bitmap.FromStream(ms);
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

        private void Save_Click_1(object sender, EventArgs e)
        {
            try
            {
                label3.Visible = false;
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                String UpdatePic = "Update dbo.User_Data SET UserImage= (@img) Where Username = '" + Username + "'";
                SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
                con.Open();
                SqlCommand comd = new SqlCommand(UpdatePic, con);
                comd.Parameters.Add(new SqlParameter("@img", img));
                int i = comd.ExecuteNonQuery();
                con.Close();
                label3.Visible = true;

            }
            catch
            {

            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                label3.Visible = false;
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|8.gif|All Files(*.*)|*.*";
                dlg.Title = "Select a profile photo";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = dlg.FileName.ToString();
                    pictureBox2.ImageLocation = imgLoc;
                }
            }
            catch
            {
            }
        }

        private void Statement_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server=localhost\MSSQLSERVER01;Database=BankApplication;Trusted_Connection=True;");
            if (!File.Exists("E:\\C#\\Form_BankApplication_bckup - Copy\\LogFiles\\" + Username + "_Statement.txt"))
            {
                File.Create("E:\\C#\\Form_BankApplication_bckup - Copy\\LogFiles\\"+Username+"_Statement.txt");
            }
            String Query = "Select TOP 10 * from dbo.MessageLog Where Username = '" + Username + "'  ORDER BY CURRENT_TIMESTAMP DESC";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);
            try
            {
                foreach (DataRow row in dt.Rows)
                {
                    String TimeStamp = row["TimeStamp1"].ToString();
                    String MessageLog = row["MessageLog"].ToString();
                    File.AppendAllText(@"E:\C#\Form_BankApplication_bckup - Copy\LogFiles\" + Username + "_Statement.txt", TimeStamp + "      |      " + MessageLog + Environment.NewLine);
                }
            }
            catch { 

            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            textBox1.UseSystemPasswordChar = false;
            System.Threading.Thread.Sleep(3000);
            textBox1.UseSystemPasswordChar = true;
        }
    }
}

