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
        public FieldElement StaticField(FieldOptions options) => Extendable.StaticField(this, options);

        public PropertyElement Property(PropertyOptions options) => Extendable.Property(this, options);
        public PropertyElement StaticProperty(PropertyOptions options) => Extendable.StaticProperty(this, options);

        public ActionMethodElement ActionMethod(MethodOptions options) => Extendable.ActionMethod(this, options);
        public ActionMethodElement StaticActionMethod(MethodOptions options) => Extendable.StaticActionMethod(this, options);

        public FuncMethodElement FuncMethod(MethodOptions options) => Extendable.FuncMethod(this, options);
        public FuncMethodElement StaticFuncMethod(MethodOptions options) => Extendable.StaticFuncMethod(this, options);

        public ConstructorElement Constructor(ConstructorOptions options)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, options);
            return new ConstructorElement(constructorInfo) { PreviousElement = this };
        }
    }
}
