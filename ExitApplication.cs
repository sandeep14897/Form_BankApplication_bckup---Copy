using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Form_BankApplication
{
    public partial class ExitApplication : Form
    {
        public ExitApplication()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm l1 = new LoginForm();
            Hide();
            l1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Process[] ps = Process.GetProcessesByName("Form_BankApplication");

            foreach (Process p in ps)
                p.Kill();
        }
    }
}
