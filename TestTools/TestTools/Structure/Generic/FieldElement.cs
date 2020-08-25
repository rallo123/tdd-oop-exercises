using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public class FieldElement<TRoot, TValue> : FieldElement, IAccessible<TRoot, TValue>, IExtendable<TRoot>
    {
        public FieldElement(FieldInfo fieldInfo) : base(fieldInfo)
        {
        }

        public TValue Get(TRoot instance)
        {
            return (TValue)base.Get(instance);
        }

        public void Set(TRoot instance, TValue value)
        {
            base.Set(instance, value);
        }

        public FieldElement<TRoot, T> Field<T>(FieldOptions options) => Extendable.Field<TRoot, T>(this, options);
        public FieldStaticElement<TRoot, T> StaticField<T>(FieldOptions options) => Extendable.StaticField<TRoot, T>(this, options);

        public PropertyElement<TRoot, T> Property<T>(PropertyOptions options) => Extendable.Property<TRoot, T>(this, options);
        public PropertyStaticElement<TRoot, T> StaticProperty<T>(PropertyOptions options) => Extendable.StaticProperty<TRoot, T>(this, options);

        public new ActionMethodElement<TRoot> ActionMethod(MethodOptions options) => Extendable.ActionMethod<TRoot>(this, options);
        public ActionMethodElement<TRoot, T1> ActionMethod<T1>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1>(this, options);
        public ActionMethodElement<TRoot, T1, T2> ActionMethod<T1, T2>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1, T2>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3> ActionMethod<T1, T2, T3>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1, T2, T3>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4> ActionMethod<T1, T2, T3, T4>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<T1, T2, T3, T4, T5>(MethodOptions options) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4, T5>(this, options);

        public FuncMethodElement<TRoot, TResult> FuncMethod<TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, TResult> FuncMethod<T1, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, TResult> FuncMethod<T1, T2, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, T2, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, TResult> FuncMethod<T1, T2, T3, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, T2, T3, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, T4, TResult> FuncMethod<T1, T2, T3, T4, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<T1, T2, T3, T4, T5, TResult>(MethodOptions options) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, options);

        public new ActionMethodStaticElement<TRoot> StaticActionMethod(MethodOptions options) => Extendable.StaticActionMethod<TRoot>(this, options);
        public ActionMethodStaticElement<TRoot, T1> StaticActionMethod<T1>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2> StaticActionMethod<T1, T2>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1, T2>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3> StaticActionMethod<T1, T2, T3>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1, T2, T3>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4> StaticActionMethod<T1, T2, T3, T4>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1, T2, T3, T4>(this, options);
        public ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> StaticActionMethod<T1, T2, T3, T4, T5>(MethodOptions options) => Extendable.StaticActionMethod<TRoot, T1, T2, T3, T4, T5>(this, options);

        public FuncMethodStaticElement<TRoot, TResult> StaticFuncMethod<TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, TResult> StaticFuncMethod<T1, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, TResult> StaticFuncMethod<T1, T2, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, T2, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> StaticFuncMethod<T1, T2, T3, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, T2, T3, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> StaticFuncMethod<T1, T2, T3, T4, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, options);
        public FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> StaticFuncMethod<T1, T2, T3, T4, T5, TResult>(MethodOptions options) => Extendable.StaticFuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, options);
    }
}
