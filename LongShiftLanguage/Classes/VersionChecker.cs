using LongShiftLanguage.Classes.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static config_definitions;
namespace LongShiftLanguage.Classes
{
	public class VersionChecker
	{
		DatabaseConnection database;
		public VersionChecker(DatabaseConnection _dbConnection) { database = _dbConnection; }
		public string url, version;

		public bool CheckVersion()
		{
			if (database.databaseType != DatabaseType.PHPAdapter) return true;
			var data = database.SelectQuery(string.Format("SELECT * FROM tbl_apps WHERE id={0}",AppID), databaseInfo.schemaname);
			foreach (var item in data)
			{
				url = item["url"];
				version = item["version"];
				return (version == ApplicationVersion);
			}
			return true;
		}
		}
}
