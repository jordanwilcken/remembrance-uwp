namespace persistence_component
{
    public sealed class InjectionProtection
    {
        public InjectionProtection(object parameters)
        {
            Parameters = parameters;
        }

        public object Parameters { get; }
    }
}