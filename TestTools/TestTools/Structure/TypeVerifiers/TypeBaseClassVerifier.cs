using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class TypeBaseClassVerifier : ITypeVerifier
    {
        Type _type;

        public TypeBaseClassVerifier(Type type)
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
            Verifier.VerifyBaseType(translatedType, _type);
        }
    }
}
