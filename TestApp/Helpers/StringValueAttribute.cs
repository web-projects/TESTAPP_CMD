using System;
using System.Linq;
using System.Reflection;

namespace TestApp.Helpers
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class StringValueAttribute : Attribute
    {
        public string Value { get; }

        public StringValueAttribute(string value) => (Value) = (value);

        public static string GetStringValue(Enum value)
        {
            if (value is null)
            {
                return string.Empty;
            }

            Type type = value.GetType();
            FieldInfo fi = type.GetRuntimeField(value.ToString());
            return (fi.GetCustomAttributes(typeof(StringValueAttribute), false).FirstOrDefault() as StringValueAttribute).Value;
        }
    }
}
