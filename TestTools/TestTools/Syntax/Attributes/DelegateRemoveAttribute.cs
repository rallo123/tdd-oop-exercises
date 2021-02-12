using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Syntax.Attributes
{
    public class DelegateRemoveAttribute : Attribute, ISyntaxTransformer
    {
        public string MemberName { get; }

        public DelegateRemoveAttribute(string memberName)
        {
            MemberName = memberName;
        }

        public virtual Expression Transform(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
