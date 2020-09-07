using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void GetUserDetails_Load(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = GetUsername.TrimEnd();
                textBox2.Text = GetPhoneNumber.TrimEnd();
                textBox3.Text = GetPinNumber.TrimEnd();
                textBox4.Text = GetBalanceAmount.TrimEnd();
            }
            catch (Exception)
            {
                MessageBox.Show("User not exits !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            EnquiryForm enquiryForm = new EnquiryForm();
            enquiryForm.Username = GetUsername;
            enquiryForm.Show();
        }
    }
}
