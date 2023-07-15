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
using System.Drawing;

namespace LongShiftLanguage.Classes
{
	public class PHPAdapterDatabase : DatabaseConnection
	{

public PHPAdapterDatabase() { databaseType = DatabaseType.PHPAdapter; }
		public override List<Dictionary<string, string>> SelectQuery(string query, string database)
		{
			var returnVal = new List<Dictionary<string, string>>();

			try
			{
				var workMethod = "SELECT";

				var values = new Dictionary<string, string>
			{
				{ "workmethod", workMethod },
				{ "db", database },
				{ "query", query }
			};
				HttpClient client = new HttpClient();
				var content = new FormUrlEncodedContent(values);
				client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(databaseInfo.username + ":" + databaseInfo.password)));
				var response = client.PostAsync(databaseInfo.Server, content);
				var responseString = response.Result.Content.ReadAsStringAsync();
				returnVal = JsonConvert.DeserializeObject<List<JObject>>(responseString.Result)
				.Select(x => x?.ToObject<Dictionary<string, string>>())
				.ToList();
			}
			catch (Exception ex) { NotificationManager.CreateNotification(ex.ToString(),"Veritabanı ile iletişimde bir problem oluştu",SystemIcons.Error); }
			return returnVal;
		}
		public override List<Dictionary<string, string>> CallRoutine(string procedureName, Dictionary<string, string> Parameters, string database, bool hasReturnValue)
		{
			var returnVal = new List<Dictionary<string, string>>();

			try
			{
				var workMethod = "CALL";

				var parameters_list_json = "";
				foreach (var parameter in Parameters.Keys)
				{
					parameters_list_json += (string.IsNullOrEmpty(parameters_list_json) ? "{" : ",") + string.Format("\"{0}\":\"{1}\"", parameter, Parameters[parameter]);
				}
				parameters_list_json += string.IsNullOrEmpty(parameters_list_json) ? "" : "}";

				var values = new Dictionary<string, string>
			{
				{ "workmethod", workMethod },
				{ "db", database },
				{ "routine", procedureName },
				{ "routine_parameters", parameters_list_json },
				{ "routine_has_return_values", hasReturnValue.ToString()}
			};
				HttpClient client = new HttpClient();

				var stringPayload = JsonConvert.SerializeObject(values);
				var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
				client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(databaseInfo.username + ":" + databaseInfo.password)));
				var response = client.PostAsync(databaseInfo.Server, content);
				var responseString = response.Result.Content.ReadAsStringAsync();
				returnVal = JsonConvert.DeserializeObject<List<JObject>>(responseString.Result)
				.Select(x => x?.ToObject<Dictionary<string, string>>())
				.ToList();
			}
			catch (Exception ex) { NotificationManager.CreateNotification(ex.ToString(), "Veritabanı ile iletişimde bir problem oluştu", SystemIcons.Error); }
			return returnVal;
		}

		public override bool InsertQuery(string query, string database)
		{
			var returnVal = false;

			try
			{
				var workMethod = "INSERT";

				var values = new Dictionary<string, string>
			{
				{ "workmethod", workMethod },
				{ "db", database },
				{ "query", query }
			};
				HttpClient client = new HttpClient(); 
				var stringPayload = JsonConvert.SerializeObject(values);
				var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
				client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(databaseInfo.username + ":" + databaseInfo.password)));
				var response = client.PostAsync(databaseInfo.Server, content);
				var responseString = response.Result.Content.ReadAsStringAsync();
				returnVal = responseString.Result.Contains("true");
			}
			catch (Exception ex) { NotificationManager.CreateNotification(ex.ToString(), "Veritabanı ile iletişimde bir problem oluştu", SystemIcons.Error); }
			return returnVal;
		}

		public override int AffectedRowsQuery(string query, string database)
		{
			int returnVal = 0;

			try
			{
				var workMethod = "AFFECTEDROWS";

				var values = new Dictionary<string, string>
			{
				{ "workmethod", workMethod },
				{ "db", database },
				{ "query", query }
			};
				HttpClient client = new HttpClient();
				var content = new FormUrlEncodedContent(values);
				client.DefaultRequestHeaders.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(databaseInfo.username + ":" + databaseInfo.password)));
				var response = client.PostAsync(databaseInfo.Server, content);
				var responseString = response.Result.Content.ReadAsStringAsync();
				returnVal = Convert.ToInt32(JsonConvert.DeserializeObject<string>(responseString.Result));
			}
			catch (Exception ex) { NotificationManager.CreateNotification(ex.ToString(), "Veritabanı ile iletişimde bir problem oluştu", SystemIcons.Error); }
			return returnVal;
		}
	}
}
