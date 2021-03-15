using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace TestTools.Syntax
{
    public interface ISyntaxTransformer
    {
        public Expression Transform(Expression expression);
    }
}
