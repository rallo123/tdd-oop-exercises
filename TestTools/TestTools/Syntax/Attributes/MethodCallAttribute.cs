using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Syntax.Attributes
{
    public class MethodCallAttribute : Attribute, ISyntaxTransformer
    {
        public string MethodName { get; }

        public MethodCallAttribute(string methodName)
        {
            MethodName = methodName;
        }

        public Expression Transform(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
