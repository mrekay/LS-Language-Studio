using LongShiftLanguage.Classes;
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

        ProjectManager projectsManager;

        Classes.Project _selectedProject;

        public ProjectSelector(ProjectManager projectManager)
        {
            InitializeComponent();
            projectsManager = projectManager;

            InitalizeApps();
            Shown += FormReady;
        }

        private void FormReady(object sender, EventArgs e)
        {
            CreateCustomSettingsButton();

        }

        void CreateCustomSettingsButton()
        {
            var crate_btn = new Button();
            crate_btn.BackgroundImage = global::LongShiftLanguage.Properties.Resources.icons8_globe_48;
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

            var projKey = 0;
            foreach (var project in projectsManager.projectList)
            {
                var projObject = ProjectManager.ToProject(project);

                var newPB = CreateprojectselectPB(projObject, projectsManager.projectList.IndexOf(project));
                panel_projects.Controls.Add(newPB);
                newPB.Location = new Point(((panel_projects.Size.Width - newPB.Size.Width) / 2), 20 + (newPB.Height * (panel_projects.Controls.Count - 1) + (8 * (panel_projects.Controls.Count - 1))));
                projKey++;
            }

        }

        public AppButton CreateprojectselectPB(Project proj, int projID)
        {
            var selectProjectPB = new AppButton(ConvertBase64ToImage(proj.photo), proj.name, projID);

            selectProjectPB.Click += SelectProjPB_Click;
            selectProjectPB.appNameLabel.Click += SelectProjPB_Click;
            selectProjectPB.deleteLanguageButton.Click += DeleteLanguageButton_Click;
            return selectProjectPB;
        }

        private void DeleteLanguageButton_Click(object sender, EventArgs e)
        {
            var projectID = Convert.ToInt32((sender as Control).Tag);
            var project = ProjectManager.ToProject(projectsManager.projectList[projectID]);
            projectsManager.projectList.RemoveAt(projectID);
            projectsManager.Save();
            InitalizeApps();
        }

        private void SelectProjPB_Click(object sender, EventArgs e)
        {
            var projectID = Convert.ToInt32((sender as PictureBox).Tag);
            var project = ProjectManager.ToProject(projectsManager.projectList[projectID]);
            if (!File.Exists(project.path))
            {
                RemoveProjectQuestion(projectID);
                return;
            }
            try
            {
                project = Project.Load(project.path);
            }
            catch (Exception ex)
            {
                RemoveProjectQuestion(projectID);
                return;
            }

            Project.instance = project;
            _selectedProject = project;
            this.Close();
        }

        public void RemoveProjectQuestion(int projectID)
        {
            if (MessageBox.Show(LangCtrl.GetText("PROJECT_REMOVED_OR_DELETED"), LangCtrl.GetText("WARNING"),MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                projectsManager.projectList.RemoveAt(projectID);
                projectsManager.Save();
                InitalizeApps();
            }
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
            AddProject addProject = new AddProject(projectsManager);
            addProject.ShowDialog();
            InitalizeApps();
        }

        private void ProjectSelector_Load(object sender, EventArgs e)
        {
            label1.Text = LangCtrl.GetText("PLEASE_SELECT_PROJECT");
        }

        private void btn_delete_lang_Click(object sender, EventArgs e)
        {
            ToggleDeletionMode();
        }

        bool deletionMode = false;
        private void ToggleDeletionMode()
        {
            deletionMode = !deletionMode;
            foreach(var projectBtn in panel_projects.Controls)
            {
                AppButton projbtn = projectBtn as AppButton;
                projbtn.deleteLanguageButton.Visible = deletionMode;
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "LSL File|*.lslp";
            if (opf.ShowDialog() == DialogResult.OK)
            {
               var project = Project.Load(opf.FileName);
                project.path = opf.FileName;
                project.Save();
                projectsManager.projectList.Add(project);
                projectsManager.Save();
                InitalizeApps();
            }
        }
    }
}
