using System.Collections.Generic;

namespace persistence_component
{
    public interface IConnection
    {
        IEnumerable<DataFields> AcceptQuery(IQuery query);
    }
}