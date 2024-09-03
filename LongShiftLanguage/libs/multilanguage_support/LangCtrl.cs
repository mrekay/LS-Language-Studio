using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.libs.multilanguage_support
{
    internal class LanguageController
    {
        public static LanguageController instance;

        private string defaultLanguageKey = "en";

        private List<Dictionary<string, string>> CurrentLang;
        private List<Dictionary<string, string>> DefaultLang;

        public LanguageController()
        {
            instance = this;
            LoadLanguage(Properties.Settings.Default.ml_support_default_language);
        }

        public Dictionary<string, string> CurrentLanguage()
        {
            if (CurrentLang != null)
                return CurrentLang[0];

            return null;
        }

        public Dictionary<string, string> DefualtLanguage()
        {
            if (DefaultLang != null)
                return DefaultLang[0];

            return null;
        }


        private string GetLangJson(string langType)
        {
            string lang_json = "";
            switch (langType)
            {
                case "tr":
                    lang_json = Encoding.UTF8.GetString(Properties.Resources.tr);
                    break;
                case "en":
                    lang_json = Encoding.UTF8.GetString(Properties.Resources.en);
                    break;
                case "fr":
                    lang_json = Encoding.UTF8.GetString(Properties.Resources.fr);
                    break;
                case "sp":
                    lang_json = Encoding.UTF8.GetString(Properties.Resources.sp);
                    break;
                case "ru":
                    lang_json = Encoding.UTF8.GetString(Properties.Resources.ru);
                    break;
                case "it":
                    lang_json = Encoding.UTF8.GetString(Properties.Resources.it);
                    break;
                case "de":
                    lang_json = Encoding.UTF8.GetString(Properties.Resources.de);
                    break;
                default:
                    lang_json = Encoding.UTF8.GetString(Properties.Resources.en);
                    break;


            }

            return lang_json;
        }

        public void LoadLanguage(string langType)
        {

            CurrentLang = JsonConvert.DeserializeObject<List<JObject>>(GetLangJson(langType))
                .Select(x => x?.ToObject<Dictionary<string, string>>()).ToList();


            DefaultLang = JsonConvert.DeserializeObject<List<JObject>>(GetLangJson(defaultLanguageKey))
                .Select(x => x?.ToObject<Dictionary<string, string>>()).ToList();

            Console.WriteLine("Loading Language : " + langType);
        }
    }

    public static class LangCtrl
    {
        public static string GetText(string textID, LangCtrlType langCtrlType = LangCtrlType.CurrentLanguage)
        {
            try
            {
                if (langCtrlType == LangCtrlType.DefaultLanguage)
                    return LanguageController.instance.DefualtLanguage()[textID];
                else
                    return LanguageController.instance.CurrentLanguage()[textID];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lang Parser error  : " + ex);
                return null;
            }
        }

        public enum LangCtrlType
        {
            DefaultLanguage,
            CurrentLanguage
        }
    }
    }