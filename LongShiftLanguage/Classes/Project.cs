using LongShiftLanguage.libs.multilanguage_support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static config_definitions;
namespace LongShiftLanguage.Classes
{
    public class Project
    {
       [NonSerialized] public static Project instance;
        public string name, photo, path;
        private string exportPath;

        public LanguageManager languageManager = new LanguageManager();

        public static Project CreateProject(string _name, string _photo, string path = "")
        {
            Project newProject = new Project();
            newProject.name = _name;
            newProject.photo = _photo;
            newProject.path = path;

            return newProject;
        }
        public static Project Clone(Project project)
        {
            Project newProject = new Project();
            newProject.name = project.name;
            newProject.photo = project.photo;
            newProject.path = project.path;

            return newProject;
        }

        internal static Project Load(string path) => XmlHelper.XmlDeserialize(typeof(Project), path) as Project;

        public string GetDefaultExportLocation()
        {
            if (!Directory.Exists(exportPath))
            {
                if (MessageBox.Show(string.IsNullOrEmpty(exportPath) ? LangCtrl.GetText("THERE_IS_NO_EXPORT_LOC") : LangCtrl.GetText("EXPORT_POINT_IS_NO_LONGER_EXIST"),LangCtrl.GetText("WARNING"),MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SetDefaultExportLocation();
                }
                else
                {
                    return "";
                }
            }

            return exportPath;
        }

        public void SetDefaultExportLocation()
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

                if (string.IsNullOrEmpty(selectedFolder)) { MessageBox.Show(LangCtrl.GetText("SAVE_POINT_CANNOT_BE_EMPTY"), LangCtrl.GetText("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                exportPath = selectedFolder;
                Save();
                MessageBox.Show(LangCtrl.GetText("DATA_OUTPUT_LOCATION_SAVED"));
            }
        }

        internal void Save()
        {
            XmlHelper.XmlSerialize(typeof(Project), this, path);
        }
    }
}
