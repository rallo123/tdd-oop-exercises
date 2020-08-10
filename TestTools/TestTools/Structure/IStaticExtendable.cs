using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public interface IStaticExtendable : IElement
    {
        public Type Type { get; }

        public FieldStaticElement Field(string fieldName, Type fieldType = null, FieldOptions options = null);
        public FieldStaticElement StaticField(string fieldName, Type fieldType = null, FieldOptions options = null);

        public PropertyStaticElement Property(string propertyName, Type propertyType, AccessorOptions get = null, AccessorOptions set = null);
        public PropertyStaticElement StaticProperty(string propertyName, Type propertyType, AccessorOptions get = null, AccessorOptions set = null);

        public ActionMethodStaticElement ActionMethod(string methodName, Type[] parameterTypes, MethodOptions options = null);
        public ActionMethodStaticElement StaticActionMethod(string methodName, Type[] parameterTypes, MethodOptions options = null);

        public FuncMethodStaticElement FuncMethod(string methodName, Type returnType, Type[] parameterTypes, MethodOptions options = null);
        public FuncMethodStaticElement StaticFuncMethod(string methodName, Type returnType, Type[] parameterTypes, MethodOptions options = null);
    }
}
