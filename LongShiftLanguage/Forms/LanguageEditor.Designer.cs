﻿namespace LongShiftLanguage.Forms
{
	partial class LanguageEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ToolButtonPanel = new System.Windows.Forms.Panel();
            this.btn_export_to_loc = new System.Windows.Forms.Button();
            this.btn_replace_all_languages = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_merge = new System.Windows.Forms.Button();
            this.btn_reload = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_importJSON = new System.Windows.Forms.Button();
            this.btn_copyJSON = new System.Windows.Forms.Button();
            this.btn_exportjson = new System.Windows.Forms.Button();
            this.pb_search = new System.Windows.Forms.PictureBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.dgv_keywords = new System.Windows.Forms.DataGridView();
            this.keyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.ToolButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_keywords)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(75)))));
            this.panel1.Controls.Add(this.ToolButtonPanel);
            this.panel1.Controls.Add(this.pb_search);
            this.panel1.Controls.Add(this.txt_search);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 32);
            this.panel1.TabIndex = 0;
            // 
            // ToolButtonPanel
            // 
            this.ToolButtonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolButtonPanel.Controls.Add(this.btn_export_to_loc);
            this.ToolButtonPanel.Controls.Add(this.btn_replace_all_languages);
            this.ToolButtonPanel.Controls.Add(this.btn_add);
            this.ToolButtonPanel.Controls.Add(this.btn_delete);
            this.ToolButtonPanel.Controls.Add(this.btn_merge);
            this.ToolButtonPanel.Controls.Add(this.btn_reload);
            this.ToolButtonPanel.Controls.Add(this.btn_save);
            this.ToolButtonPanel.Controls.Add(this.btn_importJSON);
            this.ToolButtonPanel.Controls.Add(this.btn_copyJSON);
            this.ToolButtonPanel.Controls.Add(this.btn_exportjson);
            this.ToolButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolButtonPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ToolButtonPanel.Name = "ToolButtonPanel";
            this.ToolButtonPanel.Size = new System.Drawing.Size(606, 32);
            this.ToolButtonPanel.TabIndex = 2;
            // 
            // btn_export_to_loc
            // 
            this.btn_export_to_loc.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_upload_48;
            this.btn_export_to_loc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_export_to_loc.FlatAppearance.BorderSize = 0;
            this.btn_export_to_loc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export_to_loc.Location = new System.Drawing.Point(220, 3);
            this.btn_export_to_loc.Name = "btn_export_to_loc";
            this.btn_export_to_loc.Size = new System.Drawing.Size(24, 24);
            this.btn_export_to_loc.TabIndex = 14;
            this.MainTooltip.SetToolTip(this.btn_export_to_loc, "Drop it in the designated output location");
            this.btn_export_to_loc.UseVisualStyleBackColor = true;
            this.btn_export_to_loc.Click += new System.EventHandler(this.btn_export_to_loc_Click);
            // 
            // btn_replace_all_languages
            // 
            this.btn_replace_all_languages.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_replace_all_languages.BackgroundImage")));
            this.btn_replace_all_languages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_replace_all_languages.FlatAppearance.BorderSize = 0;
            this.btn_replace_all_languages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_replace_all_languages.Location = new System.Drawing.Point(250, 3);
            this.btn_replace_all_languages.Name = "btn_replace_all_languages";
            this.btn_replace_all_languages.Size = new System.Drawing.Size(24, 24);
            this.btn_replace_all_languages.TabIndex = 18;
            this.MainTooltip.SetToolTip(this.btn_replace_all_languages, "Tüm dillerde değiştir");
            this.btn_replace_all_languages.UseVisualStyleBackColor = true;
            this.btn_replace_all_languages.Click += new System.EventHandler(this.btn_replace_all_languages_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_plus_48;
            this.btn_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add.FlatAppearance.BorderSize = 0;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Location = new System.Drawing.Point(10, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(24, 24);
            this.btn_add.TabIndex = 7;
            this.MainTooltip.SetToolTip(this.btn_add, "Yeni Satır");
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_trash_48;
            this.btn_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_delete.FlatAppearance.BorderSize = 0;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Location = new System.Drawing.Point(40, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(24, 24);
            this.btn_delete.TabIndex = 8;
            this.MainTooltip.SetToolTip(this.btn_delete, "Seçili Satır(ları) sil");
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_merge
            // 
            this.btn_merge.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_data_transfer_48;
            this.btn_merge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_merge.FlatAppearance.BorderSize = 0;
            this.btn_merge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_merge.Location = new System.Drawing.Point(280, 3);
            this.btn_merge.Name = "btn_merge";
            this.btn_merge.Size = new System.Drawing.Size(24, 24);
            this.btn_merge.TabIndex = 16;
            this.MainTooltip.SetToolTip(this.btn_merge, "Dosyadan gelen verileri güncelle");
            this.btn_merge.UseVisualStyleBackColor = true;
            this.btn_merge.Click += new System.EventHandler(this.btn_merge_Click);
            // 
            // btn_reload
            // 
            this.btn_reload.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_synchronize_48;
            this.btn_reload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reload.FlatAppearance.BorderSize = 0;
            this.btn_reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reload.Location = new System.Drawing.Point(70, 3);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(24, 24);
            this.btn_reload.TabIndex = 9;
            this.MainTooltip.SetToolTip(this.btn_reload, "Verileri Yenile");
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click_1);
            // 
            // btn_save
            // 
            this.btn_save.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_save_48;
            this.btn_save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Location = new System.Drawing.Point(100, 3);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(24, 24);
            this.btn_save.TabIndex = 10;
            this.MainTooltip.SetToolTip(this.btn_save, "Sunucuya Kaydet");
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_importJSON
            // 
            this.btn_importJSON.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_download_48;
            this.btn_importJSON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_importJSON.FlatAppearance.BorderSize = 0;
            this.btn_importJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_importJSON.Location = new System.Drawing.Point(190, 3);
            this.btn_importJSON.Name = "btn_importJSON";
            this.btn_importJSON.Size = new System.Drawing.Size(24, 24);
            this.btn_importJSON.TabIndex = 11;
            this.MainTooltip.SetToolTip(this.btn_importJSON, "Tüm verileri sil ve dosyadan yükle");
            this.btn_importJSON.UseVisualStyleBackColor = true;
            this.btn_importJSON.Click += new System.EventHandler(this.btn_importJSON_Click);
            // 
            // btn_copyJSON
            // 
            this.btn_copyJSON.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_copy_48;
            this.btn_copyJSON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_copyJSON.FlatAppearance.BorderSize = 0;
            this.btn_copyJSON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_copyJSON.Location = new System.Drawing.Point(160, 3);
            this.btn_copyJSON.Name = "btn_copyJSON";
            this.btn_copyJSON.Size = new System.Drawing.Size(24, 24);
            this.btn_copyJSON.TabIndex = 13;
            this.MainTooltip.SetToolTip(this.btn_copyJSON, "JSON metini olarak kopyala");
            this.btn_copyJSON.UseVisualStyleBackColor = true;
            this.btn_copyJSON.Click += new System.EventHandler(this.btn_copyJSON_Click_1);
            // 
            // btn_exportjson
            // 
            this.btn_exportjson.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_exportjson.BackgroundImage")));
            this.btn_exportjson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_exportjson.FlatAppearance.BorderSize = 0;
            this.btn_exportjson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exportjson.Location = new System.Drawing.Point(130, 3);
            this.btn_exportjson.Name = "btn_exportjson";
            this.btn_exportjson.Size = new System.Drawing.Size(24, 24);
            this.btn_exportjson.TabIndex = 12;
            this.MainTooltip.SetToolTip(this.btn_exportjson, "Dışa Aktar");
            this.btn_exportjson.UseVisualStyleBackColor = true;
            this.btn_exportjson.Click += new System.EventHandler(this.btn_exportjson_Click);
            // 
            // pb_search
            // 
            this.pb_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_search.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_search_48;
            this.pb_search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_search.Location = new System.Drawing.Point(611, 4);
            this.pb_search.Name = "pb_search";
            this.pb_search.Size = new System.Drawing.Size(24, 24);
            this.pb_search.TabIndex = 17;
            this.pb_search.TabStop = false;
            this.MainTooltip.SetToolTip(this.pb_search, "Ara");
            this.pb_search.Click += new System.EventHandler(this.pb_search_Click);
            // 
            // txt_search
            // 
            this.txt_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_search.ForeColor = System.Drawing.Color.White;
            this.txt_search.Location = new System.Drawing.Point(641, 6);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(147, 20);
            this.txt_search.TabIndex = 15;
            this.MainTooltip.SetToolTip(this.txt_search, "Ara");
            this.txt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_search_KeyDown);
            // 
            // dgv_keywords
            // 
            this.dgv_keywords.AllowUserToAddRows = false;
            this.dgv_keywords.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(103)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            this.dgv_keywords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_keywords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_keywords.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.dgv_keywords.ColumnHeadersHeight = 24;
            this.dgv_keywords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyid,
            this.keyname,
            this.keyvalue});
            this.dgv_keywords.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_keywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_keywords.Location = new System.Drawing.Point(0, 32);
            this.dgv_keywords.Name = "dgv_keywords";
            this.dgv_keywords.RowHeadersWidth = 48;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            this.dgv_keywords.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_keywords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_keywords.Size = new System.Drawing.Size(800, 418);
            this.dgv_keywords.TabIndex = 1;
            this.dgv_keywords.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_keywords_CellEndEdit);
            this.dgv_keywords.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_keywords_CellMouseDown);
            this.dgv_keywords.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_keywords_RowsAdded);
            // 
            // keyid
            // 
            this.keyid.HeaderText = "id";
            this.keyid.MinimumWidth = 6;
            this.keyid.Name = "keyid";
            this.keyid.Visible = false;
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyNameToolStripMenuItem,
            this.copyValueToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteEntryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 76);
            // 
            // copyNameToolStripMenuItem
            // 
            this.copyNameToolStripMenuItem.Name = "copyNameToolStripMenuItem";
            this.copyNameToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.copyNameToolStripMenuItem.Text = "Copy Name";
            this.copyNameToolStripMenuItem.Click += new System.EventHandler(this.copyNameToolStripMenuItem_Click);
            // 
            // copyValueToolStripMenuItem
            // 
            this.copyValueToolStripMenuItem.Name = "copyValueToolStripMenuItem";
            this.copyValueToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.copyValueToolStripMenuItem.Text = "Copy Value";
            this.copyValueToolStripMenuItem.Click += new System.EventHandler(this.copyValueToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // deleteEntryToolStripMenuItem
            // 
            this.deleteEntryToolStripMenuItem.Name = "deleteEntryToolStripMenuItem";
            this.deleteEntryToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteEntryToolStripMenuItem.Text = "Delete Selected Entry";
            this.deleteEntryToolStripMenuItem.Click += new System.EventHandler(this.deleteEntryToolStripMenuItem_Click);
            // 
            // MainTooltip
            // 
            this.MainTooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(95)))));
            this.MainTooltip.ForeColor = System.Drawing.Color.White;
            // 
            // LanguageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_keywords);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LanguageEditor";
            this.Text = "LanguageEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LanguageEditor_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ToolButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_keywords)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DataGridViewTextBoxColumn key_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn key_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn key_value;
		private System.Windows.Forms.DataGridViewTextBoxColumn keyid;
		private System.Windows.Forms.DataGridViewTextBoxColumn keyname;
		private System.Windows.Forms.DataGridViewTextBoxColumn keyvalue;
		private System.Windows.Forms.Button btn_copyJSON;
		private System.Windows.Forms.Button btn_exportjson;
		private System.Windows.Forms.Button btn_importJSON;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_reload;
		private System.Windows.Forms.Button btn_delete;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.Button btn_export_to_loc;
		private System.Windows.Forms.TextBox txt_search;
		private System.Windows.Forms.Button btn_merge;
		private System.Windows.Forms.PictureBox pb_search;
		private System.Windows.Forms.ToolTip MainTooltip;
		private System.Windows.Forms.Button btn_replace_all_languages;
		public System.Windows.Forms.DataGridView dgv_keywords;
        private System.Windows.Forms.Panel ToolButtonPanel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteEntryToolStripMenuItem;
    }
}