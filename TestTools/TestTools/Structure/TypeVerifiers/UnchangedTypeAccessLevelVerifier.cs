using System;
using System.Collections.Generic;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class UnchangedTypeAccessLevelVerifier : ITypeVerifier
    {
        public StructureVerifier Verifier { get; set; }
        public ITypeTranslator TypeTranslator { get; set; }
        public TypeVerificationAspect[] Aspects => new[] { TypeVerificationAspect.AccessLevel };

        public void Verify(Type originalType, Type translatedType)
        {
            AccessLevels accessLevel = ReflectionHelper.GetAccessLevel(originalType);
            Verifier.VerifyAccessLevel(translatedType, new[] { accessLevel });
        }
    }
}
