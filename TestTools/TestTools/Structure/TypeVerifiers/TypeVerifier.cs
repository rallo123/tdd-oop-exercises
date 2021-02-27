using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public abstract class TypeVerifier : ITypeVerifier
    {
        public StructureVerifier Verifier { get; set; }

        public ITypeTranslator TypeTranslator { get; set; }

        public abstract TypeVerificationAspect[] Aspects { get; }

        public abstract void Verify(Type originalType, Type translatedType);
    }
}
