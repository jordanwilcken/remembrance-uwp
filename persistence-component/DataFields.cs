using System.Collections.Generic;

namespace persistence_component
{
    public sealed class DataFields
    {
        public DataFields(object fields)
        {
            Fields = (Dictionary<string, object>)fields;
        }

        //Will take any fieldName including null
        public Result Get(string fieldName)
        {
            return Fields.ContainsKey(fieldName)
                ? new Result(Fields[fieldName])
                : new Result("nope");
        }

        private Dictionary<string, object> Fields { get; }
    }
}