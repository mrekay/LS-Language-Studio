namespace LongShiftLanguage.Forms
{
	partial class ReplaceInAllLanguages
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.dgv_keywords = new System.Windows.Forms.DataGridView();
            this.keyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ole_row_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.th_language = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_keywords)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 317);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 49);
            this.panel1.TabIndex = 1;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(75)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(498, 12);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(93, 27);
            this.btn_save.TabIndex = 0;
            this.btn_save.Text = "Değiştir";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // dgv_keywords
            // 
            this.dgv_keywords.AllowUserToAddRows = false;
            this.dgv_keywords.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(103)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            this.dgv_keywords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_keywords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_keywords.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.dgv_keywords.ColumnHeadersHeight = 24;
            this.dgv_keywords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyid,
            this.ole_row_id,
            this.th_language,
            this.keyname,
            this.keyvalue});
            this.dgv_keywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_keywords.Location = new System.Drawing.Point(0, 48);
            this.dgv_keywords.Name = "dgv_keywords";
            this.dgv_keywords.RowHeadersWidth = 48;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            this.dgv_keywords.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_keywords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_keywords.Size = new System.Drawing.Size(600, 269);
            this.dgv_keywords.TabIndex = 20;
            // 
            // keyid
            // 
            this.keyid.HeaderText = "id";
            this.keyid.MinimumWidth = 6;
            this.keyid.Name = "keyid";
            this.keyid.Visible = false;
            // 
            // ole_row_id
            // 
            this.ole_row_id.HeaderText = "row_id";
            this.ole_row_id.MinimumWidth = 6;
            this.ole_row_id.Name = "ole_row_id";
            this.ole_row_id.Visible = false;
            // 
            // th_language
            // 
            this.th_language.HeaderText = "Language";
            this.th_language.MinimumWidth = 6;
            this.th_language.Name = "th_language";
            this.th_language.ReadOnly = true;
            // 
            // keyname
            // 
            this.keyname.HeaderText = "Name";
            this.keyname.MinimumWidth = 6;
            this.keyname.Name = "keyname";
            // 
            // keyvalue
            // 
            this.keyvalue.HeaderText = "Value";
            this.keyvalue.MinimumWidth = 6;
            this.keyvalue.Name = "keyvalue";
            // 
            // ReplaceInAllLanguages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.ControlBox = false;
            this.Controls.Add(this.dgv_keywords);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReplaceInAllLanguages";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_keywords)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridView dgv_keywords;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.DataGridViewTextBoxColumn keyid;
		private System.Windows.Forms.DataGridViewTextBoxColumn ole_row_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn th_language;
		private System.Windows.Forms.DataGridViewTextBoxColumn keyname;
		private System.Windows.Forms.DataGridViewTextBoxColumn keyvalue;
	}
}