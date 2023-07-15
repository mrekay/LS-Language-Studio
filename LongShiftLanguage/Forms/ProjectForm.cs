using LongShiftLanguage.Classes;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static config_definitions;
using static function_special;
using System.Diagnostics;
using LongShiftLanguage.Classes.Abstract;

namespace LongShiftLanguage.Forms
{
	public partial class ProjectForm : LSForm
	{

		private DatabaseConnection database;
		private Classes.Project SelectedProject;
		private LanguageEditor StandardTabPage;

		bool exit;
		public ProjectForm()
		{

			//database = new Database();
			database = function_special.CreateDBConnection();
			var versionChecker = new VersionChecker(database);
			if (!versionChecker.CheckVersion())
			{
				var dialogResult = MessageBox.Show(string.Format("Yeni Sürüm Yayınlamış ({0}) Devam etmek için indiriniz.", versionChecker.version), "Yeni Sürüm Yayınlamış", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (dialogResult == DialogResult.Yes)
				{
					Process.Start(versionChecker.url);
				}

				Application.Exit();
				exit = true;


			}

			InitializeComponent();
			(new SplashScreen()).ShowDialog();


			if (SelectedProject == null)
			{
				ProjectSelector projectProjectSelector = new ProjectSelector(database);

				projectProjectSelector.FormClosing += SelectAproject;
				projectProjectSelector.ShowDialog();
			}

			if (SelectedProject == null)
			{
				this.Close();
				Application.Exit();
				return;
			}


			CreateTabs();
			Shown += FormReady;

		}

		private void FormReady(object sender, EventArgs e)
		{
			CreateMenuButton();
		}

		void CreateMenuButton()
		{
			// 
			// btn_output_loc
			// 
			var btn_output_loc = new Button();
			btn_output_loc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			btn_output_loc.BackgroundImage = global::LongShiftLanguage.Properties.Resources.option;
			btn_output_loc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btn_output_loc.FlatAppearance.BorderSize = 0;
			btn_output_loc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btn_output_loc.Name = "btn_output_loc";
			btn_output_loc.Size = new System.Drawing.Size(35, 32);
			btn_output_loc.Click += new System.EventHandler(this.btn_output_loc_Click);
			ControlsBox.AddCustomControl(btn_output_loc);
		}

		private void CreateTabs()
		{
			foreach (var item in SelectedProject.languageManager.languageList)
			{
				var leditor = new LanguageEditor(database, SelectedProject, this, item);
				var ltab = new TabPage(item.name + (item.isDefault == "1" ? " - Varsayılan" : ""));
				leditor.TopLevel = false;
				leditor.Dock = DockStyle.Fill;
				leditor.Show();
				ltab.Controls.Add(leditor);
				LanguageTabControl.TabPages.Add(ltab);
				if (item.isDefault == "1") StandardTabPage = leditor;
			}
		}

		private void SelectAproject(object sender, FormClosingEventArgs e)
		{
			SelectedProject = (sender as ProjectSelector).GetSelectedProject();
		}

		public LanguageEditor GetStandardTab()
		{
			return StandardTabPage;
		}

		internal void SaveAllProject()
		{
			foreach (TabPage tab in LanguageTabControl.TabPages)
			{
				var languageEditor = tab.Controls[0] as LanguageEditor;
				languageEditor.saveAlone();
			}
		}

		private void btn_output_loc_Click(object sender, EventArgs e)
		{
			var senderobj = ((Button)sender);
			var location = senderobj.PointToScreen(Point.Empty);
			contextMenuStrip1.Show(location.X, location.Y+ senderobj.Height);
		}

		private void yeniDilOluşturToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//CreateForm();
			AddLanguage addLanguage = new AddLanguage(database, SelectedProject);
			addLanguage.ShowDialog();
			SelectedProject.languageManager.LanguagesSelect();
			ReloadTabs();


		}

		private void çıktıKonumunuBelirleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// FolderBrowserDialog örneği oluşturuluyor
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

			// İsteğe bağlı olarak başlangıç dizinini belirleyebilirsiniz
			folderBrowserDialog.SelectedPath = @"";

			// Kullanıcıya bir klasör seçme penceresi gösterilir
			DialogResult result = folderBrowserDialog.ShowDialog();

			// Kullanıcı bir klasör seçtiyse ve Tamam düğmesine bastıysa
			if (result == DialogResult.OK)
			{
				// Seçilen klasörün yolu alınır
				string selectedFolder = folderBrowserDialog.SelectedPath;

				if (string.IsNullOrEmpty(selectedFolder)) { MessageBox.Show("Kayıt noktası boş olamaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
				Properties.Settings.Default.unity_output_location = selectedFolder;
				Properties.Settings.Default.Save();
				MessageBox.Show("Veri kayıt noktası kaydedildi!");
			}
		}

		private void seçiliDiliSilToolStripMenuItem_Click(object sender, EventArgs e)
		{

			if (MessageBox.Show("Seçili dil silinecektir.", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{

				var selectedLanguageEditor = LanguageTabControl.SelectedTab.Controls[0] as LanguageEditor;
				if (selectedLanguageEditor != null)
				{
					selectedLanguageEditor.DeleteLanguage();
					SelectedProject.languageManager.LanguagesSelect();

					ReloadTabs();


				}
			}
		}

		internal void ReloadAll()
		{
			foreach (TabPage tab in LanguageTabControl.TabPages)
			{
				var languageEditor = tab.Controls[0] as LanguageEditor;
				languageEditor.reloadAlone();
			}
		}

		void ReloadTabs()
		{
			foreach (var item in SelectedProject.languageManager.languageList)
			{
				bool hasTab = false;
				foreach (TabPage tab in LanguageTabControl.TabPages)
				{
					string tab_text = tab.Text;
					if (tab.Text.Contains('-')) tab_text = tab_text.Split('-')[0].Trim();
					if (item.name == tab_text) { hasTab = true; break; }
				}

				if (!hasTab)
				{
					var leditor = new LanguageEditor(database, SelectedProject, this, item);
					var ltab = new TabPage(item.name + (item.isDefault == "1" ? " - Varsayılan" : ""));
					leditor.TopLevel = false;
					leditor.Dock = DockStyle.Fill;
					leditor.Show();
					ltab.Controls.Add(leditor);
					LanguageTabControl.TabPages.Add(ltab);
					if (item.isDefault == "1") StandardTabPage = leditor;
				}
			}

			foreach (TabPage tab in LanguageTabControl.TabPages)
			{
				bool haslang = false;

				foreach (var item in SelectedProject.languageManager.languageList)
				{
					string tab_text = tab.Text;
					if (tab.Text.Contains('-')) tab_text = tab_text.Split('-')[0].Trim();
					if (item.name == tab_text) { haslang = true; break; }
				}

				if (!haslang)
				{
					(tab.Controls[0] as Form).Close();
				}
			}
		}

		private void başkaProjeAçToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Başka Proje Açmak İstediğinize Emin Misiniz?\nKaydetmediğiniz Değişiklikler Silinecektir\nSilinen değişiklikler geri alınmaz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Application.Restart();
			}
		}

		private void projeyiYenidenYükleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Projeyi Yeniden Yüklemek İstediğinize Emin Misiniz?\nKaydetmediğiniz Değişiklikler Silinecektir\nSilinen değişiklikler geri alınmaz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{

				ReloadAll();
			}
		}

		private void projeyiKaydetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveAllProject();
		}

		private void ProjectForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.Shift)
				switch (e.KeyCode)
				{
					case Keys.N:
						yeniDilOluşturToolStripMenuItem.PerformClick();
						break;
					case Keys.Delete:
						seçiliDiliSilToolStripMenuItem.PerformClick();
						break;
					case Keys.O:
						başkaProjeAçToolStripMenuItem.PerformClick();
						break;
					case Keys.R:
						projeyiYenidenYükleToolStripMenuItem.PerformClick();
						break;
					case Keys.S:
						projeyiKaydetToolStripMenuItem.PerformClick();
						break;
					case Keys.U:
						çıktıKonumunuBelirleToolStripMenuItem.PerformClick();
						break;
				}
		}

	}
}
