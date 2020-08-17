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

        FieldStaticElement<TRoot, T> StaticField<T>(string fieldName, FieldOptions options = null);

        PropertyStaticElement<TRoot, T> StaticProperty<T>(string propertyName, AccessorOptions get = null, AccessorOptions set = null);

        ActionMethodStaticElement<TRoot> StaticActionMethod(string methodName, MethodOptions options = null);
        ActionMethodStaticElement<TRoot, T1> StaticActionMethod<T1>(string methodName, MethodOptions options = null);
        ActionMethodStaticElement<TRoot, T1, T2> StaticActionMethod<T1, T2>(string methodName, MethodOptions options = null);
        ActionMethodStaticElement<TRoot, T1, T2, T3> StaticActionMethod<T1, T2, T3>(string methodName, MethodOptions options = null);
        ActionMethodStaticElement<TRoot, T1, T2, T3, T4> StaticActionMethod<T1, T2, T3, T4>(string methodName, MethodOptions options = null);
        ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> StaticActionMethod<T1, T2, T3, T4, T5>(string methodName, MethodOptions options = null);

        FuncMethodStaticElement<TRoot, TResult> StaticFuncMethod<TResult>(string methodName, MethodOptions options = null);
        FuncMethodStaticElement<TRoot, T1, TResult> StaticFuncMethod<T1, TResult>(string methodName, MethodOptions options = null);
        FuncMethodStaticElement<TRoot, T1, T2, TResult> StaticFuncMethod<T1, T2, TResult>(string methodName, MethodOptions options = null);
        FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> StaticFuncMethod<T1, T2, T3, TResult>(string methodName, MethodOptions options = null);
        FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> StaticFuncMethod<T1, T2, T3, T4, TResult>(string methodName, MethodOptions options = null);
        FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> StaticFuncMethod<T1, T2, T3, T4, T5, TResult>(string methodName, MethodOptions options = null);

        // TODO add static events
    }
}
