using System.Collections.Generic;

namespace persistence_component
{
    internal interface IFrom
    {
        IWhere From(string table);
    }

    internal interface IWhere
    {
        IWithInjectionProtection Where(string whereClause);
    }

    internal interface IWithInjectionProtection
    {
        IBuildQuery WithInjectionProtection(InjectionProtection protection);
    }

    internal interface IBuildQuery
    {
        IQuery BuildQuery();
    }

    public interface IQuery
    {
        IEnumerable<DataFields> RunOnConnection(IConnection connection);

        InjectionProtection InjectionProtection { get; }

        string AsString();
    }
}
