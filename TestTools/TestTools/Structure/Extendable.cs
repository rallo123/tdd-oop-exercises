using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace TestTools.Helpers
{
    public static class Extendable
    {
        public static FieldElement Field(IExtendable instance, FieldOptions options)
        {
            FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(instance.Type, options, isStatic: false);
            return new FieldElement(fieldInfo) { PreviousElement = instance };
        }

        public static PropertyElement Property(IExtendable instance, PropertyOptions options)
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetPropertyInfo(instance.Type, options, isStatic: false);
            return new PropertyElement(propertyInfo) { PreviousElement = instance };
        }

        public static ActionMethodElement ActionMethod(IExtendable instance, MethodOptions options)
        {
            options.ReturnType = typeof(void);

            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(instance.Type, options, isStatic: false);
            return new ActionMethodElement(methodInfo) { PreviousElement = instance };
        }

        public static FuncMethodElement FuncMethod(IExtendable instance, MethodOptions options)
        {
            if (options.ReturnType == typeof(void))
                throw new ArgumentException("INTERNAL: FuncMethod is not intended for void methods. Use ActionMethod instead");

            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(instance.Type, options, isStatic: false);
            return new FuncMethodElement(methodInfo) { PreviousElement = instance };
        }
    }
}
