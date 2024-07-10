namespace Library
{
    partial class frmAddAndUpdateBorroing
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddAndUpdateBorroing));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.numBookID = new System.Windows.Forms.NumericUpDown();
            this.numMemberID = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateIssueDate = new System.Windows.Forms.DateTimePicker();
            this.dateDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnShowInfoBook = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowInfoMember = new Guna.UI2.WinForms.Guna2Button();
            this.lblisValibla = new System.Windows.Forms.Label();
            this.dgvShowMember = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvShowBook = new Guna.UI2.WinForms.Guna2DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numBookID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMemberID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(193, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 33);
            this.btnCancel.TabIndex = 81;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.Lime;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(55, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 33);
            this.btnSave.TabIndex = 80;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(212, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 76;
            this.label2.Text = "Book ID:";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(285, 52);
            this.lblMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(192, 25);
            this.lblMode.TabIndex = 75;
            this.lblMode.Text = "ADD NEW ISSUE";
            // 
            // numBookID
            // 
            this.numBookID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBookID.Location = new System.Drawing.Point(298, 127);
            this.numBookID.Name = "numBookID";
            this.numBookID.Size = new System.Drawing.Size(120, 27);
            this.numBookID.TabIndex = 82;
            this.numBookID.ValueChanged += new System.EventHandler(this.numBookID_ValueChanged);
            // 
            // numMemberID
            // 
            this.numMemberID.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMemberID.Location = new System.Drawing.Point(298, 224);
            this.numMemberID.Name = "numMemberID";
            this.numMemberID.Size = new System.Drawing.Size(120, 27);
            this.numMemberID.TabIndex = 84;
            this.numMemberID.ValueChanged += new System.EventHandler(this.numMemberID_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 231);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 83;
            this.label1.Text = "Member ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 350);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 85;
            this.label3.Text = "Issue Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(119, 395);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 87;
            this.label4.Text = "Due Date:";
            // 
            // dateIssueDate
            // 
            this.dateIssueDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateIssueDate.Location = new System.Drawing.Point(228, 349);
            this.dateIssueDate.Name = "dateIssueDate";
            this.dateIssueDate.Size = new System.Drawing.Size(132, 27);
            this.dateIssueDate.TabIndex = 88;
            // 
            // dateDueDate
            // 
            this.dateDueDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDueDate.Location = new System.Drawing.Point(228, 388);
            this.dateDueDate.Name = "dateDueDate";
            this.dateDueDate.Size = new System.Drawing.Size(132, 27);
            this.dateDueDate.TabIndex = 89;
            // 
            // btnShowInfoBook
            // 
            this.btnShowInfoBook.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnShowInfoBook.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowInfoBook.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowInfoBook.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowInfoBook.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowInfoBook.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowInfoBook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowInfoBook.ForeColor = System.Drawing.Color.White;
            this.btnShowInfoBook.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnShowInfoBook.Image = ((System.Drawing.Image)(resources.GetObject("btnShowInfoBook.Image")));
            this.btnShowInfoBook.Location = new System.Drawing.Point(471, 121);
            this.btnShowInfoBook.Name = "btnShowInfoBook";
            this.btnShowInfoBook.Size = new System.Drawing.Size(112, 33);
            this.btnShowInfoBook.TabIndex = 90;
            this.btnShowInfoBook.Text = "Show Info";
            this.btnShowInfoBook.Click += new System.EventHandler(this.btnShowInfoBook_Click);
            // 
            // btnShowInfoMember
            // 
            this.btnShowInfoMember.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnShowInfoMember.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowInfoMember.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowInfoMember.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowInfoMember.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowInfoMember.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowInfoMember.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowInfoMember.ForeColor = System.Drawing.Color.White;
            this.btnShowInfoMember.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnShowInfoMember.Image = ((System.Drawing.Image)(resources.GetObject("btnShowInfoMember.Image")));
            this.btnShowInfoMember.Location = new System.Drawing.Point(471, 218);
            this.btnShowInfoMember.Name = "btnShowInfoMember";
            this.btnShowInfoMember.Size = new System.Drawing.Size(112, 33);
            this.btnShowInfoMember.TabIndex = 91;
            this.btnShowInfoMember.Text = "Show Info";
            this.btnShowInfoMember.Click += new System.EventHandler(this.btnShowInfoMember_Click);
            // 
            // lblisValibla
            // 
            this.lblisValibla.AutoSize = true;
            this.lblisValibla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblisValibla.Location = new System.Drawing.Point(608, 121);
            this.lblisValibla.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblisValibla.Name = "lblisValibla";
            this.lblisValibla.Size = new System.Drawing.Size(152, 20);
            this.lblisValibla.TabIndex = 92;
            this.lblisValibla.Text = "Is Book Available:";
            // 
            // dgvShowMember
            // 
            this.dgvShowMember.AllowUserToAddRows = false;
            this.dgvShowMember.AllowUserToDeleteRows = false;
            this.dgvShowMember.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvShowMember.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowMember.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowMember.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShowMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowMember.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvShowMember.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvShowMember.Location = new System.Drawing.Point(36, 270);
            this.dgvShowMember.Name = "dgvShowMember";
            this.dgvShowMember.ReadOnly = true;
            this.dgvShowMember.RowHeadersVisible = false;
            this.dgvShowMember.Size = new System.Drawing.Size(768, 48);
            this.dgvShowMember.TabIndex = 96;
            this.dgvShowMember.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvShowMember.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvShowMember.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvShowMember.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvShowMember.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvShowMember.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvShowMember.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvShowMember.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvShowMember.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dgvShowMember.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvShowMember.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvShowMember.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvShowMember.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvShowMember.ThemeStyle.ReadOnly = true;
            this.dgvShowMember.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvShowMember.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvShowMember.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvShowMember.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvShowMember.ThemeStyle.RowsStyle.Height = 22;
            this.dgvShowMember.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvShowMember.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvShowMember.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(758, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 97;
            this.pictureBox1.TabStop = false;
            // 
            // dgvShowBook
            // 
            this.dgvShowBook.AllowUserToAddRows = false;
            this.dgvShowBook.AllowUserToDeleteRows = false;
            this.dgvShowBook.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvShowBook.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvShowBook.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShowBook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvShowBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowBook.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvShowBook.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvShowBook.Location = new System.Drawing.Point(36, 170);
            this.dgvShowBook.Name = "dgvShowBook";
            this.dgvShowBook.ReadOnly = true;
            this.dgvShowBook.RowHeadersVisible = false;
            this.dgvShowBook.Size = new System.Drawing.Size(768, 42);
            this.dgvShowBook.TabIndex = 102;
            this.dgvShowBook.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvShowBook.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvShowBook.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvShowBook.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvShowBook.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvShowBook.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvShowBook.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvShowBook.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvShowBook.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dgvShowBook.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvShowBook.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvShowBook.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvShowBook.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvShowBook.ThemeStyle.ReadOnly = true;
            this.dgvShowBook.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvShowBook.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvShowBook.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvShowBook.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvShowBook.ThemeStyle.RowsStyle.Height = 22;
            this.dgvShowBook.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvShowBook.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvShowBook.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddAndUpdateBorroing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(831, 534);
            this.Controls.Add(this.dgvShowBook);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvShowMember);
            this.Controls.Add(this.lblisValibla);
            this.Controls.Add(this.btnShowInfoMember);
            this.Controls.Add(this.btnShowInfoBook);
            this.Controls.Add(this.dateDueDate);
            this.Controls.Add(this.dateIssueDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numMemberID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numBookID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMode);
            this.Name = "frmAddAndUpdateBorroing";
            this.Text = "frmAddAndUpdateBorroing";
            this.Load += new System.EventHandler(this.frmAddAndUpdateBorroing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBookID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMemberID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.NumericUpDown numBookID;
        private System.Windows.Forms.NumericUpDown numMemberID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateIssueDate;
        private System.Windows.Forms.DateTimePicker dateDueDate;
        private Guna.UI2.WinForms.Guna2Button btnShowInfoBook;
        private Guna.UI2.WinForms.Guna2Button btnShowInfoMember;
        private System.Windows.Forms.Label lblisValibla;
        private Guna.UI2.WinForms.Guna2DataGridView dgvShowMember;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvShowBook;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}