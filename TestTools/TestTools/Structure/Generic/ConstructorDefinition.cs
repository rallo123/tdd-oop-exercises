using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.Generic
{
    public class ConstructorDefinition<TClass> : ConstructorDefinition, IStaticInvocable<TClass>
    {
        public ConstructorDefinition(ConstructorInfo constructorInfo) : base(constructorInfo) { }
        public TClass Invoke() => (TClass)base.Invoke();
    }

    public class ConstructorDefinition<TClass, T1> : ConstructorDefinition, IStaticInvocable<TClass, T1>
    {
        public ConstructorDefinition(ConstructorInfo constructorInfo) : base(constructorInfo) { }
        public TClass Invoke(T1 par1) => (TClass)base.Invoke(par1);
    }

    public class ConstructorDefinition<TClass, T1, T2> : ConstructorDefinition, IStaticInvocable<TClass, T1, T2>
    {
        public ConstructorDefinition(ConstructorInfo constructorInfo) : base(constructorInfo) { }
        public TClass Invoke(T1 par1, T2 par2) => (TClass)base.Invoke(par1, par2);
    }

    public class ConstructorDefinition<TClass, T1, T2, T3> : ConstructorDefinition, IStaticInvocable<TClass, T1, T2, T3>
    {
        public ConstructorDefinition(ConstructorInfo constructorInfo) : base(constructorInfo) { }
        public TClass Invoke(T1 par1, T2 par2, T3 par3) => (TClass)base.Invoke(par1, par2, par3);
    }

    public class ConstructorDefinition<TClass, T1, T2, T3, T4> : ConstructorDefinition, IStaticInvocable<TClass, T1, T2, T3, T4>
    {
        public ConstructorDefinition(ConstructorInfo constructorInfo) : base(constructorInfo) { }
        public TClass Invoke(T1 par1, T2 par2, T3 par3, T4 par4) => (TClass)base.Invoke(par1, par2, par3, par4);
    }

    public class ConstructorDefinition<TClass, T1, T2, T3, T4, T5> : ConstructorDefinition, IStaticInvocable<TClass, T1, T2, T3, T4, T5>
    {
        public ConstructorDefinition(ConstructorInfo constructorInfo) : base(constructorInfo) { }
        public TClass Invoke(T1 par1, T2 par2, T3 par3, T4 par4, T5 par5) => (TClass)base.Invoke(par1, par2, par3, par4, par5);
    }
}
