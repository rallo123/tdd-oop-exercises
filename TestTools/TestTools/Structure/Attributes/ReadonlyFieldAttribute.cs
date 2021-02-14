using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.Attributes
{
    public class ReadonlyFieldAttribute : Attribute, IMemberVerifier
    {
        public StructureVerifier Verifier { get; set; }
        public ITypeTranslator TypeTranslator { get; set; }

        public MemberVerificationAspect[] Aspect => new[] {  
            MemberVerificationAspect.MemberType,
            MemberVerificationAspect.FieldAccessLevel 
        };

        public void Verify(MemberInfo originalMember, MemberInfo translatedMember)
        {
            Verifier.VerifyMemberType(translatedMember, new[] { MemberTypes.Field });
            Verifier.VerifyIsInitOnly((FieldInfo)translatedMember, true);
        }
    }
}
