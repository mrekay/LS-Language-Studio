using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static config_definitions;
namespace LongShiftLanguage.Classes
{
	public class Language
	{

		public string name, isDefault, JSON;

		public  static Language CreateLanguage(string _name,string _isDefault,string _JSON)
		{
			var language = new Language();
			language.name = _name;
			language.isDefault = _isDefault;
			language.JSON = _JSON;
			return language;
		}
		
		public Dictionary<string,string> ConvertToDict()
		{
			if (string.IsNullOrEmpty(JSON)) return null;
            return JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(JSON)[0]; ;

        }

		public void SaveLanguage()
		{
			Project.instance.Save();
		}

        internal void DeleteLanguage()
        {
            Project.instance.languageManager.languageList.Remove(this);
        }
    }
}
