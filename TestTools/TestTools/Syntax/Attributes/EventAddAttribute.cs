using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TestTools.Syntax
{
    public class EventAddAttribute
    {
        public string EventName { get; }

        public EventAddAttribute(string eventName)
        {
            EventName = eventName;
        }

        public Expression Transform(Expression expression)
        {
            // Ensuring that the method with the FieldSetAttribute is called correctly
            MethodCallExpression methodCall = (MethodCallExpression)expression;
            Type type = methodCall.Method.DeclaringType;
            if (methodCall.Arguments.Count != 1)
                throw new ArgumentException($"Method {type.Name}.{methodCall.Method.Name} must be called with 1 argument");

            // Ensuring that event exists on type
            EventInfo eventInfo = type.GetEvent(EventName);
            if (eventInfo == null)
                throw new ArgumentException($"Class {type.Name} does not contain event {EventName}");

            // Transforming the method call to a event subscription
            throw new NotImplementedException();
        }
    }
}
