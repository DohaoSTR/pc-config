namespace PCConfig.Model
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    internal sealed class DatabaseValueAttribute : Attribute
    {
        public string Value { get; }

        public DatabaseValueAttribute(string value)
        {
            Value = value;
        }
    }
}
