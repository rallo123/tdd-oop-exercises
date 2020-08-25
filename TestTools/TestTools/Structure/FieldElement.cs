using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class FieldElement : Element, IAccessible, IExtendable
    {
        public FieldElement(FieldInfo fieldInfo)
        {
            Info = fieldInfo;
        }

        public FieldInfo Info { get; }
        public override string Name => Info.Name;
        public Type Type => Info.FieldType;

        public object Get(object instance)
        {
            instance = GetValueOfPreviousElement(instance);
            return ReflectionHelper.GetValue(Info, instance);
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
