using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure.MemberVerifiers
{
    public class UnchangedIsStaticVerifier : MemberVerifier
    {
        public override MemberVerificationAspect[] Aspect => new[] {
            MemberVerificationAspect.MethodDeclaringType,
            MemberVerificationAspect.PropertyGetDeclaringType,
            MemberVerificationAspect.PropertySetDeclaringType
        };

        public override void Verify(MemberInfo originalMember, MemberInfo translatedMember)
        {
            if (originalMember is FieldInfo originalField)
            {
                Verifier.VerifyMemberType(translatedMember, new[] { MemberTypes.Field, MemberTypes.Property });

                if (translatedMember is FieldInfo translatedField)
                {
                    Verifier.VerifyIsStatic(translatedField, originalField.IsStatic);
                }
                else if (translatedMember is PropertyInfo translatedProperty)
                {
                    Verifier.VerifyIsStatic(translatedProperty, originalField.IsStatic);
                }
            }
            else if (originalMember is PropertyInfo originalProperty)
            {
                bool isStatic = originalProperty.CanRead ? originalProperty.GetMethod.IsStatic : originalProperty.SetMethod.IsStatic;

                Verifier.VerifyMemberType(translatedMember, new[] { MemberTypes.Field, MemberTypes.Property });

                if (translatedMember is FieldInfo translatedField)
                {
                    Verifier.VerifyIsStatic(translatedField, isStatic);
                }
                else if (translatedMember is PropertyInfo translatedProperty)
                {
                    Verifier.VerifyIsStatic(translatedProperty, isStatic);
                }
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
