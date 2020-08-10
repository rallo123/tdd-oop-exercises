using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Generic
{
    public interface IStaticFunc<TResult> : IStaticFunc
    {
        TResult Invoke();
    }

    public interface IStaticFunc<T1, TResult> : IStaticFunc
    {
        TResult Invoke(T1 par1);
    }

    public interface IStaticFunc<T1, T2, TResult> : IStaticFunc
    {
        TResult Invoke(T1 par1, T2 par2);
    }

    public interface IStaticFunc<T1, T2, T3, TResult> : IStaticFunc
    {
        TResult Invoke(T1 par1, T2 par2, T3 par3);
    }

    public interface IStaticFunc<T1, T2, T3, T4, TResult> : IStaticFunc
    {
        TResult Invoke(T1 par1, T2 par2, T3 par3, T4 par4);
    }

    public interface IStaticFunc<T1, T2, T3, T4, T5, TResult> : IStaticFunc
    {
        TResult Invoke(T1 par1, T2 par2, T3 par3, T4 par4, T5 par5);
    }
}
