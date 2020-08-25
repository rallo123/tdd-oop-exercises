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

        public object Get(object instance)
        {
            instance = GetValueOfPreviousElement(instance);
            return Info.GetValue(instance);
        }

        public void Set(object instance, object value)
        {
            instance = GetValueOfPreviousElement(instance);
            ReflectionHelper.SetValue(Info, instance, value);
        }

        public FieldElement Field(FieldOptions options) => Extendable.Field(this, options);
        public FieldStaticElement StaticField(FieldOptions options) => Extendable.StaticField(this, options);

        public PropertyElement Property(PropertyOptions options) => Extendable.Property(this, options);
        public PropertyStaticElement StaticProperty(PropertyOptions options) => Extendable.StaticProperty(this, options);

        public ActionMethodElement ActionMethod(MethodOptions options) => Extendable.ActionMethod(this, options);
        public ActionMethodStaticElement StaticActionMethod(MethodOptions options) => Extendable.StaticActionMethod(this, options);
        public FuncMethodElement FuncMethod(MethodOptions options) => Extendable.FuncMethod(this, options);
        public FuncMethodStaticElement StaticFuncMethod(MethodOptions options) => Extendable.StaticFuncMethod(this, options);
    }
}
