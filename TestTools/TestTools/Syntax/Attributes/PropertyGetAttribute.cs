using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Syntax.Attributes
{
    public class PropertyGetAttribute : Attribute, ISyntaxTransformer
    {
        public string PropertyName { get; }

        public PropertyGetAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        public Expression Transform(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
