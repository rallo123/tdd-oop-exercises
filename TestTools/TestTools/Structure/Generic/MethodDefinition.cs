using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public class MethodDefinition<TClass, TReturn> : MethodDefinition, IInvocable<TClass, TReturn>
    {
        public MethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(TClass instance)
        {
            return (TReturn)base.Invoke(instance, new object[] { });
        }
    }

    public class MethodDefinition<TClass, TReturn, T1> : MethodDefinition, IInvocable<TClass, TReturn, T1>
    {
        public MethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(TClass instance, T1 par1)
        {
            return (TReturn)base.Invoke(instance, new object[] { par1 });
        }
    }

    public class MethodDefinition<TClass, TReturn, T1, T2> : MethodDefinition, IInvocable<TClass, TReturn, T1, T2>
    {
        public MethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(TClass instance, T1 par1, T2 par2)
        {
            return (TReturn)base.Invoke(instance, new object[] { par1, par2 });
        }
    }

    public class MethodDefinition<TClass, TReturn, T1, T2, T3> : MethodDefinition, IInvocable<TClass, TReturn, T1, T2, T3>
    {
        public MethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(TClass instance, T1 par1, T2 par2, T3 par3)
        {
            return (TReturn) base.Invoke(instance, new object[] { par1, par2, par3 });
        }
    }

    public class MethodDefinition<TClass, TReturn, T1, T2, T3, T4> : MethodDefinition, IInvocable<TClass, TReturn, T1, T2, T3, T4>
    {
        public MethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(TClass instance, T1 par1, T2 par2, T3 par3, T4 par4)
        {
            object value = GetValueOfPreviousDefinition(instance);
            return (TReturn)StructureHelper.Invoke(Info, value, new object[] { par1, par2, par3, par4 });
        }
    }

    public class MethodDefinition<TClass, TReturn, T1, T2, T3, T4, T5> : MethodDefinition, IInvocable<TClass, TReturn, T1, T2, T3, T4, T5>{
        public MethodDefinition(MethodInfo methodInfo) : base(methodInfo) { }

        public TReturn Invoke(TClass instance, T1 par1, T2 par2, T3 par3, T4 par4, T5 par5)
        {
            return (TReturn)base.Invoke(instance, new object[] { par1, par2, par3, par4, par5 });
        }
    }
}
