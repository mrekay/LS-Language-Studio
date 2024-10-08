﻿using LongShiftLanguage.Classes;
using LongShiftLanguage.libs.multilanguage_support;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LongShiftLanguage.Forms
{
	public partial class ReplaceInAllLanguages : LSForm
	{

		Project project;
		ProjectForm projectForm;


		public ReplaceInAllLanguages(Project proj, ProjectForm projectForm)
		{
			InitializeComponent();
			this.project = proj;
			this.projectForm = projectForm;

            LoadLanguageTexts();

		}

        private void LoadLanguageTexts()
        {
			dgv_keywords.Columns[2].HeaderText = LangCtrl.GetText("LANGUAGE");
			dgv_keywords.Columns[3].HeaderText = LangCtrl.GetText("NAME");
			dgv_keywords.Columns[4].HeaderText = LangCtrl.GetText("VALUE");
			btn_save.Text = LangCtrl.GetText("CONTINUE");
        }

        public void getInAllLanguages(string key)
		{

			int i = 0;
			foreach (TabPage tab in projectForm.LanguageTabControl.TabPages)
			{
				var otherLE = tab.Controls[0] as LanguageEditor;
				var editorLang = otherLE.GetEditorLanguage();
				var value = otherLE.GetKeywordValue(key);
				
				if (value.Count > 0)
					AddKeyValue(i, value["rowID"], editorLang, key, value["value"]);
				else
					AddKeyValue(i, "", editorLang, key, "");
				i++;
			}
		}
		public void AddKeyValue(int tabID, string rowID, Language language, string key, string value)
		{
			var row = dgv_keywords.Rows.Add();
			dgv_keywords.Rows[row].Cells["keyid"].Value = tabID;
			dgv_keywords.Rows[row].Cells["ole_row_id"].Value = rowID;
			dgv_keywords.Rows[row].Cells["th_language"].Value = language.name;
			dgv_keywords.Rows[row].Cells["keyname"].Value = key;
			dgv_keywords.Rows[row].Cells["keyvalue"].Value = value;
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dgv_keywords.Rows)
			{
				var otherLE = projectForm.LanguageTabControl.TabPages[Convert.ToInt32(row.Cells[0].Value.ToString())].Controls[0] as LanguageEditor;
				var value = row.Cells["keyvalue"].Value != null ? row.Cells["keyvalue"].Value.ToString() : "";
				var rowID = row.Cells["ole_row_id"].Value;
				if (rowID != null)
					otherLE.setKeywordItem(rowID.ToString(), value);
				else
					otherLE.addKeywordItem("", row.Cells["keyname"].Value.ToString(), value);

			}
			NotificationManager.CreateNotification(LangCtrl.GetText("OPERATION_SUCCESSFUL"), LangCtrl.GetText("SAVED"), SystemIcons.Information);
			this.Close();
		}
	}
}
