using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class ClassElement : Element, IExtendable
    {
        public ClassElement(Type type, ClassRequirements options = null)
        {
            Type = type;

            if (options?.BaseType != null && options.BaseType != Type.BaseType)
                throw new AssertFailedException("Wrong base");
            if (options?.IsAbstract != null && options.IsAbstract != Type.IsAbstract)
                throw new AssertFailedException("Wrong abstract");
        }

        public Type Type { get; }

        public override string Name => FormatHelper.FormatType(Type);

        public FieldElement Field(FieldRequirements options) => Extendable.Field(this, options);
        public FieldElement StaticField(FieldRequirements options) {
            FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(Type, options, isStatic: true);
            return new FieldElement(fieldInfo) { PreviousElement = this };
        }

        public PropertyElement Property(PropertyRequirements options) => Extendable.Property(this, options);
        public PropertyElement StaticProperty(PropertyRequirements options) {
            PropertyInfo propertyInfo = ReflectionHelper.GetPropertyInfo(Type, options, isStatic: true);
            return new PropertyElement(propertyInfo) { PreviousElement = this };
        }

        public ActionMethodElement ActionMethod(MethodRequirements options) => Extendable.ActionMethod(this, options);
        public ActionMethodElement StaticActionMethod(MethodRequirements options) {
            options.ReturnType = typeof(void);

            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(Type, options, isStatic: true);
            return new ActionMethodElement(methodInfo) { PreviousElement = this };
        }

        public FuncMethodElement FuncMethod(MethodRequirements options) => Extendable.FuncMethod(this, options);
        public FuncMethodElement StaticFuncMethod(MethodRequirements options)
        {
            if (options.ReturnType == typeof(void))
                throw new ArgumentException("INTERNAL: StaticFuncMethod is not intended for void return type. Use StaticActionMethod instead");

            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(Type, options, isStatic: true);
            return new FuncMethodElement(methodInfo) { PreviousElement = this };
        }

        public ConstructorElement Constructor(ConstructorRequirements options)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement(constructorInfo) { PreviousElement = this };
        }
    }
}
