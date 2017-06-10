using System;

namespace persistence_component
{
    /// <summary>
    /// Abstraction for building database queries.
    /// NOT guaranteed to build a query that is valid SQL.
    /// Intended to shield consumers from the world of connections and readers.
    /// </summary>
    internal class QueryBuilder : IFrom, IWhere, IWithInjectionProtection, IBuildQuery
    {
        public QueryBuilder()
        {
        }

        public IFrom GetColumns(string[] columnNames)
        {
            return new QueryBuilder(columnNames);
        }

        public IWhere From(string table)
        {
            return new QueryBuilder(DesiredColumns, table);
        }

        public IWithInjectionProtection Where(string whereClause)
        {
            return new QueryBuilder(DesiredColumns, Table, "WHERE " + whereClause);
        }

        public IBuildQuery WithInjectionProtection(InjectionProtection injectionProtection)
        {
            return new QueryBuilder(DesiredColumns, Table, WhereClause, injectionProtection);
        }

        public IQuery BuildQuery()
        {
            return new SQLQuery(
                DesiredColumns,
                Table,
                WhereClause,
                InjectionProtection);
        }

        private string[] DesiredColumns { get; }
        private string Table { get; }
        private string WhereClause { get; }
        private InjectionProtection InjectionProtection { get; }

        private QueryBuilder(string[] desiredColumns)
        {
            DesiredColumns = desiredColumns;
        }

        private QueryBuilder(string[] desiredColumns, string table)
            : this(desiredColumns)
        {
            Table = table;
        }

        private QueryBuilder(string[] desiredColumns, string table, string whereClause)
            : this(desiredColumns, table)
        {
            WhereClause = whereClause;
        }

        private QueryBuilder(string[] desiredColumns, string table, string whereClause, InjectionProtection injectionProtection)
            : this(desiredColumns, table, whereClause)
        {
            InjectionProtection = injectionProtection;
        }
    }
}