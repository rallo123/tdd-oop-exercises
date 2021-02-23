using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class TypeIsStaticVerifier : ITypeVerifier
    {
        bool _isStatic;

        public TypeIsStaticVerifier(bool isStatic = true)
        {
            _isStatic = isStatic;
        }

        public StructureVerifier Verifier { get; set; }
        public ITypeTranslator TypeTranslator { get; set; }
        public TypeVerificationAspect[] Aspects => new[] { TypeVerificationAspect.AccessLevel };

        public void Verify(Type originalType, Type translatedType)
        {
            Verifier.VerifyIsStatic(translatedType, _isStatic);
        }
    }
}
