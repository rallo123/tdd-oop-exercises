using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class UnchangedMemberDeclaringType : MemberVerifier
    {
        public override MemberVerificationAspect[] Aspects => new[] {
            MemberVerificationAspect.MethodDeclaringType,
            MemberVerificationAspect.PropertyGetDeclaringType,
            MemberVerificationAspect.PropertySetDeclaringType
        };

        public override void Verify(MemberInfo originalMember, MemberInfo translatedMember)
        {
            if (originalMember is MethodInfo originalMethod)
            {
                Type type = TypeTranslator.Translate(originalMethod.DeclaringType);
                Verifier.VerifyMemberType(translatedMember, new[] { MemberTypes.Method });
                Verifier.VerifyDeclaringType((MethodInfo)translatedMember, type);
            }
            else if (originalMember is PropertyInfo originalProperty)
            {
                Type type1 = TypeTranslator.Translate(originalProperty.GetMethod.DeclaringType);
                Type type2 = TypeTranslator.Translate(originalProperty.SetMethod.DeclaringType);

                Verifier.VerifyMemberType(translatedMember, new[] { MemberTypes.Field, MemberTypes.Property });

                if (translatedMember is FieldInfo translatedField)
                {
                    Verifier.VerifyDeclaringType(translatedField, type1);
                }
                else if (translatedMember is PropertyInfo translatedProperty)
                {
                    Verifier.VerifyDeclaringType(translatedProperty, type1, GetMethod: true);
                    Verifier.VerifyDeclaringType(translatedProperty, type2, SetMethod: true);
                }
            }
            else throw new NotImplementedException();
        }
    }
}
