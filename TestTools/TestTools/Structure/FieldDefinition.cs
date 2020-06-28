using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace TestTools.Structure
{
    public class FieldDefinition : ClassDefinition, IAccessible
    {
        public FieldDefinition(FieldInfo fieldInfo) : base(fieldInfo.FieldType)
        {
            Info = fieldInfo;
        }

        public FieldInfo Info { get; }
        public override string Name => Info.Name;

        public object Get(object instance)
        {
            instance = GetValueOfPreviousDefinition(instance);
            return Info.GetValue(instance);
        }

        public void Set(object instance, object value)
        {
            instance = GetValueOfPreviousDefinition(instance);

            if (!Helper.IsOfType(value, Info.FieldType))
            {
                string formattedValue = ObjectMethodRegistry.ToString(value);
                string formattedType = Helper.FormatType(Info.FieldType);
                throw new AssertFailedException($"{formattedValue} is not of type {formattedType}");
            }
            Info.SetValue(instance, value);
        }
    }
}
