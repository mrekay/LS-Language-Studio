using Google.Protobuf.WellKnownTypes;
using LongShiftLanguage.Classes;
using LongShiftLanguage.Classes.Abstract;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Xml.Linq;

namespace LongShiftLanguage.Forms
{
	public partial class LanguageEditor : Form
	{
		DatabaseConnection database;
		Classes.Project project;
		ProjectForm projectFrm;
		Language loadedLanguage;
		bool isDefault;
		string importedJson;
		List<DataGridViewRow> new_rows = new List<DataGridViewRow>();
		public LanguageEditor(DatabaseConnection _db, Classes.Project _project, ProjectForm _proj, Language loadingLang)
		{
			InitializeComponent();

			database = _db;
			project = _project;
			projectFrm = _proj;
			loadedLanguage = loadingLang;
			isDefault = loadedLanguage.isDefault == "1" ? true : false;

			if (string.IsNullOrEmpty(loadingLang.JSON) && loadingLang.isDefault != "1")
			{
				if (projectFrm.GetStandardTab() != null)
					ImportJSONText(projectFrm.GetStandardTab().GetImportedJSON());
			}
			else
				ImportJSONText(loadingLang.JSON);

			initalized = true;
		}

		bool initalized = false;
		#region EditorFunctions

		public Language GetEditorLanguage()
		{
			return loadedLanguage;
		}
		string ExportJSONText(bool saving = false)
		{
			// DataGridView'deki verileri JSON formatına dönüştürmek için bir liste oluşturuyoruz
			var jsonstring = "[{";
			var addedObjects = 0;
			foreach (DataGridViewRow row in dgv_keywords.Rows)
			{

				if (!saving && dgv_keywords.SelectedRows.Count > 1 && !dgv_keywords.SelectedRows.Contains(row)) continue;
				if (row.IsNewRow != false) continue;
				// DataGridView'deki her bir satırı dolaşıyoruz
				Dictionary<string, object> rowData = new Dictionary<string, object>();

				if (addedObjects != 0) jsonstring += ",";
				addedObjects++;
				jsonstring += string.Format("\"{0}\":\"{1}\"", row.Cells[1].Value, row.Cells[2].Value);
			}
			jsonstring += "}]";
			return jsonstring;
		}

		void ImportJSONText(string jsonContent)
		{
			if (string.IsNullOrEmpty(jsonContent)) return;
			dgv_keywords.Rows.Clear();
			List<Dictionary<string, string>> jsonDict = JsonConvert.DeserializeObject<List<JObject>>(jsonContent)
			.Select(x => x?.ToObject<Dictionary<string, string>>()).ToList();

			foreach (var item in jsonDict[0].Keys)
			{
				addKeywordItem("", item, jsonDict[0][item]);
			}

			importedJson = jsonContent;
		}

		public string GetImportedJSON()
		{
			return string.IsNullOrEmpty(importedJson) ? "" : importedJson;
		}

		void ExportJson()
		{
			// SaveFileDialog oluşturuyoruz
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "JSON Files (*.json)|*.json";
			saveFileDialog.Title = "Save JSON File";

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{

				// JSON verisini seçilen dosyaya yazıyoruz
				string filePath = saveFileDialog.FileName;
				File.WriteAllText(filePath, ExportJSONText());

				MessageBox.Show("Veriler JSON dosyasına başarıyla aktarıldı!");
			}
		}
		void ImportJSON(bool merge = false)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "JSON Files|*.json";
			openFileDialog.Title = "Select a JSON File";

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{

				string selectedFilePath = openFileDialog.FileName;
				try
				{
					string jsonContent = File.ReadAllText(selectedFilePath);
					if (!merge)
					{
						dgv_keywords.Rows.Clear();
						ImportJSONText(jsonContent);
					}
					else
					{
						MergeJSONText(jsonContent);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occurred while reading the JSON file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void MergeJSONText(string jsonContent)
		{

			if (string.IsNullOrEmpty(jsonContent)) return;

			List<Dictionary<string, string>> jsonDict = JsonConvert.DeserializeObject<List<JObject>>(jsonContent)
			.Select(x => x?.ToObject<Dictionary<string, string>>()).ToList();

			foreach (var item in jsonDict[0].Keys)
			{
				bool added = false;
				foreach (DataGridViewRow row in dgv_keywords.Rows)
				{
					if (row.Cells[1].Value.ToString() == item)
					{
						row.Cells[2].Value = jsonDict[0][item];
						added = true;
					}


				}
				if (!added)
				{
					addKeywordItem("", item, jsonDict[0][item]);
					dgv_keywords.FirstDisplayedScrollingRowIndex = dgv_keywords.RowCount - 1;

				}
			}


		}

		public void addKeywordItem(string id, string name, string value)
		{

			var row = dgv_keywords.Rows.Add();
			dgv_keywords.Rows[row].Cells[0].Value = id;
			dgv_keywords.Rows[row].Cells[1].Value = name;
			dgv_keywords.Rows[row].Cells[2].Value = value;

		}
		public void setKeywordItem(string id, string value) {
			dgv_keywords.Rows[Convert.ToInt32(id)].Cells["keyvalue"].Value = value;
		}


		internal void saveAlone()
		{
			loadedLanguage.JSON = ExportJSONText(true);
			loadedLanguage.UpdateLanguage();
		}
		internal void reloadAlone()
		{
			loadedLanguage.Select();
			ImportJSONText(loadedLanguage.JSON);
		}
		#endregion

		#region buttonEvent
		private void btn_copyJSON_Click_1(object sender, EventArgs e)
		{

			Clipboard.SetText(ExportJSONText());
		}

		private void btn_exportjson_Click(object sender, EventArgs e)
		{
			if (dgv_keywords.SelectedRows.Count > 1) MessageBox.Show("Seçili öğeler var. Sadece seçili olan öğeler çıkartılacaktır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
			ExportJson();
		}

		private void btn_importJSON_Click(object sender, EventArgs e)
		{
			ImportJSON();
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			projectFrm.SaveAllProject();
		}

		private void btn_reload_Click_1(object sender, EventArgs e)
		{
			if (MessageBox.Show("Tüm Projeyi Yeniden Yüklemek İçin Evet Basın.\n(Hayır derseniz sadece bu dil yeniden yüklenecek.)", "Yeniden Yükleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				projectFrm.ReloadAll();
			}
			else
			{
				reloadAlone();
			}
		}

		private void btn_delete_Click(object sender, EventArgs e)
		{
			if (dgv_keywords.SelectedRows.Count > 0)
			{
				foreach (var dgv in dgv_keywords.SelectedRows)
				{
					dgv_keywords.Rows.Remove(dgv as DataGridViewRow);
				}
			}
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
			dgv_keywords.Rows.Add();
			dgv_keywords.FirstDisplayedScrollingRowIndex = dgv_keywords.RowCount - 1;
		}
		#endregion

		private void dgv_keywords_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var row = dgv_keywords.Rows[e.RowIndex];
			var text = row.Cells[e.ColumnIndex].Value;
			if (row != null)
			{
				if (new_rows.Contains(row))
				{

					if (isDefault)
					{
						foreach (TabPage tab in projectFrm.LanguageTabControl.TabPages)
						{
							var otherLE = tab.Controls[0] as LanguageEditor;
							if (otherLE != null && !otherLE.isDefault)
							{
								if (otherLE.dgv_keywords.Rows.Count <= e.RowIndex) otherLE.dgv_keywords.Rows.Add("", row.Cells[1].Value, row.Cells[2].Value);
								else
								{
									otherLE.dgv_keywords.Rows[e.RowIndex].Cells[1].Value = row.Cells[1].Value;
									otherLE.dgv_keywords.Rows[e.RowIndex].Cells[2].Value = row.Cells[2].Value;
								}
							}
						}
					}
				}
			}

		}

		private void dgv_keywords_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (initalized)
				new_rows.Add(dgv_keywords.Rows[e.RowIndex]);
		}

		private void exportUnity_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(Properties.Settings.Default.unity_output_location))
			{
				ExportJson();
			}
			else
			{
				var loc = Properties.Settings.Default.unity_output_location + "\\" + (dgv_keywords.Rows[0].Cells[2].Value) + ".json";
				File.WriteAllText(loc, ExportJSONText());
			}
		}

		private void txt_search_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				foreach (DataGridViewRow row in dgv_keywords.Rows)
				{
					if (row.Cells[1].Value.ToString().ToLower().Contains(txt_search.Text.ToLower()) || row.Cells[2].Value.ToString().ToLower().Contains(txt_search.Text.ToLower()))
					{
						row.Visible = true;
					}
					else
					{
						row.Visible = false;
					}
				}
			}
		}

		private void pb_search_Click(object sender, EventArgs e)
		{
			txt_search.Focus();
		}

		private void btn_merge_Click(object sender, EventArgs e)
		{
			ImportJSON(true);
		}

		internal void DeleteLanguage()
		{
			loadedLanguage.DeleteLanguage();
		}

		private void LanguageEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			var tb = (this.Parent as TabPage);
			var tbcontrol = tb.Parent;
			tbcontrol.Controls.Remove(tb);
		}

		private void btn_replace_all_languages_Click(object sender, EventArgs e)
		{
			if (dgv_keywords.SelectedRows.Count <= 0) return;

			ReplaceInAllLanguages replaceInAll = new ReplaceInAllLanguages(project, database, projectFrm);
			foreach (DataGridViewRow row in dgv_keywords.SelectedRows)
			{

				replaceInAll.getInAllLanguages(row.Cells["keyname"].Value.ToString());
			}
			replaceInAll.ShowDialog();
		}

		public Dictionary<string, string> GetKeywordValue(string key)
		{
			Dictionary<string, string> result = new Dictionary<string, string>();

			int i = 0;
			foreach (DataGridViewRow row in dgv_keywords.Rows)
			{

				if (row.Cells["keyname"].Value.ToString() == key)
				{
					result.Add("value", !string.IsNullOrEmpty((string)row.Cells["keyvalue"].Value) ? row.Cells["keyvalue"].Value.ToString() : "");
					result.Add("rowID", i.ToString());
					break;
				}

				i++;
			}
			return result;

		}
	}
}
