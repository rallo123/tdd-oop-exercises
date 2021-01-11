using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public interface IExtendable<TRoot> : IExtendable
    {
        FieldElement<TRoot, T> Field<T>(FieldRequirements options);

        PropertyElement<TRoot, T> Property<T>(PropertyRequirements options);

        new ActionMethodElement<TRoot> ActionMethod(MethodRequirements options);
        ActionMethodElement<TRoot, T1> ActionMethod<T1>(MethodRequirements options);
        ActionMethodElement<TRoot, T1, T2> ActionMethod<T1, T2>(MethodRequirements options);
        ActionMethodElement<TRoot, T1, T2, T3> ActionMethod<T1, T2, T3>(MethodRequirements options);
        ActionMethodElement<TRoot, T1, T2, T3, T4> ActionMethod<T1, T2, T3, T4>(MethodRequirements options);
        ActionMethodElement<TRoot, T1, T2, T3, T4, T5> ActionMethod<T1, T2, T3, T4, T5>(MethodRequirements options);

        FuncMethodElement<TRoot, TResult> FuncMethod<TResult>(MethodRequirements options);
        FuncMethodElement<TRoot, T1, TResult> FuncMethod<T1, TResult>(MethodRequirements options);
        FuncMethodElement<TRoot, T1, T2, TResult> FuncMethod<T1, T2, TResult>(MethodRequirements options);
        FuncMethodElement<TRoot, T1, T2, T3, TResult> FuncMethod<T1, T2, T3, TResult>(MethodRequirements options);
        FuncMethodElement<TRoot, T1, T2, T3, T4, TResult> FuncMethod<T1, T2, T3, T4, TResult>(MethodRequirements options);
        FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult> FuncMethod<T1, T2, T3, T4, T5, TResult>(MethodRequirements options);

        // TODO add events
    }
}
