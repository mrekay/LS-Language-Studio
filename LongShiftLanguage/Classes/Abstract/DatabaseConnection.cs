using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongShiftLanguage.Classes.Abstract
{
	public enum DatabaseType {
	
		PHPAdapter,
		Sqlite
	};
	public abstract class DatabaseConnection
	{

		public DatabaseType databaseType; 
		public abstract List<Dictionary<string, string>> SelectQuery(string query, string database);
		public abstract bool InsertQuery(string query, string database);
		public abstract int	 AffectedRowsQuery(string query, string database);
		public abstract List<Dictionary<string, string>> CallRoutine(string procedureName, Dictionary<string, string> Parameters, string database, bool hasReturnValue);
	}
}
