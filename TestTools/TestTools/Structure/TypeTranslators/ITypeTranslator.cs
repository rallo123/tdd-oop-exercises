using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public interface ITypeTranslator
    {
        StructureVerifier Verifier { get; set; }
        Type Translate(string targetNamespace, Type type);
    }
}
