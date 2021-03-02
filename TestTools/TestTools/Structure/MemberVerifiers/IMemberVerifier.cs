using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TestTools.Structure
{
    public interface IMemberVerifier
    {
        MemberVerificationAspect[] Aspects { get; }
        
        StructureVerifier Verifier { get; set; }

        ITypeTranslator TypeTranslator { get; set; }

        void Verify(MemberInfo originalMember, MemberInfo translatedMember);
    }
}
