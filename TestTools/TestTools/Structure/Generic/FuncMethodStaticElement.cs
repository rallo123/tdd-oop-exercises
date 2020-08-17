using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.Generic
{
    public class FuncMethodStaticElement<TRoot, TResult> : FuncMethodStaticElement, IStaticFunc<TResult>
    {
        public FuncMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke()
        {
            return (TResult)base.Invoke(new object[] { });
        }
    }

    public class FuncMethodStaticElement<TRoot, T1, TResult> : FuncMethodStaticElement, IStaticFunc<T1, TResult>
    {
        public FuncMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1)
        {
            return (TResult)base.Invoke(new object[] { par1 });
        }
    }

    public class FuncMethodStaticElement<TRoot, T1, T2, TResult> : FuncMethodStaticElement, IStaticFunc<T1, T2, TResult>
    {
        public FuncMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1, T2 par2)
        {
            return (TResult)base.Invoke(new object[] { par1, par2 });
        }
    }

    public class FuncMethodStaticElement<TRoot, T1, T2, T3, TResult> : FuncMethodStaticElement, IStaticFunc<T1, T2, T3, TResult>
    {
        public FuncMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1, T2 par2, T3 par3)
        {
            return (TResult)base.Invoke(new object[] { par1, par2, par3 });
        }
    }

    public class FuncMethodStaticElement<TRoot, T1, T2, T3, T4, TResult> : FuncMethodStaticElement, IStaticFunc<T1, T2, T3, T4, TResult>
    {
        public FuncMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1, T2 par2, T3 par3, T4 par4)
        {
            return (TResult)base.Invoke(new object[] { par1, par2, par3, par4 });
        }
    }

    public class FuncMethodStaticElement<TRoot, T1, T2, T3, T4, T5, TResult> : FuncMethodStaticElement, IStaticFunc<T1, T2, T3, T4, T5, TResult>
    {
        public FuncMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1, T2 par2, T3 par3, T4 par4, T5 par5)
        {
            return (TResult)base.Invoke(new object[] { par1, par2, par3, par4, par5 });
        }
    }
}
