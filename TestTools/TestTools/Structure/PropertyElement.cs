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

        public FieldElement Field(FieldRequirements options) => Extendable.Field(this, options);

        public PropertyElement Property(PropertyRequirements options) => Extendable.Property(this, options);

        public ActionMethodElement ActionMethod(MethodRequirements options) => Extendable.ActionMethod(this, options);

        public FuncMethodElement FuncMethod(MethodRequirements options) => Extendable.FuncMethod(this, options);
    }
}
