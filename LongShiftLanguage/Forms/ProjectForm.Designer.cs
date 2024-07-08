namespace LongShiftLanguage.Forms
{
	partial class ProjectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
            this.LanguageTabControl = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.yeniDilOluşturToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seçiliDiliSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.başkaProjeAçToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projeyiYenidenYükleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projeyiKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.çıktıKonumunuBelirleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.last_process_label = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LanguageTabControl
            // 
            this.LanguageTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageTabControl.Location = new System.Drawing.Point(0, 51);
            this.LanguageTabControl.Name = "LanguageTabControl";
            this.LanguageTabControl.Padding = new System.Drawing.Point(12, 3);
            this.LanguageTabControl.SelectedIndex = 0;
            this.LanguageTabControl.Size = new System.Drawing.Size(954, 530);
            this.LanguageTabControl.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniDilOluşturToolStripMenuItem,
            this.seçiliDiliSilToolStripMenuItem,
            this.toolStripSeparator1,
            this.başkaProjeAçToolStripMenuItem,
            this.projeyiYenidenYükleToolStripMenuItem,
            this.projeyiKaydetToolStripMenuItem,
            this.toolStripSeparator2,
            this.çıktıKonumunuBelirleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(271, 148);
            // 
            // yeniDilOluşturToolStripMenuItem
            // 
            this.yeniDilOluşturToolStripMenuItem.Name = "yeniDilOluşturToolStripMenuItem";
            this.yeniDilOluşturToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.yeniDilOluşturToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.yeniDilOluşturToolStripMenuItem.Text = "Yeni Dil Oluştur";
            this.yeniDilOluşturToolStripMenuItem.Click += new System.EventHandler(this.yeniDilOluşturToolStripMenuItem_Click);
            // 
            // seçiliDiliSilToolStripMenuItem
            // 
            this.seçiliDiliSilToolStripMenuItem.Name = "seçiliDiliSilToolStripMenuItem";
            this.seçiliDiliSilToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Delete)));
            this.seçiliDiliSilToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.seçiliDiliSilToolStripMenuItem.Text = "Seçili Dili Sil";
            this.seçiliDiliSilToolStripMenuItem.Click += new System.EventHandler(this.seçiliDiliSilToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // başkaProjeAçToolStripMenuItem
            // 
            this.başkaProjeAçToolStripMenuItem.Name = "başkaProjeAçToolStripMenuItem";
            this.başkaProjeAçToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.başkaProjeAçToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.başkaProjeAçToolStripMenuItem.Text = "Başka Proje Aç";
            this.başkaProjeAçToolStripMenuItem.Click += new System.EventHandler(this.başkaProjeAçToolStripMenuItem_Click);
            // 
            // projeyiYenidenYükleToolStripMenuItem
            // 
            this.projeyiYenidenYükleToolStripMenuItem.Name = "projeyiYenidenYükleToolStripMenuItem";
            this.projeyiYenidenYükleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.projeyiYenidenYükleToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.projeyiYenidenYükleToolStripMenuItem.Text = "Projeyi Yeniden Yükle";
            this.projeyiYenidenYükleToolStripMenuItem.Click += new System.EventHandler(this.projeyiYenidenYükleToolStripMenuItem_Click);
            // 
            // projeyiKaydetToolStripMenuItem
            // 
            this.projeyiKaydetToolStripMenuItem.Name = "projeyiKaydetToolStripMenuItem";
            this.projeyiKaydetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.projeyiKaydetToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.projeyiKaydetToolStripMenuItem.Text = "Projeyi Kaydet";
            this.projeyiKaydetToolStripMenuItem.Click += new System.EventHandler(this.projeyiKaydetToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(267, 6);
            // 
            // çıktıKonumunuBelirleToolStripMenuItem
            // 
            this.çıktıKonumunuBelirleToolStripMenuItem.Name = "çıktıKonumunuBelirleToolStripMenuItem";
            this.çıktıKonumunuBelirleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.çıktıKonumunuBelirleToolStripMenuItem.Size = new System.Drawing.Size(270, 22);
            this.çıktıKonumunuBelirleToolStripMenuItem.Text = "Çıktı Konumunu Belirle";
            this.çıktıKonumunuBelirleToolStripMenuItem.Click += new System.EventHandler(this.çıktıKonumunuBelirleToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.last_process_label});
            this.toolStrip1.Location = new System.Drawing.Point(0, 581);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(954, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // last_process_label
            // 
            this.last_process_label.Name = "last_process_label";
            this.last_process_label.Size = new System.Drawing.Size(83, 22);
            this.last_process_label.Text = "Proje Yüklendi";
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(954, 606);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.LanguageTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ProjectForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectForm_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		public System.Windows.Forms.TabControl LanguageTabControl;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem yeniDilOluşturToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem seçiliDiliSilToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem çıktıKonumunuBelirleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem başkaProjeAçToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem projeyiYenidenYükleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem projeyiKaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel last_process_label;
    }
}