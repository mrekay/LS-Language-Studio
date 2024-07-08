using LongShiftLanguage.Classes.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class config_definitions
{

	public static DatabaseType APP_DB_TYPE = DatabaseType.Sqlite;

	public static Session databaseInfo = new Session()
	{
		Server = "",
		schemaname = "",
		username = "",
		password = "*",
	};

	public static string
		SaltText = "LongShift Language Studio",
		ApplicationName = "LongShift Language Studio",
		ApplicationVersion = "1.5.1",
		DEFAULT_ENCRYPTION_PASSWORD = "LongShiftLanguage.",
		AppID = "2",
		ExtensionPath = "/lib/Extensions";

	public static Color APP_THEME = Color.DodgerBlue;
}

