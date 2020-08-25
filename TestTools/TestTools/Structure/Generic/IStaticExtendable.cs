using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public interface IStaticExtendable<TRoot> : IElement
    {
        Type Type { get; }

        FieldStaticElement<TRoot, T> StaticField<T>(FieldOptions options);

        PropertyStaticElement<TRoot, T> StaticProperty<T>(PropertyOptions options);

        ActionMethodStaticElement<TRoot> StaticActionMethod(MethodOptions options);
        ActionMethodStaticElement<TRoot, T1> StaticActionMethod<T1>(MethodOptions options);
        ActionMethodStaticElement<TRoot, T1, T2> StaticActionMethod<T1, T2>(MethodOptions option);
        ActionMethodStaticElement<TRoot, T1, T2, T3> StaticActionMethod<T1, T2, T3>(MethodOptions options);
        ActionMethodStaticElement<TRoot, T1, T2, T3, T4> StaticActionMethod<T1, T2, T3, T4>(MethodOptions options);
        ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> StaticActionMethod<T1, T2, T3, T4, T5>(MethodOptions options);

        FuncMethodStaticElement<TRoot, TResult> StaticFuncMethod<TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, TResult> StaticFuncMethod<T1, TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, T2, TResult> StaticFuncMethod<T1, T2, TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> StaticFuncMethod<T1, T2, T3, TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> StaticFuncMethod<T1, T2, T3, T4, TResult>(MethodOptions options);
        FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> StaticFuncMethod<T1, T2, T3, T4, T5, TResult>(MethodOptions options);

        // TODO add static events
    }
}
