using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.MemberVerifiers
{
    public abstract class MemberVerifier : IMemberVerifier
    {
        public StructureVerifier Verifier { get; set; }

        public ITypeTranslator TypeTranslator { get; set; }

        public abstract MemberVerificationAspect[] Aspect { get; }

        public abstract void Verify(MemberInfo originalMember, MemberInfo translatedMember);
    }
}
