using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class UnchangedTypeIsStaticVerifier : TypeVerifier
    {
        public override TypeVerificationAspect[] Aspects => new[] { 
            TypeVerificationAspect.IsStatic
        };

        public override void Verify(Type originalType, Type translatedType)
        {
            bool isStatic = originalType.IsAbstract && originalType.IsSealed;
            Verifier.VerifyIsStatic(originalType, isStatic);
        }
    }
}
