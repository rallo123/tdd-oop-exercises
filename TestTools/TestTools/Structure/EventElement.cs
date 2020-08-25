using System;
using System.Reflection;
using TestTools.Structure;

namespace TestTools.Structure
{
    public class EventElement : Element, IFunc
    {
        public EventInfo Info { get; set; }
        public override string Name => Info.Name;

        public EventElement(EventInfo eventInfo)
        {
            Info = eventInfo;
        }

        public object Invoke(object[] parameters) => Invoke(null, parameters);
        public object Invoke(object instance, object[] parameters)
        {
            throw new NotImplementedException("Events are not supported yet");
        }
    }
}
