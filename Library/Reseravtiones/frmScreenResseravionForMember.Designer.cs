namespace Library
{
    partial class frmScreenResseravionForMember
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScreenResseravionForMember));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSearchReservationID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddResravtion = new Guna.UI2.WinForms.Guna2Button();
            this.dgvListOfReservations = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblMode = new System.Windows.Forms.Label();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchReservationID
            // 
            this.txtSearchReservationID.AutoRoundedCorners = true;
            this.txtSearchReservationID.BorderRadius = 25;
            this.txtSearchReservationID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchReservationID.DefaultText = "";
            this.txtSearchReservationID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchReservationID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchReservationID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchReservationID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchReservationID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchReservationID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchReservationID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchReservationID.Location = new System.Drawing.Point(53, 88);
            this.txtSearchReservationID.Name = "txtSearchReservationID";
            this.txtSearchReservationID.PasswordChar = '\0';
            this.txtSearchReservationID.PlaceholderText = "";
            this.txtSearchReservationID.SelectedText = "";
            this.txtSearchReservationID.Size = new System.Drawing.Size(697, 53);
            this.txtSearchReservationID.TabIndex = 35;
            this.txtSearchReservationID.TextChanged += new System.EventHandler(this.txtSearchReservationID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(62, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Search Reservation ID:";
            // 
            // btnAddResravtion
            // 
            this.btnAddResravtion.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddResravtion.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddResravtion.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddResravtion.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddResravtion.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddResravtion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddResravtion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddResravtion.ForeColor = System.Drawing.Color.White;
            this.btnAddResravtion.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddResravtion.Image = ((System.Drawing.Image)(resources.GetObject("btnAddResravtion.Image")));
            this.btnAddResravtion.Location = new System.Drawing.Point(66, 489);
            this.btnAddResravtion.Name = "btnAddResravtion";
            this.btnAddResravtion.Size = new System.Drawing.Size(112, 33);
            this.btnAddResravtion.TabIndex = 41;
            this.btnAddResravtion.Text = "AddNew";
            this.btnAddResravtion.Click += new System.EventHandler(this.btnAddResravtion_Click);
            // 
            // dgvListOfReservations
            // 
            this.dgvListOfReservations.AllowUserToAddRows = false;
            this.dgvListOfReservations.AllowUserToDeleteRows = false;
            this.dgvListOfReservations.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvListOfReservations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListOfReservations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListOfReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListOfReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListOfReservations.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListOfReservations.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListOfReservations.Location = new System.Drawing.Point(66, 153);
            this.dgvListOfReservations.Name = "dgvListOfReservations";
            this.dgvListOfReservations.ReadOnly = true;
            this.dgvListOfReservations.RowHeadersVisible = false;
            this.dgvListOfReservations.Size = new System.Drawing.Size(474, 298);
            this.dgvListOfReservations.TabIndex = 60;
            this.dgvListOfReservations.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListOfReservations.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListOfReservations.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListOfReservations.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListOfReservations.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListOfReservations.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvListOfReservations.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListOfReservations.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListOfReservations.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.dgvListOfReservations.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvListOfReservations.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListOfReservations.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListOfReservations.ThemeStyle.HeaderStyle.Height = 23;
            this.dgvListOfReservations.ThemeStyle.ReadOnly = true;
            this.dgvListOfReservations.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListOfReservations.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListOfReservations.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.dgvListOfReservations.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListOfReservations.ThemeStyle.RowsStyle.Height = 22;
            this.dgvListOfReservations.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListOfReservations.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(301, 9);
            this.lblMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(157, 25);
            this.lblMode.TabIndex = 61;
            this.lblMode.Text = "RESERATION";
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.FillColor = System.Drawing.Color.Black;
            this.guna2PictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox3.Image")));
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(717, 97);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(20, 30);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox3.TabIndex = 62;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.UseTransparentBackground = true;
            // 
            // frmScreenResseravionForMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(838, 548);
            this.Controls.Add(this.guna2PictureBox3);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.dgvListOfReservations);
            this.Controls.Add(this.btnAddResravtion);
            this.Controls.Add(this.txtSearchReservationID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmScreenResseravionForMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmScreenResseravionForMember";
            this.Load += new System.EventHandler(this.frmScreenResseravionForMember_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListOfReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtSearchReservationID;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnAddResravtion;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListOfReservations;
        private System.Windows.Forms.Label lblMode;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
    }
}