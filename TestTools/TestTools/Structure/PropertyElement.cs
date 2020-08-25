using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class PropertyElement : Element, IAccessible, IExtendable
    {
        public PropertyElement(PropertyInfo propertyInfo)
        {
            Info = propertyInfo;
        }

        public PropertyInfo Info { get; }
        public override string Name => Info.Name;
        public Type Type => Info.PropertyType;

        public object Get() => Get(null);
        public object Get(object instance)
        {
            if (instance != null)
                instance = GetValueOfPreviousElement(instance);
            return Info.GetValue(instance);
        }

        public void Set(object value) => Set(null, value);
        public void Set(object instance, object value)
        {
            if (instance != null)
                instance = GetValueOfPreviousElement(instance);
            ReflectionHelper.SetValue(Info, instance, value);
        }

        public FieldElement Field(FieldOptions options) => Extendable.Field(this, options);

        public PropertyElement Property(PropertyOptions options) => Extendable.Property(this, options);

        public ActionMethodElement ActionMethod(MethodOptions options) => Extendable.ActionMethod(this, options);

        public FuncMethodElement FuncMethod(MethodOptions options) => Extendable.FuncMethod(this, options);
    }
}
