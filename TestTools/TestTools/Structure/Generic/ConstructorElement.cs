using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.Generic
{
    public class ConstructorElement<TRoot> : ConstructorElement, IFunc<TRoot, TRoot>
    {
        public ConstructorElement(ConstructorInfo constructorInfo) : base(constructorInfo) { }
        
        public TRoot Invoke() => (TRoot)base.Invoke();
        public TRoot Invoke(TRoot instance) => Invoke();
    }

    public class ConstructorElement<TRoot, T1> : ConstructorElement, IFunc<TRoot, T1, TRoot>
    {
        public ConstructorElement(ConstructorInfo constructorInfo) : base(constructorInfo) { }

        public TRoot Invoke(T1 par1) => (TRoot)base.Invoke(par1);
        public TRoot Invoke(TRoot instance, T1 par1) => (TRoot)base.Invoke(instance, par1);
    }

    public class ConstructorElement<TRoot, T1, T2> : ConstructorElement, IFunc<TRoot, T1, T2, TRoot>
    {
        public ConstructorElement(ConstructorInfo constructorInfo) : base(constructorInfo) { }

        public TRoot Invoke(T1 par1, T2 par2) => (TRoot)base.Invoke(par1, par2);
        public TRoot Invoke(TRoot instance, T1 par1, T2 par2) => (TRoot)base.Invoke(instance, par1, par2);
    }

    public class ConstructorElement<TRoot, T1, T2, T3> : ConstructorElement, IFunc<TRoot, T1, T2, T3, TRoot>
    {
        public ConstructorElement(ConstructorInfo constructorInfo) : base(constructorInfo) { }

        public TRoot Invoke(T1 par1, T2 par2, T3 par3) => (TRoot)base.Invoke(par1, par2, par3);
        public TRoot Invoke(TRoot instance, T1 par1, T2 par2, T3 par3) => (TRoot)base.Invoke(instance, par1, par2, par3);
    }

    public class ConstructorElement<TRoot, T1, T2, T3, T4> : ConstructorElement, IFunc<TRoot, T1, T2, T3, T4, TRoot>
    {
        public ConstructorElement(ConstructorInfo constructorInfo) : base(constructorInfo) { }
        
        public TRoot Invoke(T1 par1, T2 par2, T3 par3, T4 par4) => (TRoot)base.Invoke(par1, par2, par3, par4);
        public TRoot Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4) => (TRoot)base.Invoke(instance, par1, par2, par3, par4);
    }

    public class ConstructorElement<TRoot, T1, T2, T3, T4, T5> : ConstructorElement, IFunc<TRoot, T1, T2, T3, T4, T5, TRoot>
    {
        public ConstructorElement(ConstructorInfo constructorInfo) : base(constructorInfo) { }

        public TRoot Invoke(T1 par1, T2 par2, T3 par3, T4 par4, T5 par5) => (TRoot)base.Invoke(par1, par2, par3, par4, par5);
        public TRoot Invoke(TRoot instance, T1 par1, T2 par2, T3 par3, T4 par4, T5 par5) => (TRoot)base.Invoke(instance, par1, par2, par3, par4, par5);
    }
}
