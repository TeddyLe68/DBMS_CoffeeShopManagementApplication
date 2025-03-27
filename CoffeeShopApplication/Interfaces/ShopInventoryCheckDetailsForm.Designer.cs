namespace CoffeeShopApplication.Interfaces
{
    partial class ShopInventoryCheckDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopInventoryCheckDetailsForm));
            this.pnlInverntoryCheckDetailInfo = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIngredient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCheckId = new System.Windows.Forms.TextBox();
            this.dgvInventoryCheckDetails = new System.Windows.Forms.DataGridView();
            this.checkIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlInverntoryCheckDetailInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryCheckDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInverntoryCheckDetailInfo
            // 
            this.pnlInverntoryCheckDetailInfo.BackColor = System.Drawing.Color.NavajoWhite;
            this.pnlInverntoryCheckDetailInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.label7);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.pbAdd);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.pbSave);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.pbRefresh);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.pbDelete);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.tbQuantity);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.label5);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.cbIngredient);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.label3);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.label4);
            this.pnlInverntoryCheckDetailInfo.Controls.Add(this.tbCheckId);
            this.pnlInverntoryCheckDetailInfo.Location = new System.Drawing.Point(12, 12);
            this.pnlInverntoryCheckDetailInfo.Name = "pnlInverntoryCheckDetailInfo";
            this.pnlInverntoryCheckDetailInfo.Size = new System.Drawing.Size(409, 329);
            this.pnlInverntoryCheckDetailInfo.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Chocolate;
            this.label7.Location = new System.Drawing.Point(13, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(378, 31);
            this.label7.TabIndex = 77;
            this.label7.Text = "\"Success is a journey, not a destination.\"";
            // 
            // pbAdd
            // 
            this.pbAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAdd.Image = ((System.Drawing.Image)(resources.GetObject("pbAdd.Image")));
            this.pbAdd.Location = new System.Drawing.Point(88, 214);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(40, 40);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdd.TabIndex = 76;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // pbSave
            // 
            this.pbSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSave.Image = ((System.Drawing.Image)(resources.GetObject("pbSave.Image")));
            this.pbSave.Location = new System.Drawing.Point(276, 214);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(40, 40);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 75;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbRefresh
            // 
            this.pbRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pbRefresh.Image")));
            this.pbRefresh.Location = new System.Drawing.Point(214, 214);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(40, 40);
            this.pbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRefresh.TabIndex = 74;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // pbDelete
            // 
            this.pbDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDelete.Image = ((System.Drawing.Image)(resources.GetObject("pbDelete.Image")));
            this.pbDelete.Location = new System.Drawing.Point(151, 214);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(40, 40);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDelete.TabIndex = 73;
            this.pbDelete.TabStop = false;
            this.pbDelete.Click += new System.EventHandler(this.pbDelete_Click);
            // 
            // tbQuantity
            // 
            this.tbQuantity.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuantity.Location = new System.Drawing.Point(191, 139);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(210, 31);
            this.tbQuantity.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 23);
            this.label5.TabIndex = 71;
            this.label5.Text = "Quantity";
            // 
            // cbIngredient
            // 
            this.cbIngredient.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIngredient.FormattingEnabled = true;
            this.cbIngredient.Location = new System.Drawing.Point(191, 76);
            this.cbIngredient.Name = "cbIngredient";
            this.cbIngredient.Size = new System.Drawing.Size(210, 31);
            this.cbIngredient.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 69;
            this.label3.Text = "Ingredient";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 23);
            this.label4.TabIndex = 67;
            this.label4.Text = "ID";
            // 
            // tbCheckId
            // 
            this.tbCheckId.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCheckId.Location = new System.Drawing.Point(191, 14);
            this.tbCheckId.Name = "tbCheckId";
            this.tbCheckId.Size = new System.Drawing.Size(210, 31);
            this.tbCheckId.TabIndex = 68;
            // 
            // dgvInventoryCheckDetails
            // 
            this.dgvInventoryCheckDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventoryCheckDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryCheckDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkIdDataGridViewTextBoxColumn,
            this.ingredientNameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dgvInventoryCheckDetails.Location = new System.Drawing.Point(438, 12);
            this.dgvInventoryCheckDetails.Name = "dgvInventoryCheckDetails";
            this.dgvInventoryCheckDetails.RowHeadersWidth = 51;
            this.dgvInventoryCheckDetails.RowTemplate.Height = 24;
            this.dgvInventoryCheckDetails.Size = new System.Drawing.Size(732, 329);
            this.dgvInventoryCheckDetails.TabIndex = 1;
            this.dgvInventoryCheckDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventoryCheckDetails_CellContentClick);
            // 
            // checkIdDataGridViewTextBoxColumn
            // 
            this.checkIdDataGridViewTextBoxColumn.DataPropertyName = "checkId";
            this.checkIdDataGridViewTextBoxColumn.HeaderText = "checkId";
            this.checkIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.checkIdDataGridViewTextBoxColumn.Name = "checkIdDataGridViewTextBoxColumn";
            this.checkIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ingredientNameDataGridViewTextBoxColumn
            // 
            this.ingredientNameDataGridViewTextBoxColumn.DataPropertyName = "ingredientName";
            this.ingredientNameDataGridViewTextBoxColumn.HeaderText = "ingredientName";
            this.ingredientNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ingredientNameDataGridViewTextBoxColumn.Name = "ingredientNameDataGridViewTextBoxColumn";
            this.ingredientNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "quantity";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ShopInventoryCheckDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 353);
            this.Controls.Add(this.dgvInventoryCheckDetails);
            this.Controls.Add(this.pnlInverntoryCheckDetailInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShopInventoryCheckDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShopInventoryCheckDetailsForm";
            this.Load += new System.EventHandler(this.ShopInventoryCheckDetailsForm_Load);
            this.pnlInverntoryCheckDetailInfo.ResumeLayout(false);
            this.pnlInverntoryCheckDetailInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryCheckDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInverntoryCheckDetailInfo;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbIngredient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCheckId;
        private System.Windows.Forms.PictureBox pbAdd;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.PictureBox pbDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvInventoryCheckDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}