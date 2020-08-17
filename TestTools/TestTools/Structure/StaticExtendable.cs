using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Structure;
using TestTools.Structure.Generic;

namespace TestTools.Helpers
{
    public static class StaticExtendable
    {
        // Class members (Non-generic)
        public static FieldStaticElement Field(IStaticExtendable instance, string fieldName, Type fieldType, FieldOptions options)
        {
            FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(instance.Type, fieldName, fieldType, options, isStatic: false);
            return new FieldStaticElement(fieldInfo) { PreviousElement = instance };
        }
        public static FieldStaticElement StaticField(IStaticExtendable instance, string fieldName, Type fieldType, FieldOptions options)
        {
            FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(instance.Type, fieldName, fieldType, options, isStatic: true);
            return new FieldStaticElement(fieldInfo) { PreviousElement = instance };
        }

        public static PropertyStaticElement Property(IStaticExtendable instance, string propertyName, Type propertyType, AccessorOptions get, AccessorOptions set)
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetPropertyInfo(instance.Type, propertyName, propertyType, get, set, isStatic: false);
            return new PropertyStaticElement(propertyInfo) { PreviousElement = instance };
        }
        public static PropertyStaticElement StaticProperty(IStaticExtendable instance, string propertyName, Type propertyType, AccessorOptions get, AccessorOptions set)
        {
            PropertyInfo propertyInfo = ReflectionHelper.GetPropertyInfo(instance.Type, propertyName, propertyType, get, set, isStatic: true);
            return new PropertyStaticElement(propertyInfo) { PreviousElement = instance };
        }

        public static ActionMethodStaticElement ActionMethod(IStaticExtendable instance, string methodName, Type[] parameterTypes, MethodOptions options)
        {
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(instance.Type, methodName, typeof(void), parameterTypes, options, isStatic: false);
            return new ActionMethodStaticElement(methodInfo) { PreviousElement = instance };
        }
        public static ActionMethodStaticElement StaticActionMethod(IStaticExtendable instance, string methodName, Type[] parameterTypes, MethodOptions options)
        {
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(instance.Type, methodName, typeof(void), parameterTypes, options, isStatic: true);
            return new ActionMethodStaticElement(methodInfo) { PreviousElement = instance };
        }

        public static FuncMethodStaticElement FuncMethod(IStaticExtendable instance, string methodName, Type returnType, Type[] parameterTypes, MethodOptions options)
        {
            if (returnType == typeof(void))
                throw new ArgumentException("INTERNAL: FuncMethod is not intended for void methods. Use ActionMethod instead");

            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(instance.Type, methodName, returnType, parameterTypes, options, isStatic: false);
            return new FuncMethodStaticElement(methodInfo) { PreviousElement = instance };
        }
        public static FuncMethodStaticElement StaticFuncMethod(IStaticExtendable instance, string methodName, Type returnType, Type[] parameterTypes, MethodOptions options)
        {
            if (returnType == typeof(void))
                throw new ArgumentException("INTERNAL: StaticFuncMethod is not intended for void return type. Use StaticActionMethod instead");

            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(instance.Type, methodName, returnType, parameterTypes, options, isStatic: true);
            return new FuncMethodStaticElement(methodInfo) { PreviousElement = instance };
        }

        // Class member (Generic)
        
    }
}
