﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestTools.Structure
{
    public interface ITypeVerifier
    {
        StructureVerifier Verifier { get; set; }
        IStructureService Service { get; set; }
        TypeVerificationAspect[] Aspects { get; }
        void Verify(Type originalType, Type translatedType);
    }
}
