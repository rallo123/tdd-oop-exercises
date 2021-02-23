using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class TypeIsSubclassOfVerifier : ITypeVerifier
    {
        Type _type;

        public TypeIsSubclassOfVerifier(Type type)
        {
            _type = type;
        }

        public StructureVerifier Verifier { get; set; }
        public ITypeTranslator TypeTranslator { get; set; }

        public TypeVerificationAspect[] Aspects => new[]
        {
            TypeVerificationAspect.IsSubclassOf
        };

        public void Verify(Type originalType, Type translatedType)
        {
            Verifier.VerifyIsSubclassOf(translatedType, _type);
        }
    }
}
