namespace Library
{
    partial class frmScreenBooksForMembers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScreenBooksForMembers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnIssueBook = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtSearchBooks = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSearchBooks = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvListOfBooks = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblMode = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnIssueBook.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueBook.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIssueBook.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIssueBook.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIssueBook.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnIssueBook.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnIssueBook.ForeColor = System.Drawing.Color.White;
            this.btnIssueBook.Image = ((System.Drawing.Image)(resources.GetObject("btnIssueBook.Image")));
            this.btnIssueBook.Location = new System.Drawing.Point(12, 503);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(112, 33);
            this.btnIssueBook.TabIndex = 27;
            this.btnIssueBook.Text = "Issue Book";
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.FillColor = System.Drawing.Color.Black;
            this.guna2PictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox3.Image")));
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(744, 111);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(20, 30);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 25;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.UseTransparentBackground = true;
            // 
            // txtSearchBooks
            // 
            this.txtSearchBooks.AutoRoundedCorners = true;
            this.txtSearchBooks.BorderRadius = 25;
            this.txtSearchBooks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchBooks.DefaultText = "";
            this.txtSearchBooks.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchBooks.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchBooks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBooks.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBooks.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBooks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchBooks.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBooks.Location = new System.Drawing.Point(47, 98);
            this.txtSearchBooks.Name = "txtSearchBooks";
            this.txtSearchBooks.PasswordChar = '\0';
            this.txtSearchBooks.PlaceholderText = "";
            this.txtSearchBooks.SelectedText = "";
            this.txtSearchBooks.Size = new System.Drawing.Size(730, 53);
            this.txtSearchBooks.TabIndex = 24;
            this.txtSearchBooks.TextChanged += new System.EventHandler(this.txtSearchBooks_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Search Book By";
            // 
            // cbSearchBooks
            // 
            this.cbSearchBooks.BackColor = System.Drawing.Color.Transparent;
            this.cbSearchBooks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSearchBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchBooks.FillColor = System.Drawing.Color.CornflowerBlue;
            this.cbSearchBooks.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSearchBooks.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSearchBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cbSearchBooks.ForeColor = System.Drawing.Color.White;
            this.cbSearchBooks.ItemHeight = 30;
            this.cbSearchBooks.Items.AddRange(new object[] {
            "BookID",
            "Tital",
            "Author",
            "Gener"});
            this.cbSearchBooks.Location = new System.Drawing.Point(138, 42);
            this.cbSearchBooks.Name = "cbSearchBooks";
            this.cbSearchBooks.Size = new System.Drawing.Size(183, 36);
            this.cbSearchBooks.TabIndex = 29;
            this.cbSearchBooks.SelectedIndexChanged += new System.EventHandler(this.cbSearchBooks_SelectedIndexChanged);
            // 
            // dgvListOfBooks
            // 
            this.dgvListOfBooks.AllowUserToAddRows = false;
            this.dgvListOfBooks.AllowUserToDeleteRows = false;
            this.dgvListOfBooks.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListOfBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListOfBooks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListOfBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListOfBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListOfBooks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListOfBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListOfBooks.Location = new System.Drawing.Point(22, 170);
            this.dgvListOfBooks.Name = "dgvListOfBooks";
            this.dgvListOfBooks.ReadOnly = true;
            this.dgvListOfBooks.RowHeadersVisible = false;
            this.dgvListOfBooks.Size = new System.Drawing.Size(804, 298);
            this.dgvListOfBooks.TabIndex = 56;
            this.dgvListOfBooks.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListOfBooks.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListOfBooks.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListOfBooks.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListOfBooks.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListOfBooks.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListOfBooks.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListOfBooks.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListOfBooks.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dgvListOfBooks.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvListOfBooks.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListOfBooks.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListOfBooks.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvListOfBooks.ThemeStyle.ReadOnly = true;
            this.dgvListOfBooks.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListOfBooks.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListOfBooks.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvListOfBooks.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListOfBooks.ThemeStyle.RowsStyle.Height = 22;
            this.dgvListOfBooks.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListOfBooks.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(342, 9);
            this.lblMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(91, 25);
            this.lblMode.TabIndex = 57;
            this.lblMode.Text = "BOOKS";
            // 
            // frmScreenBooksForMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(838, 548);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.dgvListOfBooks);
            this.Controls.Add(this.cbSearchBooks);
            this.Controls.Add(this.btnIssueBook);
            this.Controls.Add(this.guna2PictureBox3);
            this.Controls.Add(this.txtSearchBooks);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScreenBooksForMembers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmScreenBooksForMembers";
            this.Load += new System.EventHandler(this.frmScreenBooksForMembers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnIssueBook;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBooks;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cbSearchBooks;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListOfBooks;
        private System.Windows.Forms.Label lblMode;
    }
}