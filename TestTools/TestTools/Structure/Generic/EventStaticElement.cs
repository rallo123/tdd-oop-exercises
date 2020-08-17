using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.Generic
{
    public class EventStaticElement<T> : EventStaticElement, IStaticFunc<T>
    {
        public EventStaticElement(EventInfo eventInfo) : base(eventInfo)
        {
        }

        public T Invoke()
        {
            return (T)base.Invoke(new object[] { });
        }
    }
}
