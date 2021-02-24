using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TestTools.Syntax
{
    public class ConstructorCallAttribute : Attribute, ISyntaxTransformer
    {
        public ConstructorCallAttribute()
        {
        }

        public virtual Expression Transform(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
