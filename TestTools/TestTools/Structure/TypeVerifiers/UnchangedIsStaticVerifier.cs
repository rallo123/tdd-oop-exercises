using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure.TypeVerifiers
{
    public class UnchangedIsStaticVerifier : ITypeVerifier
    {
        public StructureVerifier Verifier { get; set; }
        public ITypeTranslator TypeTranslator { get; set; }

        public TypeVerificationAspect[] Aspects => new[] { TypeVerificationAspect.IsStatic };

        public void Verify(Type originalType, Type translatedType)
        {
            bool isStatic = originalType.IsAbstract && originalType.IsSealed;
            Verifier.VerifyIsStatic(originalType, isStatic);
        }
    }
}
