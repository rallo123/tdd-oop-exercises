using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class ClassElement : Element, IExtendable
    {
        public ClassElement(Type type, ClassOptions options = null)
        {
            Type = type;

            if (options?.BaseType != null && options.BaseType != Type.BaseType)
                throw new AssertFailedException("Wrong base");
            if (options?.IsAbstract != null && options.IsAbstract != Type.IsAbstract)
                throw new AssertFailedException("Wrong abstract");
        }

        public Type Type { get; }

        public override string Name => FormatHelper.FormatType(Type);

        public FieldElement Field(FieldOptions options) => Extendable.Field(this, options);
        public FieldElement StaticField(FieldOptions options) {
            FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(Type, options, isStatic: true);
            return new FieldElement(fieldInfo) { PreviousElement = this };
        }

        public PropertyElement Property(PropertyOptions options) => Extendable.Property(this, options);
        public PropertyElement StaticProperty(PropertyOptions options) {
            PropertyInfo propertyInfo = ReflectionHelper.GetPropertyInfo(Type, options, isStatic: true);
            return new PropertyElement(propertyInfo) { PreviousElement = this };
        }

        public ActionMethodElement ActionMethod(MethodOptions options) => Extendable.ActionMethod(this, options);
        public ActionMethodElement StaticActionMethod(MethodOptions options) {
            options.ReturnType = typeof(void);

            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(Type, options, isStatic: true);
            return new ActionMethodElement(methodInfo) { PreviousElement = this };
        }

        public FuncMethodElement FuncMethod(MethodOptions options) => Extendable.FuncMethod(this, options);
        public FuncMethodElement StaticFuncMethod(MethodOptions options)
        {
            if (options.ReturnType == typeof(void))
                throw new ArgumentException("INTERNAL: StaticFuncMethod is not intended for void return type. Use StaticActionMethod instead");

            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(Type, options, isStatic: true);
            return new FuncMethodElement(methodInfo) { PreviousElement = this };
        }

        public ConstructorElement Constructor(ConstructorOptions options)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement(constructorInfo) { PreviousElement = this };
        }
    }
}
