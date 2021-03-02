using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public class UnchangedPropertyTypeVerifier : MemberVerifier
    {
        public override MemberVerificationAspect[] Aspects => new[] { MemberVerificationAspect.PropertyType };

        public override void Verify(MemberInfo originalMember, MemberInfo translatedMember)
        {
            FieldInfo translatedProperty = translatedMember as FieldInfo;

            Verifier.VerifyMemberType(translatedMember, new MemberTypes[] { MemberTypes.Field, MemberTypes.Property });

            if (originalMember is FieldInfo originalField)
                Verifier.VerifyFieldType(translatedProperty, originalField.FieldType);
            else if (originalMember is PropertyInfo originalProperty)
                Verifier.VerifyFieldType(translatedProperty, originalProperty.PropertyType);
            else throw new NotImplementedException();
        }
    }
}
