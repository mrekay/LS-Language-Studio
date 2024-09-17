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
      
        public List<Language> languageList = new List<Language>();
       
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

        public Language GetDefaultLanguage()
        {
            foreach (var lang in languageList)
            {
                if (lang.isDefault == "1")
                {
                    return lang;
                }

            }

            return null;
        }
    }
}
