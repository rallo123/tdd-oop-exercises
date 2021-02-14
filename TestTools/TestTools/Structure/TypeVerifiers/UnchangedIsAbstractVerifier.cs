using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.TypeVerifiers
{
    public class UnchangedIsAbstractVerifier : ITypeVerifier
    {
        public StructureVerifier Verifier { get; set; }
        public ITypeTranslator TypeTranslator { get; set; }

        public TypeVerificationAspect[] Aspects => new[] { TypeVerificationAspect.IsAbstract };

        public void Verify(Type originalType, Type translatedType)
        {
            Verifier.VerifyIsAbstract(translatedType, originalType.IsAbstract);
        }
    }
}
