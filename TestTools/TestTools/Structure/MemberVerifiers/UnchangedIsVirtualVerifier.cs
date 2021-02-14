using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace TestTools.Structure.MemberVerifiers
{
    public class UnchangedIsVirtualVerifier : MemberVerifier
    {
        public override MemberVerificationAspect[] Aspect => new[] {
            MemberVerificationAspect.PropertyGetIsVirtual,
            MemberVerificationAspect.PropertySetIsVirtual,
            MemberVerificationAspect.MethodIsVirtual
        };

        public override void Verify(MemberInfo originalMember, MemberInfo translatedMember)
        {
            if (originalMember is PropertyInfo originalProperty)
            {
                Verifier.VerifyMemberType(translatedMember, new[] { MemberTypes.Property });

                Verifier.VerifyIsVirtual((PropertyInfo)translatedMember, originalProperty.GetMethod.IsVirtual, GetMethod: true);
                Verifier.VerifyIsVirtual((PropertyInfo)translatedMember, originalProperty.SetMethod.IsVirtual, SetMethod: true);
            }
            else if (translatedMember is MethodInfo originalMethod)
            {
                Verifier.VerifyMemberType(translatedMember, new[] { MemberTypes.Method });
                Verifier.VerifyIsStatic((MethodInfo)translatedMember, originalMethod.IsStatic);
            }
            else throw new NotImplementedException();
        }
    }
}
