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
	public class Project
	{

		DatabaseConnection database;

		public string id, name, photo;

		public LanguageManager languageManager;

		public Project(DatabaseConnection _dbConnection,int id)
		{
			database = _dbConnection;

			languageManager = new LanguageManager(database,Convert.ToInt32(id));
			this.id = id.ToString();
		}

		public bool CreateProject()
		{
			return database.InsertQuery(
				string.Format("INSERT INTO tbl_projects(name,photo) VALUES('{0}','{1}')",
				name, photo), databaseInfo.schemaname);
			

		}





	}
}
