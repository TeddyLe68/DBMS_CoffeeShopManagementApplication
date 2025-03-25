namespace CoffeeShopApplication.UC
{
    partial class ShopOrderBillControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopOrderBillControl));
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDeleted = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.customerIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rewardPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updatedAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDeletedDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pbRefresh = new System.Windows.Forms.PictureBox();
            this.tbBillId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbInitialBill = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFinalBill = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRewardPointUsed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbEmployeeId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCustomerId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.pbSave = new System.Windows.Forms.PictureBox();
            this.pbRefreshOrderBill = new System.Windows.Forms.PictureBox();
            this.pbDelete = new System.Windows.Forms.PictureBox();
            this.dgvOrderBill = new System.Windows.Forms.DataGridView();
            this.billIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rewardPointsUsedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initialBillDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finalBillDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isDeletedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.employeeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefreshOrderBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderBill)).BeginInit();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(263, 7);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(200, 31);
            this.tbSearch.TabIndex = 23;
            // 
            // pbSearch
            // 
            this.pbSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSearch.Image = ((System.Drawing.Image)(resources.GetObject("pbSearch.Image")));
            this.pbSearch.Location = new System.Drawing.Point(477, 7);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(30, 30);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSearch.TabIndex = 25;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 22);
            this.label5.TabIndex = 24;
            this.label5.Text = "Search By Customer Name";
            // 
            // cbDeleted
            // 
            this.cbDeleted.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDeleted.FormattingEnabled = true;
            this.cbDeleted.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbDeleted.Location = new System.Drawing.Point(161, 234);
            this.cbDeleted.Name = "cbDeleted";
            this.cbDeleted.Size = new System.Drawing.Size(170, 30);
            this.cbDeleted.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Deleted";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvCustomer);
            this.panel1.Controls.Add(this.pbRefresh);
            this.panel1.Controls.Add(this.tbSearch);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pbSearch);
            this.panel1.Location = new System.Drawing.Point(441, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 255);
            this.panel1.TabIndex = 28;
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customerIdDataGridViewTextBoxColumn1,
            this.customerNameDataGridViewTextBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn,
            this.rewardPointDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn1,
            this.updatedAtDataGridViewTextBoxColumn,
            this.isDeletedDataGridViewCheckBoxColumn1});
            this.dgvCustomer.Location = new System.Drawing.Point(3, 49);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowHeadersWidth = 51;
            this.dgvCustomer.RowTemplate.Height = 24;
            this.dgvCustomer.Size = new System.Drawing.Size(794, 201);
            this.dgvCustomer.TabIndex = 46;
            this.dgvCustomer.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellContentClick);
            // 
            // customerIdDataGridViewTextBoxColumn1
            // 
            this.customerIdDataGridViewTextBoxColumn1.DataPropertyName = "customerId";
            this.customerIdDataGridViewTextBoxColumn1.HeaderText = "customerId";
            this.customerIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.customerIdDataGridViewTextBoxColumn1.Name = "customerIdDataGridViewTextBoxColumn1";
            this.customerIdDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            this.customerNameDataGridViewTextBoxColumn.DataPropertyName = "customerName";
            this.customerNameDataGridViewTextBoxColumn.HeaderText = "customerName";
            this.customerNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            this.customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "phoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "phoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            this.phoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rewardPointDataGridViewTextBoxColumn
            // 
            this.rewardPointDataGridViewTextBoxColumn.DataPropertyName = "rewardPoint";
            this.rewardPointDataGridViewTextBoxColumn.HeaderText = "rewardPoint";
            this.rewardPointDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.rewardPointDataGridViewTextBoxColumn.Name = "rewardPointDataGridViewTextBoxColumn";
            this.rewardPointDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdAtDataGridViewTextBoxColumn1
            // 
            this.createdAtDataGridViewTextBoxColumn1.DataPropertyName = "createdAt";
            this.createdAtDataGridViewTextBoxColumn1.HeaderText = "createdAt";
            this.createdAtDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.createdAtDataGridViewTextBoxColumn1.Name = "createdAtDataGridViewTextBoxColumn1";
            this.createdAtDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // updatedAtDataGridViewTextBoxColumn
            // 
            this.updatedAtDataGridViewTextBoxColumn.DataPropertyName = "updatedAt";
            this.updatedAtDataGridViewTextBoxColumn.HeaderText = "updatedAt";
            this.updatedAtDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.updatedAtDataGridViewTextBoxColumn.Name = "updatedAtDataGridViewTextBoxColumn";
            this.updatedAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isDeletedDataGridViewCheckBoxColumn1
            // 
            this.isDeletedDataGridViewCheckBoxColumn1.DataPropertyName = "isDeleted";
            this.isDeletedDataGridViewCheckBoxColumn1.HeaderText = "isDeleted";
            this.isDeletedDataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.isDeletedDataGridViewCheckBoxColumn1.Name = "isDeletedDataGridViewCheckBoxColumn1";
            this.isDeletedDataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // pbRefresh
            // 
            this.pbRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pbRefresh.Image")));
            this.pbRefresh.Location = new System.Drawing.Point(520, 7);
            this.pbRefresh.Name = "pbRefresh";
            this.pbRefresh.Size = new System.Drawing.Size(30, 30);
            this.pbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRefresh.TabIndex = 45;
            this.pbRefresh.TabStop = false;
            this.pbRefresh.Click += new System.EventHandler(this.pbRefresh_Click);
            // 
            // tbBillId
            // 
            this.tbBillId.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBillId.Location = new System.Drawing.Point(161, 10);
            this.tbBillId.Name = "tbBillId";
            this.tbBillId.Size = new System.Drawing.Size(170, 29);
            this.tbBillId.TabIndex = 29;
            this.tbBillId.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "Bill ID";
            // 
            // tbInitialBill
            // 
            this.tbInitialBill.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInitialBill.Location = new System.Drawing.Point(161, 47);
            this.tbInitialBill.Name = "tbInitialBill";
            this.tbInitialBill.Size = new System.Drawing.Size(170, 29);
            this.tbInitialBill.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Initial Bill";
            // 
            // tbFinalBill
            // 
            this.tbFinalBill.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFinalBill.Location = new System.Drawing.Point(161, 85);
            this.tbFinalBill.Name = "tbFinalBill";
            this.tbFinalBill.Size = new System.Drawing.Size(170, 29);
            this.tbFinalBill.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "Final Bill";
            // 
            // tbRewardPointUsed
            // 
            this.tbRewardPointUsed.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRewardPointUsed.Location = new System.Drawing.Point(161, 122);
            this.tbRewardPointUsed.Name = "tbRewardPointUsed";
            this.tbRewardPointUsed.Size = new System.Drawing.Size(170, 29);
            this.tbRewardPointUsed.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 22);
            this.label6.TabIndex = 36;
            this.label6.Text = "Point Used ";
            // 
            // tbEmployeeId
            // 
            this.tbEmployeeId.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmployeeId.Location = new System.Drawing.Point(161, 160);
            this.tbEmployeeId.Name = "tbEmployeeId";
            this.tbEmployeeId.Size = new System.Drawing.Size(170, 29);
            this.tbEmployeeId.TabIndex = 37;
            this.tbEmployeeId.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 22);
            this.label7.TabIndex = 38;
            this.label7.Text = "Employee ID";
            // 
            // tbCustomerId
            // 
            this.tbCustomerId.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomerId.Location = new System.Drawing.Point(161, 197);
            this.tbCustomerId.Name = "tbCustomerId";
            this.tbCustomerId.Size = new System.Drawing.Size(170, 29);
            this.tbCustomerId.TabIndex = 39;
            this.tbCustomerId.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 22);
            this.label8.TabIndex = 40;
            this.label8.Text = "Customer ID";
            // 
            // pbAdd
            // 
            this.pbAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAdd.Image = ((System.Drawing.Image)(resources.GetObject("pbAdd.Image")));
            this.pbAdd.Location = new System.Drawing.Point(366, 10);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(40, 40);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdd.TabIndex = 44;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // pbSave
            // 
            this.pbSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSave.Image = ((System.Drawing.Image)(resources.GetObject("pbSave.Image")));
            this.pbSave.Location = new System.Drawing.Point(366, 224);
            this.pbSave.Name = "pbSave";
            this.pbSave.Size = new System.Drawing.Size(40, 40);
            this.pbSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSave.TabIndex = 43;
            this.pbSave.TabStop = false;
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbRefreshOrderBill
            // 
            this.pbRefreshOrderBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRefreshOrderBill.Image = ((System.Drawing.Image)(resources.GetObject("pbRefreshOrderBill.Image")));
            this.pbRefreshOrderBill.Location = new System.Drawing.Point(366, 154);
            this.pbRefreshOrderBill.Name = "pbRefreshOrderBill";
            this.pbRefreshOrderBill.Size = new System.Drawing.Size(40, 40);
            this.pbRefreshOrderBill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRefreshOrderBill.TabIndex = 42;
            this.pbRefreshOrderBill.TabStop = false;
            this.pbRefreshOrderBill.Click += new System.EventHandler(this.pbRefreshOrderBill_Click);
            // 
            // pbDelete
            // 
            this.pbDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDelete.Image = ((System.Drawing.Image)(resources.GetObject("pbDelete.Image")));
            this.pbDelete.Location = new System.Drawing.Point(366, 80);
            this.pbDelete.Name = "pbDelete";
            this.pbDelete.Size = new System.Drawing.Size(40, 40);
            this.pbDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDelete.TabIndex = 41;
            this.pbDelete.TabStop = false;
            // 
            // dgvOrderBill
            // 
            this.dgvOrderBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.billIdDataGridViewTextBoxColumn,
            this.rewardPointsUsedDataGridViewTextBoxColumn,
            this.initialBillDataGridViewTextBoxColumn,
            this.finalBillDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.isDeletedDataGridViewCheckBoxColumn,
            this.employeeIdDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn});
            this.dgvOrderBill.Location = new System.Drawing.Point(21, 287);
            this.dgvOrderBill.Name = "dgvOrderBill";
            this.dgvOrderBill.RowHeadersWidth = 51;
            this.dgvOrderBill.RowTemplate.Height = 24;
            this.dgvOrderBill.Size = new System.Drawing.Size(1222, 215);
            this.dgvOrderBill.TabIndex = 45;
            this.dgvOrderBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderBill_CellContentClick);
            this.dgvOrderBill.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderBill_CellContentDoubleClick);
            // 
            // billIdDataGridViewTextBoxColumn
            // 
            this.billIdDataGridViewTextBoxColumn.DataPropertyName = "billId";
            this.billIdDataGridViewTextBoxColumn.HeaderText = "billId";
            this.billIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.billIdDataGridViewTextBoxColumn.Name = "billIdDataGridViewTextBoxColumn";
            this.billIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rewardPointsUsedDataGridViewTextBoxColumn
            // 
            this.rewardPointsUsedDataGridViewTextBoxColumn.DataPropertyName = "rewardPointsUsed";
            this.rewardPointsUsedDataGridViewTextBoxColumn.HeaderText = "rewardPointsUsed";
            this.rewardPointsUsedDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.rewardPointsUsedDataGridViewTextBoxColumn.Name = "rewardPointsUsedDataGridViewTextBoxColumn";
            this.rewardPointsUsedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // initialBillDataGridViewTextBoxColumn
            // 
            this.initialBillDataGridViewTextBoxColumn.DataPropertyName = "initialBill";
            this.initialBillDataGridViewTextBoxColumn.HeaderText = "initialBill";
            this.initialBillDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.initialBillDataGridViewTextBoxColumn.Name = "initialBillDataGridViewTextBoxColumn";
            this.initialBillDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // finalBillDataGridViewTextBoxColumn
            // 
            this.finalBillDataGridViewTextBoxColumn.DataPropertyName = "finalBill";
            this.finalBillDataGridViewTextBoxColumn.HeaderText = "finalBill";
            this.finalBillDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.finalBillDataGridViewTextBoxColumn.Name = "finalBillDataGridViewTextBoxColumn";
            this.finalBillDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "createdAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "createdAt";
            this.createdAtDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            this.createdAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isDeletedDataGridViewCheckBoxColumn
            // 
            this.isDeletedDataGridViewCheckBoxColumn.DataPropertyName = "isDeleted";
            this.isDeletedDataGridViewCheckBoxColumn.HeaderText = "isDeleted";
            this.isDeletedDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isDeletedDataGridViewCheckBoxColumn.Name = "isDeletedDataGridViewCheckBoxColumn";
            this.isDeletedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            this.employeeIdDataGridViewTextBoxColumn.DataPropertyName = "employeeId";
            this.employeeIdDataGridViewTextBoxColumn.HeaderText = "employeeId";
            this.employeeIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            this.employeeIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "customerId";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "customerId";
            this.customerIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            this.customerIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ShopOrderBillControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvOrderBill);
            this.Controls.Add(this.pbAdd);
            this.Controls.Add(this.pbSave);
            this.Controls.Add(this.pbRefreshOrderBill);
            this.Controls.Add(this.pbDelete);
            this.Controls.Add(this.tbCustomerId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbEmployeeId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbRewardPointUsed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbFinalBill);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbInitialBill);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBillId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbDeleted);
            this.Controls.Add(this.label3);
            this.Name = "ShopOrderBillControl";
            this.Size = new System.Drawing.Size(1262, 518);
            this.Load += new System.EventHandler(this.ShopOrderBillControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRefreshOrderBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDeleted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbBillId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbInitialBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFinalBill;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbRewardPointUsed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbEmployeeId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCustomerId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbAdd;
        private System.Windows.Forms.PictureBox pbSave;
        private System.Windows.Forms.PictureBox pbRefreshOrderBill;
        private System.Windows.Forms.PictureBox pbDelete;
        private System.Windows.Forms.PictureBox pbRefresh;
        private System.Windows.Forms.DataGridView dgvOrderBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn billIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rewardPointsUsedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn initialBillDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn finalBillDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDeletedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rewardPointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn updatedAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isDeletedDataGridViewCheckBoxColumn1;
    }
}
