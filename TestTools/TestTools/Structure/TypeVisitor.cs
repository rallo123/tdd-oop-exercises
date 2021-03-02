using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Linq;
using TestTools.Helpers;

namespace TestTools.Structure
{
    public class TypeVisitor : ExpressionVisitor
    {
        public string Namespace { get; set; }

        public StructureVerifier StructureVerifier { get; set; }

        public ITypeTranslator TypeTranslator { get; set; } = new SameNameTypeTranslator();

        public ICollection<ITypeVerifier> TypeVerifiers { get; set; } = new List<ITypeVerifier>()
        {
            new UnchangedTypeAccessLevelVerifier(),
            new UnchangedTypeIsAbstractVerifier(),
            new UnchangedTypeIsStaticVerifier()
        };

        public IMemberTranslator MemberTranslator { get; set; } = new SameNameMemberTranslator();

        public ICollection<IMemberVerifier> MemberVerifiers { get; set; } = new List<IMemberVerifier>()
        {
            new UnchangedFieldTypeVerifier(),
            new UnchangedMemberAccessLevelVerifier(),
            new UnchangedMemberDeclaringType(),
            new UnchangedMemberIsStaticVerifier(),
            new UnchangedMemberIsVirtualVerifier(),
            new UnchangedMemberTypeVerifier(),
            new UnchangedPropertyTypeVerifier()
        };

        public override Expression Visit(Expression node)
        {
            return base.Visit(node);
        }

        public Expression Visit(Expression node, ICollection<ITypeVerifier> typeVerifiers, ICollection<IMemberVerifier> memberVerifiers)
        {
            // All implicit verifications are handled as normally
            Expression expression = Visit(node);

            // Additional type verifications are handled after
            Type type = TranslateType(node.Type);
            foreach (TypeVerifier typeVerifier in typeVerifiers)
            {
                typeVerifier.TypeTranslator = TypeTranslator;
                typeVerifier.Verifier = StructureVerifier;

                typeVerifier.Verify(node.Type, type);
            }

            // Additional member verifications are handled last
            MemberInfo originalMember;
            if (node is NewExpression newExpression)
                originalMember = newExpression.Constructor;
            else if (node is MethodCallExpression methodCallExpression)
                originalMember = methodCallExpression.Method;
            else if (node is MemberExpression memberExpression)
                originalMember = memberExpression.Member;
            else throw new NotImplementedException();

            MemberInfo translatedMember = TranslateMember(type, originalMember);
            foreach(IMemberVerifier memberVerifier in memberVerifiers)
            {
                memberVerifier.TypeTranslator = TypeTranslator;
                memberVerifier.Verifier = StructureVerifier;

                memberVerifier.Verify(originalMember, translatedMember);
            }

            return expression;
        }

        protected override Expression VisitNew(NewExpression node)
        {
            Type type = TranslateType(node.Type);
            VerifyType(node.Type, type);

            MemberInfo memberInfo = TranslateMember(type, node.Constructor);
            VerfifyMember(
                node.Constructor,
                memberInfo,
                MemberVerificationAspect.MemberType,
                MemberVerificationAspect.ConstructorAccessLevel);

            return Expression.New((ConstructorInfo)memberInfo, node.Arguments);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            Type type = TranslateType(node.Type);
            VerifyType(node.Type, type);

            MemberInfo memberInfo = TranslateMember(type, node.Method);
            VerfifyMember(
                node.Method,
                memberInfo,
                MemberVerificationAspect.MemberType,
                MemberVerificationAspect.MethodDeclaringType,
                MemberVerificationAspect.MethodReturnType,
                MemberVerificationAspect.MethodIsStatic,
                MemberVerificationAspect.MethodIsAbstract,
                MemberVerificationAspect.MethodIsVirtual,
                MemberVerificationAspect.MethodAccessLevel);

            return Expression.Call(node.Object, (MethodInfo)memberInfo, node.Arguments);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            Type type = TranslateType(node.Type);
            VerifyType(node.Type, type);

            MemberInfo memberInfo = TranslateMember(type, node.Member);
            
            if (memberInfo is FieldInfo fieldInfo)
            {
                VerfifyMember(
                    node.Member,
                    fieldInfo,
                    MemberVerificationAspect.MemberType,
                    MemberVerificationAspect.FieldType,
                    MemberVerificationAspect.FieldIsStatic,
                    MemberVerificationAspect.FieldAccessLevel);
                return Expression.Field(node.Expression, fieldInfo);
            }
            else if (memberInfo is PropertyInfo propertyInfo)
            {
                VerfifyMember(
                       node.Member,
                       propertyInfo,
                       MemberVerificationAspect.MemberType,
                       MemberVerificationAspect.PropertyType,
                       MemberVerificationAspect.PropertyIsStatic,
                       MemberVerificationAspect.PropertyGetDeclaringType,
                       MemberVerificationAspect.PropertyGetIsAbstract,
                       MemberVerificationAspect.PropertyGetIsVirtual,
                       MemberVerificationAspect.PropertyGetAccessLevel);
                return Expression.Property(node.Expression, propertyInfo);
            }
            else throw new ArgumentException("Member was not translated to FieldInfo or PropertyInfo");
        }

        protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
        {
            Type type = TranslateType(node.Member.DeclaringType);
            VerifyType(node.Member.DeclaringType, type);

            MemberInfo memberInfo = TranslateMember(type, node.Member);

            if (memberInfo is FieldInfo fieldInfo)
            {
                VerfifyMember(
                    node.Member,
                    fieldInfo,
                    MemberVerificationAspect.MemberType,
                    MemberVerificationAspect.FieldType,
                    MemberVerificationAspect.FieldIsStatic,
                    MemberVerificationAspect.FieldWriteability,
                    MemberVerificationAspect.FieldAccessLevel);
                return Expression.Bind(fieldInfo, node.Expression);
            }
            else if (memberInfo is PropertyInfo propertyInfo)
            {
                VerfifyMember(
                       node.Member,
                       propertyInfo,
                       MemberVerificationAspect.MemberType,
                       MemberVerificationAspect.PropertyType,
                       MemberVerificationAspect.PropertyIsStatic,
                       MemberVerificationAspect.PropertySetDeclaringType,
                       MemberVerificationAspect.PropertySetIsAbstract,
                       MemberVerificationAspect.PropertySetIsVirtual,
                       MemberVerificationAspect.PropertySetAccessLevel);
                return Expression.Bind(propertyInfo, node.Expression);
            }
            else throw new ArgumentException("Member was not translated to FieldInfo or PropertyInfo");
        }

        private Type TranslateType(Type type)
        {
            ITypeTranslator translator = type.GetCustomTranslator() ?? TypeTranslator;

            translator.TargetNamespace = Namespace;
            translator.Verifier = StructureVerifier;

            return translator.Translate(type);
        }

        private void VerifyType(Type original, Type translated)
        {
            VerifyType(original, translated, TypeVerificationAspect.AccessLevel);
        }

        private void VerifyType(Type original, Type translated, params TypeVerificationAspect[] aspects)
        {
            foreach (TypeVerificationAspect aspect in aspects)
            {
                ITypeVerifier defaultVerifier = TypeVerifiers.FirstOrDefault(ver => ver.Aspects.Contains(aspect));
                ITypeVerifier verifier = original.GetCustomVerifier(aspect) ?? defaultVerifier;

                if (verifier != null)
                {
                    verifier.Verifier = StructureVerifier;
                    verifier.TypeTranslator = TypeTranslator;
                    verifier.Verify(original, translated);
                }
            }
        }

        private MemberInfo TranslateMember(Type targetType, MemberInfo memberInfo)
        {
            IMemberTranslator translator = memberInfo.GetCustomTranslator() ?? MemberTranslator;

            translator.Verifier = StructureVerifier;
            translator.TargetType = targetType;

            return translator.Translate(memberInfo);
        }

        private void VerfifyMember(MemberInfo original, MemberInfo translated, params MemberVerificationAspect[] aspects)
        {
            foreach (MemberVerificationAspect aspect in aspects)
            {
                IMemberVerifier defaultVerifier = MemberVerifiers.FirstOrDefault(ver => ver.Aspects.Contains(aspect));
                IMemberVerifier verifier = original.GetCustomVerifier(aspect) ?? defaultVerifier;

                if (verifier != null)
                {
                    verifier.TypeTranslator = TypeTranslator;
                    verifier.Verify(original, translated);
                }
            }
        }
    }
}
