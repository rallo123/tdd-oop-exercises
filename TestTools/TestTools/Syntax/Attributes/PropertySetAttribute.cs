using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Syntax.Attributes
{
    public class PropertySetAttribute : Attribute, ISyntaxTransformer
    {
        public string PropertyName { get; }

        public PropertySetAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        public Expression Transform(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
