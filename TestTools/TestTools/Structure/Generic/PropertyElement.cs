using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public class PropertyElement<TRoot, TValue> : PropertyElement, IAccessible<TRoot, TValue>, IExtendable<TRoot>
    {
        public PropertyElement(PropertyInfo propertyInfo) : base(propertyInfo)
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

        public FieldElement<TRoot, T> Field<T>(FieldRequirements options) => Extendable.Field<TRoot, T>(this, options);

        public PropertyElement<TRoot, T> Property<T>(PropertyRequirements options) => Extendable.Property<TRoot, T>(this, options);

        public new ActionMethodElement<TRoot> ActionMethod(MethodRequirements options) => Extendable.ActionMethod<TRoot>(this, options);
        public ActionMethodElement<TRoot, T1> ActionMethod<T1>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1>(this, options);
        public ActionMethodElement<TRoot, T1, T2> ActionMethod<T1, T2>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1, T2>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3> ActionMethod<T1, T2, T3>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1, T2, T3>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4> ActionMethod<T1, T2, T3, T4>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4>(this, options);
        public ActionMethodElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<T1, T2, T3, T4, T5>(MethodRequirements options) => Extendable.ActionMethod<TRoot, T1, T2, T3, T4, T5>(this, options);

        public FuncMethodElement<TRoot, TResult> FuncMethod<TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, TResult> FuncMethod<T1, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, TResult> FuncMethod<T1, T2, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, T2, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, TResult> FuncMethod<T1, T2, T3, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, T2, T3, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, T4, TResult> FuncMethod<T1, T2, T3, T4, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, TResult>(this, options);
        public FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<T1, T2, T3, T4, T5, TResult>(MethodRequirements options) => Extendable.FuncMethod<TRoot, T1, T2, T3, T4, T5, TResult>(this, options);
    }
}
