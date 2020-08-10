using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class EventStaticElement : Element, IStaticFunc
    {
        public EventStaticElement(EventInfo eventInfo)
        {
            Info = eventInfo;
        }

        public EventInfo Info { get; }
        public override string Name => Info.Name; 

        public object Invoke(object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
