using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TestTools.Structure.Attributes
{
    public class FieldOrPropertyAttribute : Attribute, IMemberVerifier
    {
        public StructureVerifier Verifier { get; set; }

        public ITypeTranslator TypeTranslator { get; set; }

        public MemberVerificationAspect[] Aspect => new[] { MemberVerificationAspect.MemberType };

        public void Verify( MemberInfo originalMember, MemberInfo translatedMember)
        {
            Verifier.VerifyMemberType(translatedMember, new[] { MemberTypes.Field, MemberTypes.Property });
        }
    }
}
