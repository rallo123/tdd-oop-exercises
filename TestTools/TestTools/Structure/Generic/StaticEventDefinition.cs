using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.Generic
{
    public class StaticEventDefinition<T> : StaticEventDefinition, IStaticInvocable<T>
    {
        public StaticEventDefinition(EventInfo eventInfo) : base(eventInfo)
        {
        }

        public T Invoke()
        {
            return (T)base.Invoke(new object[] { });
        }
    }
}
