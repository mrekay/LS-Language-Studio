namespace LongShiftLanguage.Forms
{
	partial class AddLanguage
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tb_proj_name = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_continue = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(75)))));
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Controls.Add(this.tb_proj_name);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Location = new System.Drawing.Point(80, 142);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(467, 100);
			this.panel1.TabIndex = 17;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.checkBox1.ForeColor = System.Drawing.Color.White;
			this.checkBox1.Location = new System.Drawing.Point(19, 69);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(106, 21);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Varsayılan Dil";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// tb_proj_name
			// 
			this.tb_proj_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(95)))));
			this.tb_proj_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tb_proj_name.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.tb_proj_name.ForeColor = System.Drawing.Color.White;
			this.tb_proj_name.Location = new System.Drawing.Point(16, 42);
			this.tb_proj_name.Multiline = true;
			this.tb_proj_name.Name = "tb_proj_name";
			this.tb_proj_name.Size = new System.Drawing.Size(438, 20);
			this.tb_proj_name.TabIndex = 2;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(467, 3);
			this.panel2.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(15, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 20);
			this.label2.TabIndex = 0;
			this.label2.Text = "Dil :";
			// 
			// btn_continue
			// 
			this.btn_continue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_continue.FlatAppearance.BorderSize = 0;
			this.btn_continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_continue.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.btn_continue.ForeColor = System.Drawing.Color.White;
			this.btn_continue.Location = new System.Drawing.Point(515, 339);
			this.btn_continue.Name = "btn_continue";
			this.btn_continue.Size = new System.Drawing.Size(100, 32);
			this.btn_continue.TabIndex = 19;
			this.btn_continue.Text = "Devam Et";
			this.btn_continue.UseVisualStyleBackColor = true;
			this.btn_continue.Click += new System.EventHandler(this.btn_continue_Click);
			// 
			// AddLanguage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
			this.ClientSize = new System.Drawing.Size(631, 387);
			this.ControlBox = false;
			this.Controls.Add(this.btn_continue);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(631, 284);
			this.Name = "AddLanguage";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tb_proj_name;
		private System.Windows.Forms.Button btn_continue;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}