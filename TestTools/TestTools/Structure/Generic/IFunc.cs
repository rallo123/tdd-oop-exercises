using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Generic
{
    public interface IFunc<TRoot, TResult> : IFunc
    {
        public TResult Invoke(TRoot instance);
    }

    public interface IFunc<TRoot, T1, TResult> : IFunc
    {
        public TResult Invoke(TRoot instance, T1 par1);
    }

    public interface IFunc<TRoot, T1, T2, TResult> : IFunc
    {
        public TResult Invoke(TRoot instance, T1 par1, T2 par2);
    }

    public interface IFunc<TRoot, T1, T2, T3, TResult> : IFunc
    {
        public TResult Invoke(TRoot instance, T1 par1, T2 par2, T3 par3);
    }

    public interface IFunc<TRoot, T1, T2, T3, T4, TResult> : IFunc
    {
        public TResult Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4);
    }

    public interface IFunc<TRoot, T1, T2, T3, T4, T5, TResult> : IFunc
    {
        public TResult Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4, T5 par5);
    }
}
