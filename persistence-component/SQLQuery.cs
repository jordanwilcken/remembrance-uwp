using System.Collections.Generic;

namespace persistence_component
{
    internal class SQLQuery : IQuery
    {
        public SQLQuery(
            string[] desiredColumns,
            string table,
            string whereClause,
            InjectionProtection injectionProtection)
        {
           QueryString = $@"
SELECT {string.Join(", ", desiredColumns)}
FROM {table}
{whereClause}
";

            InjectionProtection = injectionProtection;
        }

        public InjectionProtection InjectionProtection { get; }

        public IEnumerable<DataFields> RunOnConnection(IConnection connection)
        {
            return connection.AcceptQuery(this);
        }

        public string AsString() => QueryString;

        private string QueryString { get; }
    }
}