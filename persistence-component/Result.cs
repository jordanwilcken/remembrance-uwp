using persistence_component.PoorMansGenerics;

namespace persistence_component
{
    public sealed class Result
    {
        public string Error { get; }

        public object Value { get; }

        public Result(object val)
        {
            Value = val;
        }

        public Result(string error, object ignored)
        {
            Error = error;
        }

        public void Tee(IValueConsumer consumer)
        {
            if (Value != null)
            {
                consumer.Use(Value);
            }
        }
    }
}