using LongShiftLanguage.Classes.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static config_definitions;

namespace LongShiftLanguage.Classes
{
	internal class ProjectManager
	{
		DatabaseConnection database;
		Control parent;
		public ProjectManager(DatabaseConnection _dbConnection, Control _parent)
		{
			database = _dbConnection;
			parent = _parent;
		}

		public List<Project> gamesList = new List<Project>();
		public List<Project> TranslationAppsSelectList()
		{
			var returnVal = new List<Project>();
			var data = database.SelectQuery("SELECT * FROM tbl_projects ORDER BY id desc", databaseInfo.schemaname);
			foreach (var item in data)
			{
				var todo = new Project(database, Convert.ToInt32(item["id"]))
				{
					name = item["name"],
					photo = item["photo"],
				};
				returnVal.Add(todo);
			}

			return returnVal;
		}
	}
}
