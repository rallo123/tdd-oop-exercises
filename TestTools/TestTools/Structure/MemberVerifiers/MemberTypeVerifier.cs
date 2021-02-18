using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.MemberVerifiers
{
    public class MemberTypeVerifier : MemberVerifier
    {
        MemberTypes[] _memberTypes;

        public MemberTypeVerifier(MemberTypes[] memberTypes)
        {
            _memberTypes = memberTypes;
        }

        public override MemberVerificationAspect[] Aspect => new[] { MemberVerificationAspect.MemberType };

        public override void Verify(MemberInfo originalMember, MemberInfo translatedMember)
        {
            Verifier.VerifyMemberType(translatedMember, _memberTypes);
        }
    }
}
