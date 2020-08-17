using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class FieldStaticElement : Element, IStaticExtendable
    {
        public FieldStaticElement(FieldInfo fieldInfo)
        {
            Info = fieldInfo;
        }

        public FieldInfo Info { get; }
        public override string Name => Info.Name;
        public Type Type => Info.FieldType;

        public object Get()
        {
            throw new NotImplementedException();
        }
        
        public object Set(object value)
        {
            throw new NotImplementedException();
        }

        public FieldStaticElement Field(string fieldName, Type fieldType = null, FieldOptions options = null) => StaticExtendable.Field(this, fieldName, fieldType, options);
        public FieldStaticElement StaticField(string fieldName, Type fieldType = null, FieldOptions options = null) => StaticExtendable.StaticField(this, fieldName, fieldType, options);

        public PropertyStaticElement Property(string propertyName, Type propertyType, AccessorOptions get = null, AccessorOptions set = null) => StaticExtendable.Property(this, propertyName, propertyType, get, set);
        public PropertyStaticElement StaticProperty(string propertyName, Type propertyType, AccessorOptions get = null, AccessorOptions set = null) => StaticExtendable.StaticProperty(this, propertyName, propertyType, get, set);

        public ActionMethodStaticElement ActionMethod(string methodName, Type[] parameterTypes, MethodOptions options = null) => StaticExtendable.ActionMethod(this, methodName, parameterTypes, options);
        public FuncMethodStaticElement FuncMethod(string methodName, Type returnType, Type[] parameterTypes, MethodOptions options = null) => StaticExtendable.FuncMethod(this, methodName, returnType, parameterTypes, options);
        public ActionMethodStaticElement StaticActionMethod(string methodName, Type[] parameterTypes, MethodOptions options = null) => StaticExtendable.StaticActionMethod(this, methodName, parameterTypes, options);
        public FuncMethodStaticElement StaticFuncMethod(string methodName, Type returnType, Type[] parameterTypes, MethodOptions options = null) => StaticExtendable.StaticFuncMethod(this, methodName, returnType, parameterTypes, options);
    }
}
