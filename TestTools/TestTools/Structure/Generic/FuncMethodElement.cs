using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public class FuncMethodElement<TRoot, TResult> : FuncMethodElement, IFunc<TRoot, TResult>
    {
        public FuncMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke() => (TResult)base.Invoke(new object[] { });
        public TResult Invoke(TRoot instance) => (TResult)base.Invoke(instance, new object[] { });
    }

    public class FuncMethodElement<TRoot, T1, TResult> : FuncMethodElement, IFunc<TRoot, T1, TResult>
    {
        public FuncMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1) => (TResult)base.Invoke(new object[] { par1 });
        public TResult Invoke(TRoot instance, T1 par1) => (TResult)base.Invoke(instance, new object[] { par1 });
    }

    public class FuncMethodElement<TRoot, T1, T2, TResult> : FuncMethodElement, IFunc<TRoot, T1, T2, TResult>
    {
        public FuncMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1, T2 par2) => (TResult)base.Invoke(new object[] { par1, par2 });
        public TResult Invoke(TRoot instance, T1 par1, T2 par2) => (TResult)base.Invoke(instance, new object[] { par1, par2 });
    }

    public class FuncMethodElement<TRoot, T1, T2, T3, TResult> : FuncMethodElement, IFunc<TRoot, T1, T2, T3, TResult>
    {
        public FuncMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1, T2 par2, T3 par3) => (TResult)base.Invoke(new object[] { par1, par2, par3 });
        public TResult Invoke(TRoot instance, T1 par1, T2 par2, T3 par3) => (TResult)base.Invoke(instance, new object[] { par1, par2, par3 });
    }

    public class FuncMethodElement<TRoot, T1, T2, T3, T4, TResult> : FuncMethodElement, IFunc<TRoot, T1, T2, T3, T4, TResult>
    {
        public FuncMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1, T2 par2, T3 par3, T4 par4) => (TResult)base.Invoke(new object[] { par1, par2, par3, par4 });
        public TResult Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4) => (TResult)base.Invoke(instance, new object[] { par1, par2, par3, par4 });

    }

    public class FuncMethodElement<TRoot, T1, T2, T3, T4, T5, TResult> : FuncMethodElement, IFunc<TRoot, T1, T2, T3, T4, T5, TResult>
    {
        public FuncMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public TResult Invoke(T1 par1, T2 par2, T3 par3, T4 par4, T5 par5) => (TResult)base.Invoke(new object[] { par1, par2, par3, par4, par5 });
        public TResult Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4, T5 par5) => (TResult)base.Invoke(instance, new object[] { par1, par2, par3, par4, par5 });
    }
}
