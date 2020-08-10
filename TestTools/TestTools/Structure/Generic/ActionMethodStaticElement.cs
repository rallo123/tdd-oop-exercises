using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.Generic
{
    public class ActionMethodStaticElement<TRoot> : ActionMethodStaticElement, IStaticAction
    {
        public ActionMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke()
        {
            base.Invoke(new object[] { });
        }
    }

    public class ActionMethodStaticElement<TRoot, T1> : Structure.ActionMethodStaticElement, IStaticAction<T1>
    {
        public ActionMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(T1 par1)
        {
            base.Invoke(new object[] { par1 });
        }
    }

    public class ActionMethodStaticElement<TRoot, T1, T2> : Structure.ActionMethodStaticElement, IStaticAction<T1, T2>
    {
        public ActionMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(T1 par1, T2 par2)
        {
            base.Invoke(new object[] { par1, par2 });
        }
    }

    public class ActionMethodStaticElement<TRoot, T1, T2, T3> : Structure.ActionMethodStaticElement, IStaticAction<T1, T2, T3>
    {
        public ActionMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(T1 par1, T2 par2, T3 par3)
        {
            base.Invoke(new object[] { par1, par2, par3 });
        }
    }

    public class ActionMethodStaticElement<TRoot, T1, T2, T3, T4> : Structure.ActionMethodStaticElement, IStaticAction<T1, T2, T3, T4>
    {
        public ActionMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(T1 par1, T2 par2, T3 par3, T4 par4)
        {
            base.Invoke(new object[] { par1, par2, par3, par4 });
        }
    }

    public class ActionMethodStaticElement<TRoot, T1, T2, T3, T4, T5> : Structure.ActionMethodStaticElement, IStaticAction<T1, T2, T3, T4, T5>
    {
        public ActionMethodStaticElement(MethodInfo methodInfo) : base(methodInfo) { }

        public void Invoke(T1 par1, T2 par2, T3 par3, T4 par4, T5 par5)
        {
            base.Invoke(new object[] { par1, par2, par3, par4, par5 });
        }
    }
}
