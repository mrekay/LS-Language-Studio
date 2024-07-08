using LongShiftLanguage.Classes.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static config_definitions;
namespace LongShiftLanguage.Classes
{
	public class Language
	{
		DatabaseConnection database;

		public string id, projID, name, isDefault, JSON;
		public Language(DatabaseConnection _dbConnection) { database = _dbConnection; }
		public void UpdateLanguage()
		{
			if (id != null)
			{
				database.AffectedRowsQuery(
				string.Format("UPDATE tbl_languages SET name='{1}', isDefault='{2}', JSON='{3}' WHERE id='{4}' and projID='{0}'",
				projID, name, isDefault, JSON,id), databaseInfo.schemaname);
			}
		}

		public void Select()
		{
			var data = database.SelectQuery(string.Format("SELECT * FROM tbl_languages WHERE projID={0} and id={1} ORDER BY isDefault desc", projID, id), databaseInfo.schemaname);
			if (data.Count <= 0) return;
			var item = data[0];
			id = item["id"];
			projID = item["projID"];
			name = item["name"];
			isDefault = item["isDefault"];
			JSON = HttpUtility.HtmlDecode(item["JSON"]);

		}

		public bool CreateLanguage()
		{
			return database.InsertQuery(
				string.Format("INSERT INTO tbl_languages(projID,name,isDefault) VALUES('{0}','{1}','{2}')",
				projID, name, isDefault), databaseInfo.schemaname);
		}
		public bool DeleteLanguage()
		{
			return database.AffectedRowsQuery(
				string.Format("DELETE FROM tbl_languages WHERE id ='{0}'", id), databaseInfo.schemaname) > 0;
		}


		public Dictionary<string,string> ConvertToDict()
		{
			if (string.IsNullOrEmpty(JSON)) return null;
            return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(JSON)[0]; ;

        }

    }
}
