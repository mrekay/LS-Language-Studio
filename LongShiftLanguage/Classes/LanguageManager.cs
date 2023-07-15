using LongShiftLanguage.Classes.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static config_definitions;
namespace LongShiftLanguage.Classes
{
	public class LanguageManager
	{
		DatabaseConnection database;
		int projID;
		public LanguageManager(DatabaseConnection _dbConnection, int _projID)
		{
			database = _dbConnection;
			this.projID = _projID;

			LanguagesSelect();

		}

		public List<Language> languageList = new List<Language>();
		public void LanguagesSelect()
		{
			languageList = LanguagesSelectList();
		}
		public List<Language> LanguagesSelectList()
		{
			var returnVal = new List<Language>();
			var data = database.SelectQuery(string.Format("SELECT * FROM tbl_languages WHERE projID={0} ORDER BY isDefault desc",projID), databaseInfo.schemaname);
			foreach (var item in data)
			{
				var lang = new Language(database)
				{
					id = item["id"],
					projID = item["projID"],
					name = item["name"],
					isDefault = item["isDefault"],
					JSON = HttpUtility.HtmlDecode( item["JSON"]),
				};
				returnVal.Add(lang);
			}

			return returnVal;
		}

		public bool CheckForDefualtLanguageExists()
		{
			var retunVal = false;
			foreach (var lang in languageList)
			{
				if (lang.isDefault == "1")
				{
					retunVal = true;
					break;
				}
			}

			return retunVal;
		}
	}
}
