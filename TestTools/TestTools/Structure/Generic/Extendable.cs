using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public static class Extendable
    {
        public static FieldElement<TRoot, T> Field<TRoot, T>(IExtendable<TRoot> instance, FieldRequirements options)
        {
            options.FieldType = typeof(T);
            FieldInfo fieldInfo = ReflectionHelper.GetFieldInfo(typeof(TRoot), options, isStatic: false);
            return new FieldElement<TRoot, T>(fieldInfo) { PreviousElement = instance };
        }

        public static PropertyElement<TRoot, T> Property<TRoot, T>(IExtendable<TRoot> instance, PropertyRequirements options)
        {
            options.PropertyType = typeof(T);
            PropertyInfo propertyInfo = ReflectionHelper.GetPropertyInfo(typeof(TRoot), options, isStatic: false);
            return new PropertyElement<TRoot, T>(propertyInfo) { PreviousElement = instance };
        }

        public static ActionMethodElement<TRoot> ActionMethod<TRoot>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[0]);
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new ActionMethodElement<TRoot>(methodInfo) { PreviousElement = instance };
        }
        public static ActionMethodElement<TRoot, T1> ActionMethod<TRoot, T1>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new ActionMethodElement<TRoot, T1>(methodInfo) { PreviousElement = instance };
        }
        public static ActionMethodElement<TRoot, T1, T2> ActionMethod<TRoot, T1, T2>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1), typeof(T2) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new ActionMethodElement<TRoot, T1, T2>(methodInfo) { PreviousElement = instance };
        }
        public static ActionMethodElement<TRoot, T1, T2, T3> ActionMethod<TRoot, T1, T2, T3>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1), typeof(T2), typeof(T3) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new ActionMethodElement<TRoot, T1, T2, T3>(methodInfo) { PreviousElement = instance };
        }
        public static ActionMethodElement<TRoot, T1, T2, T3, T4> ActionMethod<TRoot, T1, T2, T3, T4>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new ActionMethodElement<TRoot, T1, T2, T3, T4>(methodInfo) { PreviousElement = instance };
        }
        public static ActionMethodElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<TRoot, T1, T2, T3, T4, T5>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(void), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new ActionMethodElement<TRoot, T1, T2, T3, T4, T5>(methodInfo) { PreviousElement = instance };
        }

        public static FuncMethodElement<TRoot, TResult> FuncMethod<TRoot, TResult>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[0]);
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new FuncMethodElement<TRoot, TResult>(methodInfo) { PreviousElement = instance };
        }
        public static FuncMethodElement<TRoot, T1, TResult> FuncMethod<TRoot, T1, TResult>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new FuncMethodElement<TRoot, T1, TResult>(methodInfo) { PreviousElement = instance };
        }
        public static FuncMethodElement<TRoot, T1, T2, TResult> FuncMethod<TRoot, T1, T2, TResult>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1), typeof(T2) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new FuncMethodElement<TRoot, T1, T2, TResult>(methodInfo) { PreviousElement = instance };
        }
        public static FuncMethodElement<TRoot, T1, T2, T3, TResult> FuncMethod<TRoot, T1, T2, T3, TResult>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new FuncMethodElement<TRoot, T1, T2, T3, TResult>(methodInfo) { PreviousElement = instance };
        }
        public static FuncMethodElement<TRoot, T1, T2, T3, T4, TResult> FuncMethod<TRoot, T1, T2, T3, T4, TResult>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new FuncMethodElement<TRoot, T1, T2, T3, T4, TResult>(methodInfo) { PreviousElement = instance };
        }
        public static FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(IExtendable<TRoot> instance, MethodRequirements options)
        {
            options.OverwriteTypes(typeof(TResult), new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) });
            MethodInfo methodInfo = ReflectionHelper.GetMethodInfo(typeof(TRoot), options, isStatic: false);
            return new FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult>(methodInfo) { PreviousElement = instance };
        }
    }
}
