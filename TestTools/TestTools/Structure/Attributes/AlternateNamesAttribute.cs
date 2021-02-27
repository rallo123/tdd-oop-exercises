using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace TestTools.Structure.Attributes
{
    public class AlternateNamesAttribute : Attribute, ITypeTranslator, IMemberTranslator
    {
        readonly AlternateNameTypeTranslator _typeTranslator;
        readonly AlternateNameMemberTranslator _memberTranslator;

        public AlternateNamesAttribute(params string[] alternateNames)
        {
            _typeTranslator = new AlternateNameTypeTranslator(alternateNames);
            _memberTranslator = new AlternateNameMemberTranslator(alternateNames);
        }

        public string TargetNamespace { 
            get => _typeTranslator.TargetNamespace; 
            set => _typeTranslator.TargetNamespace = value;
        }

        public Type TargetType { 
            get => _memberTranslator.TargetType; 
            set => _memberTranslator.TargetType = value; 
        }

        public StructureVerifier Verifier { get; set; }

        public Type Translate(Type type) => _typeTranslator.Translate(type);

        public MemberInfo Translate(MemberInfo member) => _memberTranslator.Translate(member);
    }
}
