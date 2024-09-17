namespace LongShiftLanguage.Forms
{
	partial class AddProject
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
            this.tb_proj_name = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_project_name = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pb_project_image = new System.Windows.Forms.PictureBox();
            this.btn_loadimage = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_project_photo = new System.Windows.Forms.Label();
            this.btn_continue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_project_image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.tb_proj_name);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txt_project_name);
            this.panel1.Location = new System.Drawing.Point(77, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 100);
            this.panel1.TabIndex = 17;
            // 
            // tb_proj_name
            // 
            this.tb_proj_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(95)))));
            this.tb_proj_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_proj_name.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tb_proj_name.ForeColor = System.Drawing.Color.White;
            this.tb_proj_name.Location = new System.Drawing.Point(19, 52);
            this.tb_proj_name.Multiline = true;
            this.tb_proj_name.Name = "tb_proj_name";
            this.tb_proj_name.Size = new System.Drawing.Size(438, 20);
            this.tb_proj_name.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Orange;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(467, 3);
            this.panel2.TabIndex = 1;
            // 
            // txt_project_name
            // 
            this.txt_project_name.AutoSize = true;
            this.txt_project_name.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_project_name.ForeColor = System.Drawing.Color.White;
            this.txt_project_name.Location = new System.Drawing.Point(15, 17);
            this.txt_project_name.Name = "txt_project_name";
            this.txt_project_name.Size = new System.Drawing.Size(81, 20);
            this.txt_project_name.TabIndex = 0;
            this.txt_project_name.Text = "Proje Adı : ";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(75)))));
            this.panel3.Controls.Add(this.pb_project_image);
            this.panel3.Controls.Add(this.btn_loadimage);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.txt_project_photo);
            this.panel3.Location = new System.Drawing.Point(77, 214);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(467, 230);
            this.panel3.TabIndex = 18;
            // 
            // pb_project_image
            // 
            this.pb_project_image.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_camera_48;
            this.pb_project_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb_project_image.Location = new System.Drawing.Point(33, 53);
            this.pb_project_image.Name = "pb_project_image";
            this.pb_project_image.Size = new System.Drawing.Size(400, 160);
            this.pb_project_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_project_image.TabIndex = 20;
            this.pb_project_image.TabStop = false;
            // 
            // btn_loadimage
            // 
            this.btn_loadimage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_loadimage.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_add_file_48;
            this.btn_loadimage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_loadimage.FlatAppearance.BorderSize = 0;
            this.btn_loadimage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_loadimage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_loadimage.ForeColor = System.Drawing.Color.White;
            this.btn_loadimage.Location = new System.Drawing.Point(125, 13);
            this.btn_loadimage.Name = "btn_loadimage";
            this.btn_loadimage.Size = new System.Drawing.Size(24, 24);
            this.btn_loadimage.TabIndex = 19;
            this.btn_loadimage.UseVisualStyleBackColor = true;
            this.btn_loadimage.Click += new System.EventHandler(this.btn_loadimage_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Orange;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(467, 3);
            this.panel4.TabIndex = 1;
            // 
            // txt_project_photo
            // 
            this.txt_project_photo.AutoSize = true;
            this.txt_project_photo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_project_photo.ForeColor = System.Drawing.Color.White;
            this.txt_project_photo.Location = new System.Drawing.Point(15, 17);
            this.txt_project_photo.Name = "txt_project_photo";
            this.txt_project_photo.Size = new System.Drawing.Size(104, 20);
            this.txt_project_photo.TabIndex = 0;
            this.txt_project_photo.Text = "Proje Görseli : ";
            // 
            // btn_continue
            // 
            this.btn_continue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_continue.FlatAppearance.BorderSize = 0;
            this.btn_continue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_continue.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_continue.ForeColor = System.Drawing.Color.White;
            this.btn_continue.Location = new System.Drawing.Point(507, 491);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(100, 32);
            this.btn_continue.TabIndex = 19;
            this.btn_continue.Text = "Devam Et";
            this.btn_continue.UseVisualStyleBackColor = true;
            this.btn_continue.Click += new System.EventHandler(this.btn_continue_Click);
            // 
            // AddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(620, 532);
            this.ControlBox = false;
            this.Controls.Add(this.btn_continue);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(620, 532);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(620, 532);
            this.Name = "AddProject";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_project_image)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label txt_project_name;
		private System.Windows.Forms.TextBox tb_proj_name;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.PictureBox pb_project_image;
		private System.Windows.Forms.Button btn_loadimage;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label txt_project_photo;
		private System.Windows.Forms.Button btn_continue;
	}
}