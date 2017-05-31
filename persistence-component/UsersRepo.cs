using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;

namespace persistence_component
{
    public sealed class UsersRepo
    {
        public UsersRepo()
        {

        }

        public UserDTO Get(string username)
        {
            SqliteEngine.UseWinSqlite3();
            UserDTO dto;

            using (var connection = new SqliteConnection("Data Source=remembrance.db;"))
            {
                connection.Open();
                using (var command = new SqliteCommand(
                    "SELECT rowid, username, hashed_password FROM users WHERE username = 'Guest'",
                    connection))
                {
                    var reader = command.ExecuteReader();
                    reader.Read();
                    object[] currentRow = new object[reader.FieldCount];
                    reader.GetValues(currentRow);
                    dto = new UserDTO { Id = (long)currentRow[0], Name = currentRow[1] as string, HashedPassword = currentRow[2] as string };
                    //(long)row[0], row[1] as string, row[2] as string
                }
                connection.Close();
            }

            return dto;
        }
    }
}
