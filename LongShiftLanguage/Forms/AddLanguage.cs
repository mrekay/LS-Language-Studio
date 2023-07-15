using LongShiftLanguage.Classes;
using LongShiftLanguage.Classes.Abstract;
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
			this.database = database;
			this.project = project;	
		}



		private void btn_continue_Click(object sender, EventArgs e)
		{
			bool imperativeDefaultLang = false;
			if (string.IsNullOrEmpty(tb_proj_name.Text))
			{
				NotificationManager.CreateNotification("Dil Boş Olamaz", "Uyarı", SystemIcons.Error);
				return;
			}

			if (project.languageManager.CheckForDefualtLanguageExists() && checkBox1.Checked)
			{
				NotificationManager.CreateNotification("Zaten başka bir dil varsayılan olarak atanmış", "Uyarı", SystemIcons.Error);
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
				NotificationManager.CreateNotification("Dil Oluşturuldu","İşlem Başarılı",SystemIcons.Information);
				this.Close();
			}
			else
			{
				NotificationManager.CreateNotification("Dil Oluşturulamadı", "İşlem Başarısız", SystemIcons.Error);

			}


		}
	}
}
