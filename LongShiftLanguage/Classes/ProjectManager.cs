using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static config_definitions;

namespace LongShiftLanguage.Classes
{
	public class ProjectManager
	{

		public List<Project> projectList = new List<Project>();
		
		public static Project ToProject(object project)
		{
			return project as Project;
		}

		internal void Save()
		{
			var currentProjectList = projectList;

			var tempProjectList = new List<Project>();
			foreach (var project in projectList)
			{
				tempProjectList.Add(Project.Clone(project));
			}

			projectList = tempProjectList;

            XmlHelper.XmlSerialize(typeof(ProjectManager), this, GetProjectManHistoryPath());

			projectList = currentProjectList;
		}

		internal static ProjectManager Load() => XmlHelper.XmlDeserialize(typeof(ProjectManager), GetProjectManHistoryPath()) as ProjectManager;
		

		private static string GetProjectManHistoryPath() => Path.Combine(Application.StartupPath,config_definitions.ProjectsHistoryPath);
		
    }
}
