using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using TestTools.Structure;

namespace TestTools.Structure
{
    public class StructureTest
    {
        internal StructureTest() { }

        public void AssertType(Type @class, params ITypeVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public void AssertMember(MemberInfo memberInfo, params IMemberVerifier[] verifiers)
        {
            throw new NotImplementedException();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
