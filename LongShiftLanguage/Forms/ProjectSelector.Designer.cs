using LongShiftLanguage.libs.multilanguage_support;

namespace LongShiftLanguage.Forms
{
	partial class ProjectSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectSelector));
            this.label1 = new System.Windows.Forms.Label();
            this.panel_projects = new System.Windows.Forms.Panel();
            this.btn_add_lang = new System.Windows.Forms.Button();
            this.btn_delete_lang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Select Project";
            // 
            // panel_projects
            // 
            this.panel_projects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_projects.AutoScroll = true;
            this.panel_projects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(75)))));
            this.panel_projects.Location = new System.Drawing.Point(14, 87);
            this.panel_projects.Name = "panel_projects";
            this.panel_projects.Size = new System.Drawing.Size(440, 367);
            this.panel_projects.TabIndex = 1;
            // 
            // btn_add_lang
            // 
            this.btn_add_lang.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_plus_48;
            this.btn_add_lang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add_lang.FlatAppearance.BorderSize = 0;
            this.btn_add_lang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_lang.Location = new System.Drawing.Point(388, 52);
            this.btn_add_lang.Name = "btn_add_lang";
            this.btn_add_lang.Size = new System.Drawing.Size(28, 28);
            this.btn_add_lang.TabIndex = 3;
            this.btn_add_lang.UseVisualStyleBackColor = true;
            this.btn_add_lang.Click += new System.EventHandler(this.crate_btn_Click);
            // 
            // btn_delete_lang
            // 
            this.btn_delete_lang.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_trash_48;
            this.btn_delete_lang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delete_lang.FlatAppearance.BorderSize = 0;
            this.btn_delete_lang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete_lang.Location = new System.Drawing.Point(426, 52);
            this.btn_delete_lang.Name = "btn_delete_lang";
            this.btn_delete_lang.Size = new System.Drawing.Size(28, 28);
            this.btn_delete_lang.TabIndex = 4;
            this.btn_delete_lang.UseVisualStyleBackColor = true;
            this.btn_delete_lang.Click += new System.EventHandler(this.btn_delete_lang_Click);
            // 
            // ProjectSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(467, 465);
            this.ControlBox = false;
            this.Controls.Add(this.btn_delete_lang);
            this.Controls.Add(this.btn_add_lang);
            this.Controls.Add(this.panel_projects);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(467, 465);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(467, 465);
            this.Name = "ProjectSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProjectSelector_FormClosed);
            this.Load += new System.EventHandler(this.ProjectSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel_projects;
        private System.Windows.Forms.Button btn_add_lang;
        private System.Windows.Forms.Button btn_delete_lang;
    }
}