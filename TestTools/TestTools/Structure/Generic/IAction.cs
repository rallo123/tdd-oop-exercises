using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.Generic
{
    public interface IAction<TRoot> : IAction
    {
        public void Invoke(TRoot instance);
    }

    public interface IAction<TRoot, T1> : IAction
    {
        public void Invoke(TRoot instance, T1 par1);
    }

    public interface IAction<TRoot, T1, T2> : IAction
    {
        public void Invoke(TRoot instance, T1 par1, T2 par2);
    }

    public interface IAction<TRoot, T1, T2, T3> : IAction
    {
        public void Invoke(TRoot instance, T1 par1, T2 par2, T3 par3);
    }

    public interface IAction<TRoot, T1, T2, T3, T4> : IAction
    {
        public void Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4);
    }

    public interface IAction<TRoot, T1, T2, T3, T4, T5> : IAction
    {
        public void Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4, T5 par5);
    }
}
