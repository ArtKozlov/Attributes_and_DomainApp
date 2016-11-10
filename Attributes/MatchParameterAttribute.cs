using System;

namespace Attributes
{
    // Should be applied to .ctors.
    // Matches a .ctor parameter with property. Needs to get a default value from property field, and use this value for calling .ctor.
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = true)]
    public class MatchParameterWithPropertyAttribute : Attribute
    {
        public string ParametrName { get; set; }
        public string PropertyName { get; set; }
        public MatchParameterWithPropertyAttribute(string parametrName, string propertyName)
        {
            ParametrName = parametrName;
            PropertyName = propertyName;
        }
    }
}
