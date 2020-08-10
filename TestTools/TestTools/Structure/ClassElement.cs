using System;
using System.Reflection;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class ClassElement : Element, IExtendable
    {
        public ClassElement(Type type)
        {
            Type = type;
        }

        public Type Type { get; }

        public override string Name => FormatHelper.FormatType(Type);

        public FieldElement Field(string fieldName, Type fieldType = null, FieldOptions options = null) => Extendable.Field(this, fieldName, fieldType, options);
        public FieldStaticElement StaticField(string fieldName, Type fieldType = null, FieldOptions options = null) => Extendable.StaticField(this, fieldName, fieldType, options);

        public PropertyElement Property(string propertyName, Type propertyType = null, AccessorOptions get = null, AccessorOptions set = null) => Extendable.Property(this, propertyName, propertyType, get, set);
        public PropertyStaticElement StaticProperty(string propertyName, Type propertyType, AccessorOptions get = null, AccessorOptions set = null) => Extendable.StaticProperty(this, propertyName, propertyType, get, set);

        public ActionMethodElement ActionMethod(string methodName, Type[] parameterTypes, MethodOptions options = null) => Extendable.ActionMethod(this, methodName, parameterTypes, options);
        public ActionMethodStaticElement StaticActionMethod(string methodName, Type[] parameterTypes, MethodOptions options = null) => Extendable.StaticActionMethod(this, methodName, parameterTypes, options);

        public FuncMethodElement FuncMethod(string methodName, Type returnType, Type[] parameterTypes, MethodOptions options = null) => Extendable.FuncMethod(this, methodName, returnType, parameterTypes, options);
        public FuncMethodStaticElement StaticFuncMethod(string methodName, Type returnType, Type[] parameterTypes, MethodOptions options = null) => Extendable.StaticFuncMethod(this, methodName, returnType, parameterTypes, options);

        public ConstructorElement Constructor(Type[] parameterTypes, ConstructorOptions options = null)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, parameterTypes, options);
            return new ConstructorElement(constructorInfo) { PreviousElement = this };
        }
    }
}
