using LongShiftLanguage.Classes;
using LongShiftLanguage.Classes.Abstract;
using LongShiftLanguage.Classes.Components;
using LongShiftLanguage.libs.multilanguage_support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static functions;

namespace LongShiftLanguage.Forms
{
	public partial class ProjectSelector : LSForm
	{

		DatabaseConnection database;
		ProjectManager projectsManager;

		List<Classes.Project> projects;
        Classes.Project _selectedProject;

		public ProjectSelector(DatabaseConnection _db)
		{
			InitializeComponent();

			database = _db;
			projectsManager = new ProjectManager(database,this);

			InitalizeApps();
			Shown += FormReady;
		}

		private void FormReady(object sender, EventArgs e)
		{
			CreateCustomSettingsButton();

            CreateCustomCreateButton();
		}

		void CreateCustomCreateButton()
		{
			var crate_btn = new Button();
			crate_btn.BackgroundImage = global::LongShiftLanguage.Properties.Resources.add;
			crate_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			crate_btn.FlatAppearance.BorderSize = 0;
			crate_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			crate_btn.Name = "btn_create_lang";
			crate_btn.Size = new System.Drawing.Size(24, 24);
			crate_btn.Anchor = AnchorStyles.Right;
			crate_btn.Click += new System.EventHandler(crate_btn_Click);
			ControlsBox.AddCustomControl(crate_btn);
		}
		void CreateCustomSettingsButton()
		{
			var crate_btn = new Button();
			crate_btn.BackgroundImage = global::LongShiftLanguage.Properties.Resources.globe;
			crate_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			crate_btn.FlatAppearance.BorderSize = 0;
			crate_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			crate_btn.Name = "btn_settings";
			crate_btn.Size = new System.Drawing.Size(24, 24);
			crate_btn.Anchor = AnchorStyles.Right;
			crate_btn.Click += new System.EventHandler(btn_settings_click);
			ControlsBox.AddCustomControl(crate_btn);
		}

        private void btn_settings_click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void InitalizeApps()
		{
			panel_projects.Controls.Clear();
			projects = projectsManager.TranslationAppsSelectList();

			var projKey = 0;
			foreach (var project in projects)
			{
				var newPB = CreateprojectselectPB(projKey.ToString(), project.name);
				panel_projects.Controls.Add(newPB);
				newPB.Location = new Point(((panel_projects.Size.Width - newPB.Size.Width)/2), 20 +(newPB.Height*(panel_projects.Controls.Count-1) + (8 * (panel_projects.Controls.Count - 1))) );
                projKey++;
			}

		}

		public AppButton CreateprojectselectPB(string appID,string appName)
		{
			var selectProjectPB = new AppButton(ConvertBase64ToImage(projects[Convert.ToInt32(appID)].photo), appName,appID);

            selectProjectPB.Click += SelectProjPB_Click;
			return selectProjectPB;
		}

		private void SelectProjPB_Click(object sender, EventArgs e)
		{
			_selectedProject =  projects[Convert.ToInt32((sender as PictureBox).Tag)];
			this.Close();
		}

		public Classes.Project GetSelectedProject()
		{
			return _selectedProject;
		}

		private void ProjectSelector_FormClosed(object sender, FormClosedEventArgs e)
		{

		}

		private void crate_btn_Click(object sender, EventArgs e)
		{
			AddProject addProject = new AddProject(database);
			addProject.ShowDialog();
			InitalizeApps();
		}

        private void ProjectSelector_Load(object sender, EventArgs e)
        {
			label1.Text = LangCtrl.GetText("PLEASE_SELECT_PROJECT");
        }
    }
}
