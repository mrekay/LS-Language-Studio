namespace LongShiftLanguage.Forms
{
    partial class SettingsForm
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
            this.lbl_app_prf_lng = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_app_prf_lng
            // 
            this.lbl_app_prf_lng.AutoSize = true;
            this.lbl_app_prf_lng.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_app_prf_lng.ForeColor = System.Drawing.Color.White;
            this.lbl_app_prf_lng.Location = new System.Drawing.Point(12, 57);
            this.lbl_app_prf_lng.Name = "lbl_app_prf_lng";
            this.lbl_app_prf_lng.Size = new System.Drawing.Size(205, 17);
            this.lbl_app_prf_lng.TabIndex = 1;
            this.lbl_app_prf_lng.Text = "Application Prefered Language : ";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Deutsch",
            "English",
            "Español",
            "Français",
            "Italiano",
            "Русский",
            "Türkçe"});
            this.comboBox1.Location = new System.Drawing.Point(15, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(403, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Tag = "";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(75)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(326, 114);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(93, 27);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Apply";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(430, 149);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbl_app_prf_lng);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_app_prf_lng;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_save;
    }
}