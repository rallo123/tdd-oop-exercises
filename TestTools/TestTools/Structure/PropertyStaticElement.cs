using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class PropertyStaticElement : Element, IStaticAccessible, IStaticExtendable
    {
        public PropertyStaticElement(PropertyInfo propertyInfo)
        {
            Info = propertyInfo;
        }

        public PropertyInfo Info { get; }
        public override string Name => Info.Name;
        public Type Type => Info.PropertyType;

        public object Get()
        {
            throw new NotImplementedException();
        }

        public object Set(object value)
        {
            throw new NotImplementedException();
        }


        public FieldStaticElement Field(FieldOptions options) => StaticExtendable.Field(this, options);
        public FieldStaticElement StaticField(FieldOptions options) => StaticExtendable.StaticField(this, options);

        public PropertyStaticElement Property(PropertyOptions options) => StaticExtendable.Property(this, options);
        public PropertyStaticElement StaticProperty(PropertyOptions options) => StaticExtendable.StaticProperty(this, options);

        public ActionMethodStaticElement ActionMethod(MethodOptions options) => StaticExtendable.ActionMethod(this, options);
        public FuncMethodStaticElement FuncMethod(MethodOptions options) => StaticExtendable.FuncMethod(this, options);
        public ActionMethodStaticElement StaticActionMethod(MethodOptions options) => StaticExtendable.StaticActionMethod(this, options);
        public FuncMethodStaticElement StaticFuncMethod(MethodOptions options) => StaticExtendable.StaticFuncMethod(this, options);

    }
}
