using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;

namespace persistence_component
{
    internal class AppDatabase
    {
        public AppDatabase(string connectionString, string createTablesCommand)
        {
            SqliteEngine.UseWinSqlite3();
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqliteCommand(createTablesCommand, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
