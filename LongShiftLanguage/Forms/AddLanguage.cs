using LongShiftLanguage.Classes;
using LongShiftLanguage.Classes.Abstract;
using LongShiftLanguage.libs.multilanguage_support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LongShiftLanguage.Forms
{
	public partial class AddLanguage : LSForm
	{

		DatabaseConnection database;
		Project project;
		public AddLanguage(DatabaseConnection database, Project project)
		{
			InitializeComponent();
            LoadLanguageTexts();
			this.database = database;
			this.project = project;	
		}

        private void LoadLanguageTexts()
        {
			label2.Text = LangCtrl.GetText("LANGUAGE");
			checkBox1.Text = LangCtrl.GetText("DEFAULT_LANGUAGE");
			btn_continue.Text = LangCtrl.GetText("CONTINUE");
        }

        private void btn_continue_Click(object sender, EventArgs e)
		{
			bool imperativeDefaultLang = false;
			if (string.IsNullOrEmpty(tb_proj_name.Text))
			{
				NotificationManager.CreateNotification(LangCtrl.GetText("LANG_CANNOT_BE_EMPTY"), LangCtrl.GetText("WARNING"), SystemIcons.Error);
				return;
			}

			if (project.languageManager.CheckForDefualtLanguageExists() && checkBox1.Checked)
			{
				NotificationManager.CreateNotification(LangCtrl.GetText("ANOTHER_LANG_ALREADY_DEFAULT"), LangCtrl.GetText("WARNING"), SystemIcons.Error);
				return;
			}
			else if (!project.languageManager.CheckForDefualtLanguageExists()) 
			{
				imperativeDefaultLang = true;
			}

			Language lang = new Language(database);
			lang.projID = project.id.ToString();
			lang.name = tb_proj_name.Text;
			lang.isDefault = checkBox1.Checked || imperativeDefaultLang ? "1" : "0";
			if (lang.CreateLanguage())
			{
				NotificationManager.CreateNotification(LangCtrl.GetText("LANG_CREATED"), LangCtrl.GetText("OPERATION_SUCCESSFUL"), SystemIcons.Information);
				this.Close();
			}
			else
			{
				NotificationManager.CreateNotification(LangCtrl.GetText("LANG_CREATION_UNSUCCESSFUL"), LangCtrl.GetText("OEPRATION_FAILED"), SystemIcons.Error);

			}


		}
	}
}
