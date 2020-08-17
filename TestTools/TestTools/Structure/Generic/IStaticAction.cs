using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Generic
{
    public interface IStaticAction<T1> : IStaticAction
    {
        void Invoke(T1 par1);
    }

    public interface IStaticAction<T1, T2> : IStaticAction
    {
        void Invoke(T1 par1, T2 par2);
    }

    public interface IStaticAction<T1, T2, T3> : IStaticAction
    {
        void Invoke(T1 par1, T2 par2, T3 par3);
    }

    public interface IStaticAction<T1, T2, T3, T4> : IStaticAction
    {
        void Invoke(T1 par1, T2 par2, T3 par3, T4 par4);
    }

    public interface IStaticAction<T1, T2, T3, T4, T5> : IStaticAction
    {
        void Invoke(T1 par1, T2 par2, T3 par3, T4 par4, T5 par5);
    }
}
