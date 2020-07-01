using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Generic
{
    public interface IStaticInvocable<TReturn> : IStaticInvocable
    {
        TReturn Invoke();
    }

    public interface IStaticInvocable<TReturn, T1> : IStaticInvocable
    {
        TReturn Invoke(T1 par1);
    }

    public interface IStaticInvocable<TReturn, T1, T2> : IStaticInvocable
    {
        TReturn Invoke(T1 par1, T2 par2);
    }

    public interface IStaticInvocable<TReturn, T1, T2, T3> : IStaticInvocable
    {
        TReturn Invoke(T1 par1, T2 par2, T3 par3);
    }

    public interface IStaticInvocable<TReturn, T1, T2, T3, T4> : IStaticInvocable
    {
        TReturn Invoke(T1 par1, T2 par2, T3 par3, T4 par4);
    }

    public interface IStaticInvocable<TReturn, T1, T2, T3, T4, T5> : IStaticInvocable
    {
        TReturn Invoke(T1 par1, T2 par2, T3 par3, T4 par4, T5 par5);
    }
}
