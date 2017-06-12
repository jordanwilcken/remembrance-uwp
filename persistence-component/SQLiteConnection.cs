using Microsoft.Data.Sqlite;
using Microsoft.Data.Sqlite.Internal;
using persistence_component.PoorMansGenerics;
using System.Collections.Generic;
using System.Linq;
using Windows.Storage;

namespace persistence_component
{
    class SQLiteConnection : IConnection
    {
        private IConvertToFields FieldConverter { get; }

        public SQLiteConnection(IConvertToFields fieldConverter)
        {
            FieldConverter = fieldConverter;
        }

        public IEnumerable<DataFields> AcceptQuery(IQuery query)
        {
            using (var connection = MakeConnection())
            using (var command = new SqliteCommand(query.AsString(), connection))
            {
                command.Parameters.AddRange((SqliteParameter[])query.InjectionProtection.Parameters);
                var rows = new List<object[]>();
                try
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        object[] currentRow = new object[reader.FieldCount];
                        reader.GetValues(currentRow);
                        rows.Add(currentRow);
                    }
                }
                catch { }

                connection.Close();

                return rows.Select(row => FieldConverter.ConvertToFields(query, row));
            }
        }

        public static SqliteConnection MakeConnection()
        {
            if (!UsingWinSqlite3)
            {
                SqliteEngine.UseWinSqlite3();
                UsingWinSqlite3 = true;
            }
            var connection = new SqliteConnection(
               (string)ApplicationData.Current.LocalSettings.Values["defaultConnectionString"]);
            connection.Open();
            return connection;
        }

        private static bool UsingWinSqlite3 { get; set; }
    }

    public sealed class SQLiteConnectionMaker : IMakeConnection
    {
        public IConnection MakeConnection() => new SQLiteConnection(new EveryFieldConverter());
    }

    class EveryFieldConverter : IConvertToFields
    {
        public DataFields ConvertToFields(IQuery query, object[] data)
        {
            return new DataFields(new Dictionary<string, object>
            {
                { "rowid", data[0] },
                { "username", data[1] },
                { "hashed_password", data[2] }
            });
        }
    }
}
