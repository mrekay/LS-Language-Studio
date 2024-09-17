using LongShiftLanguage.Classes;
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

namespace LongShiftLanguage.Forms
{
    internal partial class AddProject : LSForm
    {

        ProjectManager projectMan;
        internal AddProject(ProjectManager _projectMan)
        {
            InitializeComponent();
            LoadLanguageTexts();
            this.projectMan = _projectMan;
        }

        private void LoadLanguageTexts()
        {
            txt_project_name.Text = LangCtrl.GetText("PROJECT_NAME");
            txt_project_photo.Text = LangCtrl.GetText("PROJECT_PHOTO");
            btn_continue.Text = LangCtrl.GetText("CONTINUE");
        }

        public string base64Img;

        private void btn_loadimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter =  LangCtrl.GetText("IMAGE_FILES") +" (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                string base64String = Convert.ToBase64String(imageBytes);
                base64Img = base64String;

                // Base64 stringini PictureBox kontrolünde görüntüle
                pb_project_image.Image = ConvertBase64ToImage(base64String);
            }
        }

        private Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_proj_name.Text))
            {

                NotificationManager.CreateNotification(LangCtrl.GetText("PROJECT_NAME_CANNOT_BE_EMPTY"), LangCtrl.GetText("WARNING"), SystemIcons.Error);

                return;
            }

            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            string projectPath = "";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                projectPath = folderBrowser.SelectedPath;
            }
            else
            {
                return;
            }

            var newProject = Project.CreateProject(tb_proj_name.Text, base64Img);
            if (newProject != null)
            {
                newProject.path = Path.Combine(projectPath, tb_proj_name.Text+ ".lslp");
                projectMan.projectList.Add(newProject);
                newProject.Save();
                projectMan.Save();
                NotificationManager.CreateNotification(LangCtrl.GetText("PROJECT_CREATED_SUCCESSFULLY"), LangCtrl.GetText("OPERATION_SUCCESSFUL"), SystemIcons.Information);
                this.Close();
            }
            else
            {
                NotificationManager.CreateNotification(LangCtrl.GetText("PROJECT_CREATION_UNSUCCESSFUL"), LangCtrl.GetText("OEPRATION_FAILED"), SystemIcons.Error);

            }


        }
    }
}
