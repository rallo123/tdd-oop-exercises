using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Syntax.Attributes
{
    public class EventRemoveAttribute : DelegateRemoveAttribute
    {
        public EventRemoveAttribute(string memberName) : base(memberName)
        {
        }

        public override Expression Transform(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
