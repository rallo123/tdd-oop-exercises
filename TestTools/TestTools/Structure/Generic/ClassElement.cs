using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using TestTools.Helpers;


namespace TestTools.Structure.Generic
{
    public class ClassElement<TRoot> : ClassElement, IExtendable<TRoot>
    {
        public ClassElement() : base(typeof(TRoot))
        {
        }

        public FieldElement<TRoot, T> Field<T>(string fieldName, FieldOptions options = null) => Extendable.Field<TRoot, T>(this, fieldName, options);
        public FieldStaticElement<TRoot, T> StaticField<T>(string fieldName, FieldOptions options = null) => Extendable.StaticField<TRoot, T>(this, fieldName, options);

        public PropertyElement<TRoot, T> Property<T>(string propertyName, AccessorOptions get = null, AccessorOptions set = null) => Extendable.Property<TRoot, T>(this, propertyName, get, set);
        public PropertyStaticElement<TRoot, T> StaticProperty<T>(string propertyName, AccessorOptions get = null, AccessorOptions set = null) => Extendable.StaticProperty<TRoot, T>(this, propertyName, get, set);

        public ActionMethodElement<TRoot> ActionMethod(string methodName, MethodOptions options = null) => Extendable.ActionMethod<TRoot>(this, methodName, options);
        public ActionMethodElement<TRoot, T1> ActionMethod<T1>(string methodName, MethodOptions options = null) => Extendable.ActionMethod<TRoot, T1>(this, methodName, options);
        public ActionMethodElement<TRoot, T1, T2> ActionMethod<T1, T2>(string methodName, MethodOptions options = null) => Extendable.ActionMethod<TRoot, T1, T2>(this, methodName, options);
        public ActionMethodElement<TRoot, T1, T2, T3> ActionMethod<T1, T2, T3>(string methodName, MethodOptions options = null) => Extendable.ActionMethod<TRoot, T1, T2, T3>(this, methodName, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4> ActionMethod<T1, T2, T3, T4>(string methodName, MethodOptions options = null) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4>(this, methodName, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<T1, T2, T3, T4, T5>(string methodName, MethodOptions options = null) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4, T5>(this, methodName, options);

        public FuncMethodElement<TRoot, TResult> FuncMethod<TResult>(string methodName, MethodOptions options = null) => Extendable.FuncMethod<TRoot, TResult>(this, methodName, options);
        public FuncMethodDefinition<TRoot, T1, TResult> FuncMethod<T1, TResult>(string methodName, MethodOptions options = null) => Extendable.FuncMethod<TRoot, T1, TResult>(this, methodName, options);
        public FuncMethodDefinition<TRoot, T1, T2, TResult> FuncMethod<T1, T2, TResult>(string methodName, MethodOptions options = null) => Extendable.FuncMethod<TRoot, T1, T2, TResult>(this, methodName, options);
        public FuncMethodDefinition<TRoot, T1, T2, T3, TResult> FuncMethod<T1, T2, T3, TResult>(string methodName, MethodOptions options = null) => Extendable.FuncMethod<TRoot, T1, T2, T3, TResult>(this, methodName, options);
        public FuncMethodDefinition<TRoot, T1, T2, T3, T4, TResult> FuncMethod<T1, T2, T3, T4, TResult>(string methodName, MethodOptions options = null) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, methodName, options);
        public FuncMethodDefinition<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<T1, T2, T3, T4, T5, TResult>(string methodName, MethodOptions options = null) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, methodName, options);

        public ActionMethodStaticElement<TRoot> StaticActionMethod(string methodName, MethodOptions options = null) => Extendable.StaticActionMethod<TRoot>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1> StaticActionMethod<T1>(string methodName, MethodOptions options = null) => Extendable.StaticActionMethod<TRoot, T1>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2> StaticActionMethod<T1, T2>(string methodName, MethodOptions options = null) => Extendable.StaticActionMethod<TRoot, T1, T2>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3> StaticActionMethod<T1, T2, T3>(string methodName, MethodOptions options = null) => Extendable.StaticActionMethod<TRoot, T1, T2, T3>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4> StaticActionMethod<T1, T2, T3, T4>(string methodName, MethodOptions options = null) => Extendable.StaticActionMethod<TRoot, T1, T2, T3, T4>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> StaticActionMethod<T1, T2, T3, T4, T5>(string methodName, MethodOptions options = null) => Extendable.StaticActionMethod<TRoot, T1, T2, T3, T4, T5>(this, methodName, options);

        public FuncMethodStaticElement<TRoot, TResult> StaticFuncMethod<TResult>(string methodName, MethodOptions options = null) => Extendable.StaticFuncMethod<TRoot, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, TResult> StaticFuncMethod<T1, TResult>(string methodName, MethodOptions options = null) => Extendable.StaticFuncMethod<TRoot, T1, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, TResult> StaticFuncMethod<T1, T2, TResult>(string methodName, MethodOptions options = null) => Extendable.StaticFuncMethod<TRoot, T1, T2, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> StaticFuncMethod<T1, T2, T3, TResult>(string methodName, MethodOptions options = null) => Extendable.StaticFuncMethod<TRoot, T1, T2, T3, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> StaticFuncMethod<T1, T2, T3, T4, TResult>(string methodName, MethodOptions options = null) => Extendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> StaticFuncMethod<T1, T2, T3, T4, T5, TResult>(string methodName, MethodOptions options = null) => Extendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, methodName, options);
        
        public ConstructorElement<TRoot> Constructor(ConstructorOptions options = null)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(typeof(TRoot), options);
            return new ConstructorElement<TRoot>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1> Constructor<T1>(ConstructorOptions options = null)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, new Type[] { typeof(T1) }, options);
            return new ConstructorElement<TRoot, T1>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2> Constructor<T1, T2>(ConstructorOptions options = null)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, new Type[] { typeof(T1), typeof(T2) }, options);
            return new ConstructorElement<TRoot, T1, T2>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2, T3> Constructor<T1, T2, T3>(ConstructorOptions options = null)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, new Type[] { typeof(T1), typeof(T2), typeof(T3) }, options);
            return new ConstructorElement<TRoot, T1, T2, T3>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2, T3, T4> Constructor<T1, T2, T3, T4>(ConstructorOptions options = null)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) }, options);
            return new ConstructorElement<TRoot, T1, T2, T3, T4>(constructorInfo);
        }
        public ConstructorElement<TRoot, T1, T2, T3, T4, T5> Constructor<T1, T2, T3, T4, T5>(ConstructorOptions options = null)
        {
            ConstructorInfo constructorInfo = ReflectionHelper.GetConstructorInfo(Type, new Type[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) }, options);
            return new ConstructorElement<TRoot, T1, T2, T3, T4, T5>(constructorInfo);
        }
    }
}
