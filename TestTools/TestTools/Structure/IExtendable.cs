using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public interface IExtendable : IElement
    {
        public Type Type { get; }

        public FieldElement Field(FieldRequirements options);

        public PropertyElement Property(PropertyRequirements options);

        public ActionMethodElement ActionMethod(MethodRequirements options);

        public FuncMethodElement FuncMethod(MethodRequirements options);

        //events
    }
}
