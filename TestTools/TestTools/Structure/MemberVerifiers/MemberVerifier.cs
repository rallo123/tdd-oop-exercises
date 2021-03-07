using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public abstract class MemberVerifier : IMemberVerifier
    {
        public StructureVerifier Verifier { get; set; }

        public IStructureService Service { get; set; }

        public abstract MemberVerificationAspect[] Aspects { get; }

        public abstract void Verify(MemberInfo originalMember, MemberInfo translatedMember);
    }
}
