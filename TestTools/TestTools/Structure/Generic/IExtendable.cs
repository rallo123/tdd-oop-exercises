using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public interface IExtendable<TRoot> : IExtendable
    {
        FieldElement<TRoot, T> Field<T>(FieldOptions options);
        FieldStaticElement<TRoot, T> StaticField<T>(FieldOptions options);

        PropertyElement<TRoot, T> Property<T>(PropertyOptions options);
        PropertyStaticElement<TRoot, T> StaticProperty<T>(PropertyOptions options);

        new ActionMethodElement<TRoot> ActionMethod(MethodOptions options);
        ActionMethodElement<TRoot, T1> ActionMethod<T1>(MethodOptions options);
        ActionMethodElement<TRoot, T1, T2> ActionMethod<T1, T2>(MethodOptions options);
        ActionMethodElement<TRoot, T1, T2, T3> ActionMethod<T1, T2, T3>(MethodOptions options);
        ActionMethodElement<TRoot, T1, T2, T3, T4> ActionMethod<T1, T2, T3, T4>(MethodOptions options);
        ActionMethodElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<T1, T2, T3, T4, T5>(MethodOptions options);

        FuncMethodElement<TRoot, TResult> FuncMethod<TResult>(MethodOptions options);
        FuncMethodElement<TRoot, T1, TResult> FuncMethod<T1, TResult>(MethodOptions options);
        FuncMethodElement<TRoot, T1, T2, TResult> FuncMethod<T1, T2, TResult>(MethodOptions options);
        FuncMethodElement<TRoot, T1, T2, T3, TResult> FuncMethod<T1, T2, T3, TResult>(MethodOptions options);
        FuncMethodElement<TRoot, T1, T2, T3, T4, TResult> FuncMethod<T1, T2, T3, T4, TResult>(MethodOptions options);
        FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<T1, T2, T3, T4, T5, TResult>(MethodOptions options);

        new ActionMethodStaticElement<TRoot> StaticActionMethod(MethodOptions options);
        ActionMethodStaticElement<TRoot, T1> StaticActionMethod<T1>(MethodOptions options);
        ActionMethodStaticElement<TRoot, T1, T2> StaticActionMethod<T1, T2>(MethodOptions options);
        ActionMethodStaticElement<TRoot, T1, T2, T3> StaticActionMethod<T1, T2, T3>(MethodOptions options);
        ActionMethodStaticElement<TRoot, T1, T2, T3, T4> StaticActionMethod<T1, T2, T3, T4>(MethodOptions options);
        ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> StaticActionMethod<T1, T2, T3, T4, T5>(MethodOptions options);

        FuncMethodStaticElement<TRoot, TResult> StaticFuncMethod<TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, TResult> StaticFuncMethod<T1, TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, T2, TResult> StaticFuncMethod<T1, T2, TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> StaticFuncMethod<T1, T2, T3, TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> StaticFuncMethod<T1, T2, T3, T4, TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> StaticFuncMethod<T1, T2, T3, T4, T5, TResult>(MethodOptions options);

        // TODO add events
    }
}
