using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Generic
{
    public interface IInvocable<TClass, TReturn> : IInvocable
    {
        public TReturn Invoke(TClass instance);
    }

    public interface IInvocable<TClass, TReturn, T1> : IInvocable
    {
        public TReturn Invoke(TClass instance, T1 par1);
    }

    public interface IInvocable<TClass, TReturn, T1, T2> : IInvocable
    {
        public TReturn Invoke(TClass instance, T1 par1, T2 par2);
    }

    public interface IInvocable<TClass, TReturn, T1, T2, T3> : IInvocable
    {
        public TReturn Invoke(TClass instance, T1 par1, T2 par2, T3 par3);
    }

    public interface IInvocable<TClass, TReturn, T1, T2, T3, T4> : IInvocable
    {
        public TReturn Invoke(TClass instance, T1 par1, T2 par2, T3 par3, T4 par4);
    }

    public interface IInvocable<TClass, TReturn, T1, T2, T3, T4, T5> : IInvocable
    {
        public TReturn Invoke(TClass instance, T1 par1, T2 par2, T3 par3, T4 par4, T5 par5);
    }
}
