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

        public ICollection<ITypeVerifier> TypeVerifiers { get; set; } = new List<ITypeVerifier>()
        {
            new UnchangedTypeAccessLevelVerifier(),
            new UnchangedTypeIsAbstractVerifier(),
            new UnchangedTypeIsStaticVerifier()
        };

        public IMemberTranslator MemberTranslator { get; set; }

        public ICollection<IMemberVerifier> MemberVerifiers { get; set; } = new List<IMemberVerifier>()
        {
            new UnchangedFieldTypeVerifier(),
            new UnchangedMemberAccessLevelVerifier(),
            new UnchangedMemberDeclaringType(),
            new UnchangedMemberIsStaticVerifier(),
            new UnchangedMemberIsVirtualVerifier(),
            new UnchangedMemberTypeVerifier(),
            new UnchangedPropertyTypeVerifier()
        };

        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }
    }
}
