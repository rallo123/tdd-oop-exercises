using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public abstract class TypeTranslator : ITypeTranslator
    {
        public string TargetNamespace { get; set; }

        public StructureVerifier Verifier { get; set; }

        public abstract Type Translate(Type type);
    }
}
