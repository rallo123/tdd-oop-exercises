using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Syntax
{
    public class FieldSetAttribute : Attribute, ISyntaxTransformer
    {
        public string FieldName { get; }

        public FieldSetAttribute(string fieldName)
        {
            FieldName = fieldName;
        }

        public Expression Transform(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
