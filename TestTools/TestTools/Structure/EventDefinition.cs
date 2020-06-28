using System;
using System.Reflection;
using TestTools.Structure;

namespace TestTools.Structure
{
    public class EventDefinition : Definition, IInvocable
    {
        public EventInfo Info { get; set; }
        public override string Name => Info.Name;

        public EventDefinition(EventInfo eventInfo)
        {
            Info = eventInfo;
        }

        public object Invoke(object instance, object[] parameters)
        {
            throw new NotImplementedException("Events are not supported yet");
        }
    }
}
