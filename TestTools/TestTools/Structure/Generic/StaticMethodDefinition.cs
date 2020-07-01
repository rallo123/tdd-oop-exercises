using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.Generic
{
    public class StaticMethodDefinition<TReturn> : StaticMethodDefinition, IStaticInvocable<TReturn>
    {
        public StaticMethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke()
        {
            return (TReturn)base.Invoke(new object[] { });
        }
    }

    public class StaticMethodDefinition<TReturn, T1> : StaticMethodDefinition, IStaticInvocable<TReturn, T1>
    {
        public StaticMethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(T1 par1)
        {
            return (TReturn)base.Invoke(new object[] { par1 });
        }
    }

    public class StaticMethodDefinition<TReturn, T1, T2> : StaticMethodDefinition, IStaticInvocable<TReturn, T1, T2>
    {
        public StaticMethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(T1 par1, T2 par2)
        {
            return (TReturn)base.Invoke(new object[] { par1, par2 });
        }
    }

    public class StaticMethodDefinition<TReturn, T1, T2, T3> : StaticMethodDefinition, IStaticInvocable<TReturn, T1, T2, T3>
    {
        public StaticMethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(T1 par1, T2 par2, T3 par3)
        {
            return (TReturn)base.Invoke(new object[] { par1, par2, par3 });
        }
    }

    public class StaticMethodDefinition<TReturn, T1, T2, T3, T4> : StaticMethodDefinition, IStaticInvocable<TReturn, T1, T2, T3, T4>
    {
        public StaticMethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(T1 par1, T2 par2, T3 par3, T4 par4)
        {
            return (TReturn)base.Invoke(new object[] { par1, par2, par3, par4 });
        }
    }

    public class StaticMethodDefinition<TReturn, T1, T2, T3, T4, T5> : StaticMethodDefinition, IStaticInvocable<TReturn, T1, T2, T3, T4, T5>
    {
        public StaticMethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(T1 par1, T2 par2, T3 par3, T4 par4, T5 par5)
        {
            return (TReturn)base.Invoke(new object[] { par1, par2, par3, par4, par5 });
        }
    }
}
