using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class StructureService
    {
        string FromNamespace { get; set; }

        string ToNamespace { get; set; }

        public StructureVerifier StructureVerifier { get; set; } = new StructureVerifier();

        public ITypeTranslator TypeTranslator { get; set; } = new SameNameTypeTranslator();

        public IMemberTranslator MemberTranslator { get; set; } = new SameNameMemberTranslator();

        public ICollection<ITypeVerifier> DefaultTypeVerifiers { get; set; } = new List<ITypeVerifier>()
        {
            new UnchangedTypeAccessLevelVerifier(),
            new UnchangedTypeIsAbstractVerifier(),
            new UnchangedTypeIsStaticVerifier()
        };

        public ICollection<IMemberVerifier> DefaultMemberVerifiers { get; set; } = new List<IMemberVerifier>()
        {
            new UnchangedFieldTypeVerifier(),
            new UnchangedMemberAccessLevelVerifier(),
            new UnchangedMemberDeclaringType(),
            new UnchangedMemberIsStaticVerifier(),
            new UnchangedMemberIsVirtualVerifier(),
            new UnchangedMemberTypeVerifier(),
            new UnchangedPropertyTypeVerifier()
        };

        public ICollection<TypeVerificationAspect> TypeVerificationOrder { get; set; } = new[]
        {
            TypeVerificationAspect.IsInterface,
            TypeVerificationAspect.IsDelegate,
            TypeVerificationAspect.IsSubclassOf,
            TypeVerificationAspect.DelegateSignature,
            TypeVerificationAspect.IsStatic,
            TypeVerificationAspect.IsAbstract,
            TypeVerificationAspect.AccessLevel
        };

        public ICollection<MemberVerificationAspect> MemberVerificationOrder { get; set; } = new[]
        {
            MemberVerificationAspect.MemberType,
            MemberVerificationAspect.FieldType,
            MemberVerificationAspect.FieldAccessLevel,
            MemberVerificationAspect.FieldWriteability,
            MemberVerificationAspect.PropertyType,
            MemberVerificationAspect.PropertyIsStatic,
            MemberVerificationAspect.PropertyGetIsAbstract,
            MemberVerificationAspect.PropertyGetIsVirtual,
            MemberVerificationAspect.PropertyGetDeclaringType,
            MemberVerificationAspect.PropertyGetAccessLevel,
            MemberVerificationAspect.PropertySetIsAbstract,
            MemberVerificationAspect.PropertySetIsVirtual,
            MemberVerificationAspect.PropertySetDeclaringType,
            MemberVerificationAspect.PropertySetAccessLevel,
            MemberVerificationAspect.MethodReturnType,
            MemberVerificationAspect.MethodIsAbstract,
            MemberVerificationAspect.MethodIsVirtual,
            MemberVerificationAspect.MethodDeclaringType,
            MemberVerificationAspect.MethodAccessLevel
        };

        public StructureService(string fromNamespace, string toNamespace)
        {
            FromNamespace = fromNamespace;
            ToNamespace = toNamespace;
        }

        public Type TranslateType(Type type)
        {
            if (type.Namespace != FromNamespace)
                return type;

            ITypeTranslator translator = type.GetCustomTranslator() ?? TypeTranslator;

            translator.TargetNamespace = ToNamespace;
            translator.Verifier = StructureVerifier;

            return translator.Translate(type);
        }

        public MemberInfo TranslateMember(MemberInfo memberInfo)
        {
            if (memberInfo.DeclaringType.Namespace != FromNamespace)
                return memberInfo;
            
            IMemberTranslator translator = memberInfo.GetCustomTranslator() ?? MemberTranslator;

            translator.Verifier = StructureVerifier;
            translator.TargetType = TranslateType(memberInfo.DeclaringType);

            return translator.Translate(memberInfo);
        }

        public MemberInfo TranslateMember(Type targetType, MemberInfo memberInfo)
        {
            if (memberInfo.DeclaringType.Namespace != FromNamespace)
                return memberInfo;

            IMemberTranslator translator = memberInfo.GetCustomTranslator() ?? MemberTranslator;

            translator.Verifier = StructureVerifier;
            translator.TargetType = targetType;

            return translator.Translate(memberInfo);
        }

        public void VerifyType(Type original)
        {
            VerifyType(original, DefaultTypeVerifiers.ToArray());
        }

        public void VerifyType(Type original, params TypeVerificationAspect[] aspects) 
        {
            VerifyType(original, DefaultTypeVerifiers.ToArray(), aspects);
        }

        public void VerifyType(Type original, ITypeVerifier[] verifiers)
        {
            Type translated = TranslateType(original);

            foreach (TypeVerificationAspect aspect in TypeVerificationOrder)
            {
                ITypeVerifier defaultVerifier = verifiers.FirstOrDefault(ver => ver.Aspects.Contains(aspect));
                ITypeVerifier verifier = original.GetCustomVerifier(aspect) ?? defaultVerifier;

                if (verifier != null)
                {
                    verifier.Verifier = StructureVerifier;
                    verifier.TypeTranslator = TypeTranslator;
                    verifier.Verify(original, translated);
                }
            }
        }

        public void VerifyType(Type original, ITypeVerifier[] verifiers, params TypeVerificationAspect[] aspects)
        {
            Type translated = TranslateType(original);

            foreach (TypeVerificationAspect aspect in TypeVerificationOrder)
            {
                if (!aspects.Contains(aspect))
                    continue;

                ITypeVerifier defaultVerifier = verifiers.FirstOrDefault(ver => ver.Aspects.Contains(aspect));
                ITypeVerifier verifier = original.GetCustomVerifier(aspect) ?? defaultVerifier;

                if (verifier != null)
                {
                    verifier.Verifier = StructureVerifier;
                    verifier.TypeTranslator = TypeTranslator;
                    verifier.Verify(original, translated);
                }
            }
        }

        public void VerifyMember(MemberInfo original)
        {
            VerifyMember(original, DefaultMemberVerifiers.ToArray());
        }

        public void VerifyMember(MemberInfo original, params MemberVerificationAspect[] aspects)
        {
            VerifyMember(original, DefaultMemberVerifiers.ToArray(), aspects);
        }

        public void VerifyMember(MemberInfo original, IMemberVerifier[] verifiers)
        {
            Type translatedType = TranslateType(original.DeclaringType);
            MemberInfo translatedMember = TranslateMember(translatedType, original);

            foreach (MemberVerificationAspect aspect in MemberVerificationOrder)
            {
                IMemberVerifier defaultVerifier = verifiers.FirstOrDefault(ver => ver.Aspects.Contains(aspect));
                IMemberVerifier verifier = original.GetCustomVerifier(aspect) ?? defaultVerifier;

                if (verifier != null)
                {
                    verifier.Verifier = StructureVerifier;
                    verifier.TypeTranslator = TypeTranslator;
                    verifier.Verify(original, translatedMember);
                }
            }
        }

        public void VerifyMember(MemberInfo original, IMemberVerifier[] verifiers, params MemberVerificationAspect[] aspects)
        {
            Type translatedType = TranslateType(original.DeclaringType);
            MemberInfo translatedMember = TranslateMember(translatedType, original);

            foreach (MemberVerificationAspect aspect in MemberVerificationOrder)
            {
                if (!aspects.Contains(aspect))
                    continue;

                IMemberVerifier defaultVerifier = verifiers.FirstOrDefault(ver => ver.Aspects.Contains(aspect));
                IMemberVerifier verifier = original.GetCustomVerifier(aspect) ?? defaultVerifier;

                if (verifier != null)
                {
                    verifier.Verifier = StructureVerifier;
                    verifier.TypeTranslator = TypeTranslator;
                    verifier.Verify(original, translatedMember);
                }
            }
        }
    }
}
