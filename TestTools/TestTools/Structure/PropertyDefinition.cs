using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace TestTools.Structure
{
    public class PropertyDefinition : ClassDefinition, IAccessible
    {
        public PropertyDefinition(PropertyInfo propertyInfo) : base(propertyInfo.PropertyType)
        {
            Info = propertyInfo;
        }

        public PropertyInfo Info { get; }
        public override string Name => Info.Name; 

        public object Get(object instance)
        {
            instance = GetValueOfPreviousDefinition(instance);

            return Info.GetValue(instance);
        }

        public void Set(object instance, object value)
        {
            instance = GetValueOfPreviousDefinition(instance);

            if (!Helper.IsOfType(value, Info.PropertyType))
            {
                string formattedValue = ObjectMethodRegistry.ToString(value);
                string formattedType = Helper.FormatType(Info.PropertyType);

                throw new AssertFailedException($"{formattedValue} is not of type {formattedType}");
            }

            Info.SetValue(instance, value);
        }
    }
}
