using LongShiftLanguage.Classes.Abstract;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static config_definitions;
using System.Collections;
using System.Data.SQLite;
using System.IO;

namespace LongShiftLanguage.Classes
{
	public class SqliteDatabase : DatabaseConnection
	{

		SQLiteConnection _connection;

		public SqliteDatabase()
		{
			databaseType = DatabaseType.Sqlite;
		}

		SQLiteConnection CreateConnection()
		{
			if (!File.Exists("./lib/longshiftlanguagedb.db")) function_special.CreateSQLiteDB();
			return new SQLiteConnection("Data Source=./lib/longshiftlanguagedb.db; Version = 3; New = True; Compress = True; ");
		}

		void OpenConnection()
		{
			_connection = CreateConnection();
			_connection.Open();
		}
		void CloseConnection()
		{
			_connection.Close();
		}

		public override List<Dictionary<string, string>> SelectQuery(string query, string database)
		{
			var returnVal = new List<Dictionary<string, string>>();
			try
			{

				OpenConnection();
				SQLiteCommand command = _connection.CreateCommand();
				command.CommandText = query;
				string json = "";
				// SQLite veri okuyucusunu başlatma
				using (SQLiteDataReader reader = command.ExecuteReader())
				{
					// JSON nesnesi oluşturma
					List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

					// Veri okuyucusunu dönerek her satırı işleme
					while (reader.Read())
					{
						// Satırın sütunlarını al
						Dictionary<string, object> row = new Dictionary<string, object>();

						for (int i = 0; i < reader.FieldCount; i++)
						{
							string columnName = reader.GetName(i);
							object value = reader.GetValue(i);
							row[columnName] = value;
						}

						// Satırı JSON nesnesine ekleme
						rows.Add(row);
					
					}

					// JSON nesnesini seri hale getirme
					json  = JsonConvert.SerializeObject(rows, Formatting.None);
				}
				CloseConnection();

				if (string.IsNullOrEmpty(json)) return returnVal;
				returnVal = JsonConvert.DeserializeObject<List<JObject>>(json)
				.Select(x => x?.ToObject<Dictionary<string, string>>())
				.ToList();
			}
			catch (Exception ex) { MessageBox.Show(ex.ToString()); CloseConnection();   }

			return returnVal;
		}
		public override List<Dictionary<string, string>> CallRoutine(string procedureName, Dictionary<string, string> Parameters, string database, bool hasReturnValue)
		{
			throw new NotImplementedException();
		}

		public override bool InsertQuery(string query, string database)
		{
			try
			{

				OpenConnection();
				SQLiteCommand command = _connection.CreateCommand();
				command.CommandText = query;
				var response = command.ExecuteNonQuery();
				CloseConnection();
				return response > 0;
			}
			catch (Exception ex) { CloseConnection(); MessageBox.Show(ex.ToString());  return false; }

		}

		public override int AffectedRowsQuery(string query, string database)
		{
			try
			{

				OpenConnection();
				SQLiteCommand command = _connection.CreateCommand();
				command.CommandText = query;
				var response = command.ExecuteNonQuery();
				CloseConnection();
				return response;
			}
			catch (Exception ex) { CloseConnection(); MessageBox.Show(ex.ToString()); return 0; }
		}
	}
}
