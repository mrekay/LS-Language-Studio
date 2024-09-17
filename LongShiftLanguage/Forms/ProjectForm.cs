using LongShiftLanguage.Classes;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static config_definitions;
using static function_special;
using System.Diagnostics;
using System.Management.Instrumentation;
using LongShiftLanguage.libs.multilanguage_support;

namespace LongShiftLanguage.Forms
{
    public partial class ProjectForm : LSForm
    {

        internal static ProjectForm instance;

        public ProjectManager projectManager;
        private Classes.Project SelectedProject;
        private LanguageEditor StandardTabPage;

        bool exit;

        public static Project GetProject() => instance.SelectedProject;
        public static LanguageEditor SelectedEditorTab() => (LanguageEditor)instance.LanguageTabControl.SelectedTab.Controls[0];
        public static Language SelectedLanguage() => SelectedEditorTab().GetEditorLanguage();

        public ProjectForm()
        {
            instance = this;
            projectManager =  ProjectManager.Load();
            if (projectManager == null || projectManager.projectList == null)
            {
                projectManager = new ProjectManager();
                projectManager.projectList = new System.Collections.Generic.List<Project>();
                projectManager.Save();
            }
           
            InitializeComponent();
            LoadLanguageTexts();
            (new SplashScreen()).ShowDialog();
            resetLPLabel.Tick += ResetLPLabel_Tick;


            if (SelectedProject == null)
            {
                ProjectSelector projectProjectSelector = new ProjectSelector(projectManager);

                projectProjectSelector.FormClosing += SelectAproject;
                projectProjectSelector.ShowDialog();
            }

            if (SelectedProject == null)
            {
                this.Close();
                Application.Exit();
                return;
            }

            /* initalize Extention resources*/
            InitializeExtentionResources();

            this.KeyPreview = true;
            CreateTabs();
            Shown += FormReady;

        }

        private void LoadLanguageTexts()
        {
            yeniDilOluşturToolStripMenuItem.Text = LangCtrl.GetText("CREATE_NEW_LANGUAGE");
            başkaProjeAçToolStripMenuItem.Text = LangCtrl.GetText("OPEN_OTHER_PROJECT");
            projeyiYenidenYükleToolStripMenuItem.Text = LangCtrl.GetText("RELOAD_PROJECT");
            projeyiKaydetToolStripMenuItem.Text = LangCtrl.GetText("SAVE_PROJECT");
            seçiliDiliSilToolStripMenuItem.Text = LangCtrl.GetText("DELETE_SELECTED_LANGUAGE");
            çıktıKonumunuBelirleToolStripMenuItem.Text = LangCtrl.GetText("SET_OUTPUT_LOCATION");
            lSLHakkındaToolStripMenuItem.Text = LangCtrl.GetText("ABOUT_LSL");
            tümProjeyiÇıktıAlToolStripMenuItem.Text = LangCtrl.GetText("EXPORT_ALL_LANGS");
            çıkışToolStripMenuItem.Text = LangCtrl.GetText("EXIT");
        }

        private void InitializeExtentionResources()
        {
            foreach (var mI in ExtentionManager.menuItems)
            {
                if (mI != null)
                {

                    contextMenuStrip1.Items.Add(mI);
                }
            }
        }

        private void FormReady(object sender, EventArgs e)
        {
            CreateMenuButton();
            CreateExportAllButton();
        }

        void CreateMenuButton()
        {
            // 
            // btn_output_loc
            // 
            var btn_output_loc = new Button();
            btn_output_loc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btn_output_loc.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_settings_48;
            btn_output_loc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btn_output_loc.FlatAppearance.BorderSize = 0;
            btn_output_loc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_output_loc.Name = "btn_output_loc";
            btn_output_loc.Size = new System.Drawing.Size(35, 32);
            btn_output_loc.Click += new System.EventHandler(this.btn_output_loc_Click);
            ControlsBox.AddCustomControl(btn_output_loc);
        }
        void CreateExportAllButton()
        {
            var btn_export_all = new Button();
            btn_export_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            btn_export_all.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_export_48_32;
            btn_export_all.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            btn_export_all.FlatAppearance.BorderSize = 0;
            btn_export_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_export_all.Name = "btn_export_all_button";
            btn_export_all.Size = new System.Drawing.Size(35, 32);
            btn_export_all.Click += new System.EventHandler(this.btn_export_all_Click);
            toolTip1.SetToolTip(btn_export_all, LangCtrl.GetText("EXPORT_ALL_LANGS"));
            ControlsBox.AddCustomControl(btn_export_all);
        }

        private void CreateTabs()
        {
            foreach (var item in SelectedProject.languageManager.languageList)
            {
                var leditor = new LanguageEditor(SelectedProject, this, item);
                var ltab = new TabPage(item.name + (item.isDefault == "1" ? " - " + LangCtrl.GetText("DEFAULT") : ""));
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
            contextMenuStrip1.Show(location.X, location.Y + senderobj.Height);
        }
        

        private void btn_export_all_Click(object sender, EventArgs e)
        {
            ExportAllLangs();
        }

        private void yeniDilOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //CreateForm();
            AddLanguage addLanguage = new AddLanguage(SelectedProject);
            addLanguage.ShowDialog();
            ReloadTabs();


        }

        private void çıktıKonumunuBelirleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project.instance.SetDefaultExportLocation();
        }

        private void seçiliDiliSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(LangCtrl.GetText("ARE_YOU_SURE_TO_DELETE_FILE"), LangCtrl.GetText("WARNING"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                var selectedLanguageEditor = LanguageTabControl.SelectedTab.Controls[0] as LanguageEditor;
                if (selectedLanguageEditor != null)
                {
                    selectedLanguageEditor.DeleteLanguage();
                    //SelectedProject.languageManager.LanguagesSelect();

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

        internal void ExportAllLangs()
        {
            foreach (TabPage tab in LanguageTabControl.TabPages)
            {
                var languageEditor = tab.Controls[0] as LanguageEditor;
                if (!languageEditor.exportAlone())
                {
                    return;
                }
            }
            ProjectForm.SetLastProcessLabel(string.Format(LangCtrl.GetText("ALL_PROJECT_SAVED_AT_X"), Project.instance.GetDefaultExportLocation()));
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
                    var leditor = new LanguageEditor(SelectedProject, this, item);
                    var ltab = new TabPage(item.name + (item.isDefault == "1" ? " - " + LangCtrl.GetText("DEFAULT") : ""));
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
            if (MessageBox.Show(LangCtrl.GetText("ARE_YOU_SURE_TO_LOAD_OTHER_PROJECT"), LangCtrl.GetText("WARNING"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void projeyiYenidenYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(LangCtrl.GetText("ARE_YOU_SURE_TO_RELOAD_PROJECT"), LangCtrl.GetText("WARNING"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            else if (e.Control && e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9)
            {
                int tabIndex = e.KeyCode - Keys.D1; // Ctrl + 1 için 0, Ctrl + 2 için 1, vb.
                if (tabIndex < this.LanguageTabControl.TabPages.Count)
                {
                    this.LanguageTabControl.SelectedIndex = tabIndex;
                }
            }


        }

        Timer resetLPLabel = new Timer() { Interval = 2700 };
        public static void SetLastProcessLabel(string text,bool isPermanted = false)
        {
            instance.resetLPLabel.Stop();
            instance.last_process_label.Text = text;
            if (!isPermanted)instance.resetLPLabel.Start();
        }
        private void ResetLPLabel_Tick(object sender, EventArgs e)
        {
            resetLPLabel.Stop();
            instance.last_process_label.Text = LangCtrl.GetText("READY");
        }



        private void tümProjeyiÇıktıAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportAllLangs();
        }

        private void lSLHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutLSL aboutLSL = new AboutLSL();
            aboutLSL.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
