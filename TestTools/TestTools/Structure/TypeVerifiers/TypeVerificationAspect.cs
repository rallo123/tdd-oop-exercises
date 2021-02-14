using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public class TypeVerificationAspect
    {
        public TypeVerificationAspect()
        {
        }

        public static TypeVerificationAspect AccessLevel { get; } = new TypeVerificationAspect();
        public static TypeVerificationAspect IsAbstract { get; } = new TypeVerificationAspect();
        public static TypeVerificationAspect IsStatic { get; } = new TypeVerificationAspect();
    }
}
