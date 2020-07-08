namespace BNSManagement
{
    partial class User
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
            this.cat_btn = new System.Windows.Forms.Button();
            this.connect_btn = new System.Windows.Forms.Button();
            this.shop_btn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ip_tx = new System.Windows.Forms.TextBox();
            this.pass_tx = new System.Windows.Forms.TextBox();
            this.user_tx = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cat_btn
            // 
            this.cat_btn.Enabled = false;
            this.cat_btn.Location = new System.Drawing.Point(12, 12);
            this.cat_btn.Name = "cat_btn";
            this.cat_btn.Size = new System.Drawing.Size(96, 50);
            this.cat_btn.TabIndex = 0;
            this.cat_btn.Text = "EDIT CATEGORY";
            this.cat_btn.UseVisualStyleBackColor = true;
            this.cat_btn.Click += new System.EventHandler(this.cat_btn_Click);
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(190, 239);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(98, 41);
            this.connect_btn.TabIndex = 1;
            this.connect_btn.Text = "Connect";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // shop_btn
            // 
            this.shop_btn.Enabled = false;
            this.shop_btn.Location = new System.Drawing.Point(128, 12);
            this.shop_btn.Name = "shop_btn";
            this.shop_btn.Size = new System.Drawing.Size(98, 50);
            this.shop_btn.TabIndex = 2;
            this.shop_btn.Text = "ADD ITEMSHOP";
            this.shop_btn.UseVisualStyleBackColor = true;
            this.shop_btn.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(247, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 50);
            this.button4.TabIndex = 3;
            this.button4.Text = "ADD BOXSHOP";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(375, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 50);
            this.button5.TabIndex = 4;
            this.button5.Text = "RELOAD SERVER";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ip_tx
            // 
            this.ip_tx.Location = new System.Drawing.Point(163, 150);
            this.ip_tx.Name = "ip_tx";
            this.ip_tx.Size = new System.Drawing.Size(153, 20);
            this.ip_tx.TabIndex = 5;
            this.ip_tx.Text = "154.202.3.61,1433";
            this.ip_tx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pass_tx
            // 
            this.pass_tx.Location = new System.Drawing.Point(197, 202);
            this.pass_tx.Name = "pass_tx";
            this.pass_tx.PasswordChar = '*';
            this.pass_tx.Size = new System.Drawing.Size(91, 20);
            this.pass_tx.TabIndex = 6;
            // 
            // user_tx
            // 
            this.user_tx.Location = new System.Drawing.Point(207, 176);
            this.user_tx.Name = "user_tx";
            this.user_tx.Size = new System.Drawing.Size(69, 20);
            this.user_tx.TabIndex = 7;
            this.user_tx.Text = "sa";
            this.user_tx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "EXIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(12, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 34);
            this.button2.TabIndex = 9;
            this.button2.Text = "ADD CATEGORY";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 337);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.user_tx);
            this.Controls.Add(this.pass_tx);
            this.Controls.Add(this.ip_tx);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.shop_btn);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.cat_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "User";
            this.Text = "User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ip_tx;
        private System.Windows.Forms.TextBox pass_tx;
        private System.Windows.Forms.TextBox user_tx;
        public System.Windows.Forms.Button connect_btn;
        public System.Windows.Forms.Button cat_btn;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button shop_btn;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button button2;
    }
}