using LongShiftLanguage.libs.multilanguage_support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.Forms
{
    public partial class SettingsForm : LSForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadLanguageTexts();

            switch (Properties.Settings.Default.ml_support_default_language)
            {
                case "de":
                    comboBox1.Text = "Deutsch";
                    break;
                case "en":
                    comboBox1.Text = "English";
                    break;
                case "fr":
                    comboBox1.Text = "Français";
                    break;
                case "tr":
                    comboBox1.Text = "Türkçe";
                    break;
                case "sp":
                    comboBox1.Text = "Español";
                    break;
                case "ru":
                    comboBox1.Text = "Русский";
                    break;
                case "it":
                    comboBox1.Text = "Italiano";
                    break;
            }
        }

        private void LoadLanguageTexts()
        {
            lbl_app_prf_lng.Text = LangCtrl.GetText("APPLICATION_PREFERRED_LANGUAGE");
            btn_save.Text = LangCtrl.GetText("APPLY");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "English":
                    Properties.Settings.Default.ml_support_default_language = "en";
                    break;
                case "Türkçe":
                    Properties.Settings.Default.ml_support_default_language = "tr";
                    break;
                case "Deutsch":
                    Properties.Settings.Default.ml_support_default_language = "de";
                    break;
                case "Français":
                    Properties.Settings.Default.ml_support_default_language = "fr";
                    break;
                case "Español":
                    Properties.Settings.Default.ml_support_default_language = "sp";
                    break;
                case "Русский":
                    Properties.Settings.Default.ml_support_default_language = "ru";
                    break;
                case "Italiano":
                    Properties.Settings.Default.ml_support_default_language = "it";
                    break;
            }

            if (MessageBox.Show(LangCtrl.GetText("APPLICATION_MUST_BE_RESTARTED"),LangCtrl.GetText("WARNING"),MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes){
                Properties.Settings.Default.Save();
                Application.Restart();
            }
        }
    }
}
