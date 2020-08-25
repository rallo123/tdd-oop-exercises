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

        public FieldElement Field(FieldOptions options);
        public FieldStaticElement StaticField(FieldOptions options);

        public PropertyElement Property(PropertyOptions options);
        public PropertyStaticElement StaticProperty(PropertyOptions options);

        public ActionMethodElement ActionMethod(MethodOptions options);
        public ActionMethodStaticElement StaticActionMethod(MethodOptions options);

        public FuncMethodElement FuncMethod(MethodOptions options);
        public FuncMethodStaticElement StaticFuncMethod(MethodOptions options);

        //events
    }
}
