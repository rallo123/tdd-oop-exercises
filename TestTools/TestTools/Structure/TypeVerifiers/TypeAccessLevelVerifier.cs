using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class TypeAccessLevelVerifier : ITypeVerifier
    {
        AccessLevels[] _accessLevels;

        public TypeAccessLevelVerifier(AccessLevels accessLevel) : this(new[] { accessLevel })
        {
        }

        public TypeAccessLevelVerifier(AccessLevels[] accessLevels)
        {
            _accessLevels = accessLevels;
        }

        public StructureVerifier Verifier { get; set; }
        public ITypeTranslator TypeTranslator { get; set; }

        public TypeVerificationAspect[] Aspects => new[]
        {
            TypeVerificationAspect.AccessLevel
        };

        public void Verify(Type originalType, Type translatedType)
        {
            Verifier.VerifyAccessLevel(translatedType, _accessLevels);
        }
    }
}
