using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Syntax
{
    public class EventAddAttribute : DelegateAddAttribute
    {
        public EventAddAttribute(string memberName) : base(memberName)
        {
        }

        public override Expression Transform(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
