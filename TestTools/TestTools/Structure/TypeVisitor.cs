using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class TypeVisitor : ExpressionVisitor
    {
        public ITypeTranslator TypeTranslator { get; set; }

        public ICollection<ITypeVerifier> TypeVerifiers { get; set; }

        public IMemberTranslator MemberTranslator { get; set; }

        public ICollection<IMemberVerifier> MemberVerifiers { get; set; }

        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }
    }
}
