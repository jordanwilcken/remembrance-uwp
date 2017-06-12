using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;

namespace persistence_component
{
    internal class AppDatabase
    {
        public AppDatabase(string connectionString, string createTablesCommand)
        {
            using (var connection = SQLiteConnection.MakeConnection())
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
