namespace Form_BankApplication
{
    partial class TransferAmount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferAmount));
            this.panel1 = new System.Windows.Forms.Panel();
            this.success = new System.Windows.Forms.Label();
            this.WrongDetails = new System.Windows.Forms.Label();
            this.notAllowed = new System.Windows.Forms.Label();
            this.SuccessTrans = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.insufficientLabel = new System.Windows.Forms.Label();
            this.Allrequired = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuccessTrans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Allrequired);
            this.panel1.Controls.Add(this.insufficientLabel);
            this.panel1.Controls.Add(this.success);
            this.panel1.Controls.Add(this.WrongDetails);
            this.panel1.Controls.Add(this.notAllowed);
            this.panel1.Controls.Add(this.SuccessTrans);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 397);
            this.panel1.TabIndex = 10;
            // 
            // success
            // 
            this.success.AutoSize = true;
            this.success.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.success.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.success.Location = new System.Drawing.Point(326, 318);
            this.success.Name = "success";
            this.success.Size = new System.Drawing.Size(225, 20);
            this.success.TabIndex = 25;
            this.success.Text = "Hurray! Transaction is success";
            // 
            // WrongDetails
            // 
            this.WrongDetails.AutoSize = true;
            this.WrongDetails.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WrongDetails.ForeColor = System.Drawing.Color.Red;
            this.WrongDetails.Location = new System.Drawing.Point(278, 318);
            this.WrongDetails.Name = "WrongDetails";
            this.WrongDetails.Size = new System.Drawing.Size(346, 20);
            this.WrongDetails.TabIndex = 24;
            this.WrongDetails.Text = "Sorry! Username or Phone number is incorrect";
            this.WrongDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notAllowed
            // 
            this.notAllowed.AutoSize = true;
            this.notAllowed.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notAllowed.ForeColor = System.Drawing.Color.Red;
            this.notAllowed.Location = new System.Drawing.Point(275, 318);
            this.notAllowed.Name = "notAllowed";
            this.notAllowed.Size = new System.Drawing.Size(349, 20);
            this.notAllowed.TabIndex = 23;
            this.notAllowed.Text = "Sorry! Not allowed to transfer to the same Account";
            this.notAllowed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SuccessTrans
            // 
            this.SuccessTrans.Image = ((System.Drawing.Image)(resources.GetObject("SuccessTrans.Image")));
            this.SuccessTrans.Location = new System.Drawing.Point(309, 86);
            this.SuccessTrans.Name = "SuccessTrans";
            this.SuccessTrans.Size = new System.Drawing.Size(277, 229);
            this.SuccessTrans.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SuccessTrans.TabIndex = 22;
            this.SuccessTrans.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(319, 303);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(227, 1);
            this.panel4.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(319, 234);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 1);
            this.panel3.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(322, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 1);
            this.panel2.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(381, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightGreen;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(404, 341);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 34);
            this.button3.TabIndex = 18;
            this.button3.Text = "Bank To Home";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(776, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 48);
            this.button2.TabIndex = 17;
            this.button2.Text = "Log Out";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(293, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 34);
            this.button1.TabIndex = 16;
            this.button1.Text = "Transfer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(321, 277);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(224, 20);
            this.textBox3.TabIndex = 15;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(320, 208);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(227, 20);
            this.textBox2.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(323, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 20);
            this.textBox1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Amount to transfer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Recepient Phone Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Recepient Username";
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.HideSelection = false;
            this.textBox6.Location = new System.Drawing.Point(185, 736);
            this.textBox6.Margin = new System.Windows.Forms.Padding(0);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(498, 28);
            this.textBox6.TabIndex = 13;
            this.textBox6.Text = "Helpline Numbers: 1800-2345-3333, 1800-2345-5555";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(405, 681);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.HideSelection = false;
            this.textBox5.Location = new System.Drawing.Point(280, 619);
            this.textBox5.Margin = new System.Windows.Forms.Padding(0);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(323, 44);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "For any login or technical support. Please, contact our team";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(882, 211);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // insufficientLabel
            // 
            this.insufficientLabel.AutoSize = true;
            this.insufficientLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insufficientLabel.ForeColor = System.Drawing.Color.Red;
            this.insufficientLabel.Location = new System.Drawing.Point(377, 318);
            this.insufficientLabel.Name = "insufficientLabel";
            this.insufficientLabel.Size = new System.Drawing.Size(137, 20);
            this.insufficientLabel.TabIndex = 26;
            this.insufficientLabel.Text = "Insufficient funds!";
            this.insufficientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Allrequired
            // 
            this.Allrequired.AutoSize = true;
            this.Allrequired.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Allrequired.ForeColor = System.Drawing.Color.Red;
            this.Allrequired.Location = new System.Drawing.Point(325, 318);
            this.Allrequired.Name = "Allrequired";
            this.Allrequired.Size = new System.Drawing.Size(222, 20);
            this.Allrequired.TabIndex = 27;
            this.Allrequired.Text = "Please, fill all the input fields !";
            // 
            // TransferAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 853);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "TransferAmount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TransferAmount";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SuccessTrans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox SuccessTrans;
        private System.Windows.Forms.Label notAllowed;
        private System.Windows.Forms.Label WrongDetails;
        private System.Windows.Forms.Label success;
        private System.Windows.Forms.Label insufficientLabel;
        private System.Windows.Forms.Label Allrequired;
    }
}