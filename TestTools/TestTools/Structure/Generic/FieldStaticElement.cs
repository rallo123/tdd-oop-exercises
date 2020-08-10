using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public class FieldStaticElement<TRoot, TValue> : FieldStaticElement, IStaticAccessible<TValue>, IStaticExtendable<TRoot>
    {
        public FieldStaticElement(FieldInfo fieldInfo) : base(fieldInfo)
        {
        }

        public new TValue Get()
        {
            return (TValue)base.Get();
        }

        public void Set(TValue value)
        {
            base.Set(value);
        }
        
        public FieldStaticElement<TRoot, T> Field<T>(string fieldName, FieldOptions options = null) => StaticExtendable.Field<TRoot, T>(this, fieldName, options);
        public FieldStaticElement<TRoot, T> StaticField<T>(string fieldName, FieldOptions options = null) => StaticExtendable.StaticField<TRoot, T>(this, fieldName, options);

        public PropertyStaticElement<TRoot, T> Property<T>(string propertyName, AccessorOptions get = null, AccessorOptions set = null) => StaticExtendable.Property<TRoot, T>(this, propertyName, get, set);
        public PropertyStaticElement<TRoot, T> StaticProperty<T>(string propertyName, AccessorOptions get = null, AccessorOptions set = null) => StaticExtendable.StaticProperty<TRoot, T>(this, propertyName, get, set);

        public ActionMethodStaticElement<TRoot> ActionMethod(string methodName, MethodOptions options = null) => StaticExtendable.ActionMethod<TRoot>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1> ActionMethod<T1>(string methodName, MethodOptions options = null) => StaticExtendable.ActionMethod<TRoot, T1>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2> ActionMethod<T1, T2>(string methodName, MethodOptions options = null) => StaticExtendable.ActionMethod<TRoot, T1, T2>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3> ActionMethod<T1, T2, T3>(string methodName, MethodOptions options = null) => StaticExtendable.ActionMethod<TRoot, T1, T2, T3>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4> ActionMethod<T1, T2, T3, T4>(string methodName, MethodOptions options = null) => StaticExtendable.ActionMethod<TRoot, T1, T2, T3, T4>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<T1, T2, T3, T4, T5>(string methodName, MethodOptions options = null) => StaticExtendable.ActionMethod<TRoot, T1, T2, T3, T4, T5>(this, methodName, options);

        public FuncMethodStaticElement<TRoot, TResult> FuncMethod<TResult>(string methodName, MethodOptions options = null) => StaticExtendable.FuncMethod<TRoot, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, TResult> FuncMethod<T1, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.FuncMethod<TRoot, T1, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, TResult> FuncMethod<T1, T2, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.FuncMethod<TRoot, T1, T2, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> FuncMethod<T1, T2, T3, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.FuncMethod<TRoot, T1, T2, T3, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> FuncMethod<T1, T2, T3, T4, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.FuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<T1, T2, T3, T4, T5, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.FuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, methodName, options);

        public ActionMethodStaticElement<TRoot> StaticActionMethod(string methodName, MethodOptions options = null) => StaticExtendable.StaticActionMethod<TRoot>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1> StaticActionMethod<T1>(string methodName, MethodOptions options = null) => StaticExtendable.StaticActionMethod<TRoot, T1>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2> StaticActionMethod<T1, T2>(string methodName, MethodOptions options = null) => StaticExtendable.StaticActionMethod<TRoot, T1, T2>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3> StaticActionMethod<T1, T2, T3>(string methodName, MethodOptions options = null) => StaticExtendable.StaticActionMethod<TRoot, T1, T2, T3>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4> StaticActionMethod<T1, T2, T3, T4>(string methodName, MethodOptions options = null) => StaticExtendable.StaticActionMethod<TRoot, T1, T2, T3, T4>(this, methodName, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> StaticActionMethod<T1, T2, T3, T4, T5>(string methodName, MethodOptions options = null) => StaticExtendable.StaticActionMethod<TRoot, T1, T2, T3, T4, T5>(this, methodName, options);

        public FuncMethodStaticElement<TRoot, TResult> StaticFuncMethod<TResult>(string methodName, MethodOptions options = null) => StaticExtendable.StaticFuncMethod<TRoot, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, TResult> StaticFuncMethod<T1, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.StaticFuncMethod<TRoot, T1, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, TResult> StaticFuncMethod<T1, T2, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.StaticFuncMethod<TRoot, T1, T2, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> StaticFuncMethod<T1, T2, T3, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.StaticFuncMethod<TRoot, T1, T2, T3, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> StaticFuncMethod<T1, T2, T3, T4, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, methodName, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> StaticFuncMethod<T1, T2, T3, T4, T5, TResult>(string methodName, MethodOptions options = null) => StaticExtendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, methodName, options);
    }
}
