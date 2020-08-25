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
        
        public FieldStaticElement<TRoot, T> Field<T>(FieldOptions options) => StaticExtendable.Field<TRoot, T>(this, options);
        public FieldStaticElement<TRoot, T> StaticField<T>(FieldOptions options) => StaticExtendable.StaticField<TRoot, T>(this, options);

        public PropertyStaticElement<TRoot, T> Property<T>(PropertyOptions options) => StaticExtendable.Property<TRoot, T>(this, options);
        public PropertyStaticElement<TRoot, T> StaticProperty<T>(PropertyOptions options) => StaticExtendable.StaticProperty<TRoot, T>(this, options);

        public new ActionMethodStaticElement<TRoot> ActionMethod(MethodOptions options) => StaticExtendable.ActionMethod<TRoot>(this, options);
        public ActionMethodStaticElement<TRoot, T1> ActionMethod<T1>(MethodOptions options) => StaticExtendable.ActionMethod<TRoot, T1>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2> ActionMethod<T1, T2>(MethodOptions options) => StaticExtendable.ActionMethod<TRoot, T1, T2>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3> ActionMethod<T1, T2, T3>(MethodOptions options) => StaticExtendable.ActionMethod<TRoot, T1, T2, T3>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4> ActionMethod<T1, T2, T3, T4>(MethodOptions options) => StaticExtendable.ActionMethod<TRoot, T1, T2, T3, T4>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<T1, T2, T3, T4, T5>(MethodOptions options) => StaticExtendable.ActionMethod<TRoot, T1, T2, T3, T4, T5>(this, options);

        public FuncMethodStaticElement<TRoot, TResult> FuncMethod<TResult>(MethodOptions options) => StaticExtendable.FuncMethod<TRoot, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, TResult> FuncMethod<T1, TResult>(MethodOptions options) => StaticExtendable.FuncMethod<TRoot, T1, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, TResult> FuncMethod<T1, T2, TResult>(MethodOptions options) => StaticExtendable.FuncMethod<TRoot, T1, T2, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> FuncMethod<T1, T2, T3, TResult>(MethodOptions options) => StaticExtendable.FuncMethod<TRoot, T1, T2, T3, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> FuncMethod<T1, T2, T3, T4, TResult>(MethodOptions options) => StaticExtendable.FuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<T1, T2, T3, T4, T5, TResult>(MethodOptions options) => StaticExtendable.FuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, options);

        public new ActionMethodStaticElement<TRoot> StaticActionMethod(MethodOptions options) => StaticExtendable.StaticActionMethod<TRoot>(this, options);
        public ActionMethodStaticElement<TRoot, T1> StaticActionMethod<T1>(MethodOptions options) => StaticExtendable.StaticActionMethod<TRoot, T1>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2> StaticActionMethod<T1, T2>(MethodOptions options) => StaticExtendable.StaticActionMethod<TRoot, T1, T2>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3> StaticActionMethod<T1, T2, T3>(MethodOptions options) => StaticExtendable.StaticActionMethod<TRoot, T1, T2, T3>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4> StaticActionMethod<T1, T2, T3, T4>(MethodOptions options) => StaticExtendable.StaticActionMethod<TRoot, T1, T2, T3, T4>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> StaticActionMethod<T1, T2, T3, T4, T5>(MethodOptions options) => StaticExtendable.StaticActionMethod<TRoot, T1, T2, T3, T4, T5>(this, options);

        public FuncMethodStaticElement<TRoot, TResult> StaticFuncMethod<TResult>(MethodOptions options) => StaticExtendable.StaticFuncMethod<TRoot, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, TResult> StaticFuncMethod<T1, TResult>(MethodOptions options) => StaticExtendable.StaticFuncMethod<TRoot, T1, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, TResult> StaticFuncMethod<T1, T2, TResult>(MethodOptions options) => StaticExtendable.StaticFuncMethod<TRoot, T1, T2, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> StaticFuncMethod<T1, T2, T3, TResult>(MethodOptions options) => StaticExtendable.StaticFuncMethod<TRoot, T1, T2, T3, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> StaticFuncMethod<T1, T2, T3, T4, TResult>(MethodOptions options) => StaticExtendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> StaticFuncMethod<T1, T2, T3, T4, T5, TResult>(MethodOptions options) => StaticExtendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, options);
    }
}
