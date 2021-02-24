using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Syntax
{
    public class FieldGetAttribute : Attribute, ISyntaxTransformer
    {
        public string FieldName { get; }

        public FieldGetAttribute(string fieldName)
        {
            FieldName = fieldName;
        }

        public Expression Transform(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
