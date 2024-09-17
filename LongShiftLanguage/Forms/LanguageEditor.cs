using Google.Protobuf.WellKnownTypes;
using LongShiftLanguage.Classes;
using LongShiftLanguage.Classes.Components;
using LongShiftLanguage.libs.multilanguage_support;
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
        Classes.Project project;
        ProjectForm projectFrm;
        Language loadedLanguage;
        bool isDefault;
        string importedJson;
        List<DataGridViewRow> new_rows = new List<DataGridViewRow>();
        public LanguageEditor( Classes.Project _project, ProjectForm _proj, Language loadingLang)
        {
            InitializeComponent();
            LoadLanguageTexts();
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

            /* extention resources*/
            InitializeExtentionResources();
            ProjectForm.SetLastProcessLabel(LangCtrl.GetText("PROJECT_LOADED"));


        }

        private void LoadLanguageTexts()
        {
            MainTooltip.SetToolTip(btn_add, LangCtrl.GetText("NEW_ROW"));
            MainTooltip.SetToolTip(btn_delete, LangCtrl.GetText("DELETE_SELECTED_ROWS"));
            MainTooltip.SetToolTip(btn_reload, LangCtrl.GetText("RELOAD"));
            MainTooltip.SetToolTip(btn_save, LangCtrl.GetText("SAVE"));
            MainTooltip.SetToolTip(btn_importJSON, LangCtrl.GetText("REMOVE_ALL_DATAS_AND_LOAD_FROM_FILE"));
            MainTooltip.SetToolTip(btn_merge, LangCtrl.GetText("COMPARE_AND_LOAD_FROM_FILE"));
            MainTooltip.SetToolTip(btn_exportjson, LangCtrl.GetText("EXPORT"));
            MainTooltip.SetToolTip(btn_copyJSON, LangCtrl.GetText("COPY_AS_JSON"));
            MainTooltip.SetToolTip(btn_replace_all_languages, LangCtrl.GetText("REPLACE_IN_ALL_LANGUAGES"));
            MainTooltip.SetToolTip(btn_export_to_loc, LangCtrl.GetText("DROP_DESIGNATED_OUTPUT_LOCATION"));
            MainTooltip.SetToolTip(txt_search, LangCtrl.GetText("SEARCH"));
            dgv_keywords.Columns[1].HeaderText  = LangCtrl.GetText("NAME");
            dgv_keywords.Columns[2].HeaderText  = LangCtrl.GetText("VALUE");
        }

        private void InitializeExtentionResources()
        {
            foreach (var btn in ExtentionManager.menuButtons)
            {
                var myBtn = ToolMenuButton.Clone(btn);
                ToolButtonPanel.Controls.Add(myBtn);
                var lst_btn = ToolButtonPanel.Controls[Controls.Count - 1];
                myBtn.Click += (s, e) => btn.PerformClick();
                MainTooltip.SetToolTip(myBtn, myBtn.ToolTipText);
                myBtn.Location = new Point(lst_btn.Location.X + lst_btn.Width + myBtn.Width + 12, 3);
            }
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
            saveFileDialog.Filter = LangCtrl.GetText("JSON_FILES") +" (*.json)|*.json";
            saveFileDialog.Title = LangCtrl.GetText("SAVE_JSON_FILE");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                // JSON verisini seçilen dosyaya yazıyoruz
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, ExportJSONText());

                ProjectForm.SetLastProcessLabel(LangCtrl.GetText("JSON_EXPORT_SUCCESS"));
            }
        }
        void ImportJSON(bool merge = false)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = LangCtrl.GetText("JSON_FILES") +"|*.json";
            openFileDialog.Title = LangCtrl.GetText("SELECT_A_JSON_FILE");

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
                    MessageBox.Show(string.Format(LangCtrl.GetText("ERROR_OCCURRED_WHILE_READING_JSON"), ex.Message), LangCtrl.GetText("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void setKeywordItem(string id, string value)
        {
            dgv_keywords.Rows[Convert.ToInt32(id)].Cells["keyvalue"].Value = value;
        }
        internal bool exportAlone()
        {
            try
            {
                var defaultExportLoc = Project.instance.GetDefaultExportLocation();
                if (string.IsNullOrEmpty(defaultExportLoc)) return false;
                var loc = Path.Combine(defaultExportLoc, loadedLanguage.name + ".json");
                File.WriteAllText(loc, ExportJSONText());
                ProjectForm.SetLastProcessLabel(string.Format(LangCtrl.GetText("FILE_SAVED_TO"), loc));
                return true;
            }
            catch (Exception ex)
            {
                ProjectForm.SetLastProcessLabel(LangCtrl.GetText("OEPRATION_FAILED"));
                return false;
            }
        }
        internal void saveAlone()
        {
            loadedLanguage.JSON = ExportJSONText(true);
            loadedLanguage.SaveLanguage();
        }
        internal void reloadAlone()
        {
            ImportJSONText(loadedLanguage.JSON);
        }
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
        #endregion

        #region buttonEvent

        private void btn_export_to_loc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Project.instance.GetDefaultExportLocation()))
            {
                ExportJson();
            }
            else
            {
                exportAlone();
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
        private void btn_copyJSON_Click_1(object sender, EventArgs e)
        {

            Clipboard.SetText(ExportJSONText());
        }
        private void btn_exportjson_Click(object sender, EventArgs e)
        {
            if (dgv_keywords.SelectedRows.Count > 1) MessageBox.Show(LangCtrl.GetText("THERE_ARE_SELECTED_FILES"), LangCtrl.GetText("INFORMATION"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (MessageBox.Show(LangCtrl.GetText("RELOAD_ALL_PROJECT_OR_RELOAD_SINGLE_LANGUAGE"), LangCtrl.GetText("RELOAD"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
        private void btn_replace_all_languages_Click(object sender, EventArgs e)
        {
            if (dgv_keywords.SelectedRows.Count <= 0) return;

            ReplaceInAllLanguages replaceInAll = new ReplaceInAllLanguages(project, projectFrm);
            foreach (DataGridViewRow row in dgv_keywords.SelectedRows)
            {

                replaceInAll.getInAllLanguages(row.Cells["keyname"].Value.ToString());
            }
            replaceInAll.ShowDialog();
        }


        #endregion

        private void copyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_keywords.SelectedRows.Count > 0)
            Clipboard.SetText(dgv_keywords.SelectedRows[0].Cells["keyname"].Value.ToString());
        }

        private void copyValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_keywords.SelectedRows.Count > 0)
                Clipboard.SetText(dgv_keywords.SelectedRows[0].Cells["keyvalue"].Value.ToString());
        }

        private void deleteEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgv_keywords.SelectedRows.Count > 0)
            {
                foreach (var dgv in dgv_keywords.SelectedRows)
                {
                    dgv_keywords.Rows.Remove(dgv as DataGridViewRow);
                }
            }

        }

        private void dgv_keywords_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
                // Eğer sağ tıklama yapılmışsa
                if (e.Button == MouseButtons.Right)
                {
                    // Sağ tıklanan hücreyi seçili hale getir
                    dgv_keywords.ClearSelection();
                dgv_keywords.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                
            }
        }
    }
}
