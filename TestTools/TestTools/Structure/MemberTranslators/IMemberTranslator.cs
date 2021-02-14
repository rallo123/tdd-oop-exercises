using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestTools.Structure
{
    public interface IMemberTranslator
    {
        StructureVerifier Verifier { get; set; }
        MemberInfo Translate(Type targetType, MemberInfo member);
    }
}
