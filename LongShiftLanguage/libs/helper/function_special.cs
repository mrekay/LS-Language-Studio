using LongShiftLanguage.Classes;
using LongShiftLanguage.Classes.Abstract;
using LongShiftLanguage.Forms;
using System;
using System.IO;
using System.Windows.Forms;

public static class function_special
	{


	public static DatabaseConnection CreateDBConnection()
	{
		switch (config_definitions.APP_DB_TYPE)
		{
			case DatabaseType.PHPAdapter:
				return new PHPAdapterDatabase();
				break;
			case DatabaseType.Sqlite:
				return new SqliteDatabase();
				break;
		}
		return new SqliteDatabase();
	}

	public static void CreateSQLiteDB()
	{
		if (Directory.Exists("./lib/"))
		{
			File.WriteAllBytes("./lib/longshiftlanguagedb.db", LongShiftLanguage.Properties.Resources.longshiftlanguagedb);
		}
	}
}

