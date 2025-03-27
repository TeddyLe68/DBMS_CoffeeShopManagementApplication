namespace CoffeeShopApplication.UC
{
    partial class HomeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeControl));
            this.lbHello = new System.Windows.Forms.Label();
            this.pbManageAccount = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.pbAccounts = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbManageAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // lbHello
            // 
            this.lbHello.AutoSize = true;
            this.lbHello.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHello.ForeColor = System.Drawing.Color.Chocolate;
            this.lbHello.Location = new System.Drawing.Point(63, 33);
            this.lbHello.Name = "lbHello";
            this.lbHello.Size = new System.Drawing.Size(78, 30);
            this.lbHello.TabIndex = 14;
            this.lbHello.Text = "Hello !!!";
            // 
            // pbManageAccount
            // 
            this.pbManageAccount.Image = ((System.Drawing.Image)(resources.GetObject("pbManageAccount.Image")));
            this.pbManageAccount.Location = new System.Drawing.Point(7, 13);
            this.pbManageAccount.Name = "pbManageAccount";
            this.pbManageAccount.Size = new System.Drawing.Size(50, 50);
            this.pbManageAccount.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbManageAccount.TabIndex = 13;
            this.pbManageAccount.TabStop = false;
            this.pbManageAccount.Click += new System.EventHandler(this.pbManageAccount_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnLogOut.FlatAppearance.BorderColor = System.Drawing.Color.NavajoWhite;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.Chocolate;
            this.btnLogOut.Location = new System.Drawing.Point(560, 412);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(150, 40);
            this.btnLogOut.TabIndex = 12;
            this.btnLogOut.Text = "LOG OUT";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe Print", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Chocolate;
            this.label10.Location = new System.Drawing.Point(259, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(753, 65);
            this.label10.TabIndex = 11;
            this.label10.Text = "Wellcome To Coffee Shop Management";
            // 
            // pbAccounts
            // 
            this.pbAccounts.Image = ((System.Drawing.Image)(resources.GetObject("pbAccounts.Image")));
            this.pbAccounts.Location = new System.Drawing.Point(481, 13);
            this.pbAccounts.Name = "pbAccounts";
            this.pbAccounts.Size = new System.Drawing.Size(300, 300);
            this.pbAccounts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAccounts.TabIndex = 10;
            this.pbAccounts.TabStop = false;
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbHello);
            this.Controls.Add(this.pbManageAccount);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pbAccounts);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(1262, 518);
            ((System.ComponentModel.ISupportInitialize)(this.pbManageAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHello;
        private System.Windows.Forms.PictureBox pbManageAccount;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pbAccounts;
    }
}
