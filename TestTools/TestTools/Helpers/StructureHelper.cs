using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TestTools.Helpers
{
    public static class StructureHelper
    {
        public static Expression<Func<EventInfo, bool>> IsPublicEvent
        {
            get { return info => info.AddMethod.IsPublic && info.RemoveMethod.IsPublic; }
        }

        public static EventInfo GetEventInfo<TInstance>(string name)
        {
            return typeof(TInstance).GetEvent(name);
        }

        public static Expression<Func<PropertyInfo, bool>> IsPublicProperty
        {
            get { return info => info.GetMethod.IsPublic && info.SetMethod.IsPublic; }
        }

        public static PropertyInfo GetIndexProperty<TInstance>()
        {
            throw new NotImplementedException();
        }
    }
}
