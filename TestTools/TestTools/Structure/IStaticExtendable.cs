using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public interface IStaticExtendable : IElement
    {
        public Type Type { get; }

        public FieldStaticElement Field(FieldOptions options);
        public FieldStaticElement StaticField(FieldOptions options);

        public PropertyStaticElement Property(PropertyOptions options);
        public PropertyStaticElement StaticProperty(PropertyOptions options);

        public ActionMethodStaticElement ActionMethod(MethodOptions options);
        public ActionMethodStaticElement StaticActionMethod(MethodOptions options);

        public FuncMethodStaticElement FuncMethod(MethodOptions options);
        public FuncMethodStaticElement StaticFuncMethod(MethodOptions options);
    }
}
