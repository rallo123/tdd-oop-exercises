using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure.Generic
{
    public class ActionMethodElement<TRoot> : ActionMethodElement, IAction<TRoot>
    {
        public ActionMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(TRoot instance)
        {
            base.Invoke(instance, new object[] { });
        }
    }

    public class ActionMethodElement<TRoot, T1> : ActionMethodElement, IAction<TRoot, T1>
    {
        public ActionMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(TRoot instance, T1 par1)
        {
            base.Invoke(instance, new object[] { par1 });
        }
    }

    public class ActionMethodElement<TRoot, T1, T2> : ActionMethodElement, IAction<TRoot, T1, T2>
    {
        public ActionMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(TRoot instance, T1 par1, T2 par2)
        {
            base.Invoke(instance, new object[] { par1, par2 });
        }
    }

    public class ActionMethodElement<TRoot, T1, T2, T3> : ActionMethodElement, IAction<TRoot, T1, T2, T3>
    {
        public ActionMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(TRoot instance, T1 par1, T2 par2, T3 par3)
        {
            base.Invoke(instance, new object[] { par1, par2, par3 });
        }
    }

    public class ActionMethodElement<TRoot, T1, T2, T3, T4> : ActionMethodElement, IAction<TRoot, T1, T2, T3, T4>
    {
        public ActionMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4)
        {
            object value = GetValueOfPreviousElement(instance);
            ReflectionHelper.Invoke(Info, value, new object[] { par1, par2, par3, par4 });
        }
    }

    public class ActionMethodElement<TRoot, T1, T2, T3, T4, T5> : ActionMethodElement, IAction<TRoot, T1, T2, T3, T4, T5>{
        public ActionMethodElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4, T5 par5)
        {
            base.Invoke(instance, new object[] { par1, par2, par3, par4, par5 });
        }
    }
}
