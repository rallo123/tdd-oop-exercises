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
        StructureService _structureService;

        public TypeVisitor(StructureService structureService)
        {
            _structureService = structureService;
        }

        protected override Expression VisitNew(NewExpression node)
        {
            _structureService.VerifyType(node.Type);
            _structureService.VerifyMember(
                node.Constructor,
                MemberVerificationAspect.MemberType,
                MemberVerificationAspect.ConstructorAccessLevel);

            Type type = _structureService.TranslateType(node.Type);
            MemberInfo memberInfo = _structureService.TranslateMember(type, node.Constructor);
            return Expression.New((ConstructorInfo)memberInfo, node.Arguments);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            _structureService.VerifyType(node.Type);
            _structureService.VerifyMember(
                node.Method,
                MemberVerificationAspect.MemberType,
                MemberVerificationAspect.MethodDeclaringType,
                MemberVerificationAspect.MethodReturnType,
                MemberVerificationAspect.MethodIsStatic,
                MemberVerificationAspect.MethodIsAbstract,
                MemberVerificationAspect.MethodIsVirtual,
                MemberVerificationAspect.MethodAccessLevel);

            MemberInfo memberInfo = _structureService.TranslateMember(node.Method);
            return Expression.Call(node.Object, (MethodInfo)memberInfo, node.Arguments);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            _structureService.VerifyType(node.Type);
            _structureService.VerifyMember(node.Member, MemberVerificationAspect.MemberType);

            MemberInfo memberInfo = _structureService.TranslateMember(node.Member);
            
            if (memberInfo is FieldInfo fieldInfo)
            {
                _structureService.VerifyMember(
                    node.Member,
                    MemberVerificationAspect.FieldType,
                    MemberVerificationAspect.FieldIsStatic,
                    MemberVerificationAspect.FieldAccessLevel);
                return Expression.Field(node.Expression, fieldInfo);
            }
            else if (memberInfo is PropertyInfo propertyInfo)
            {
                _structureService.VerifyMember(
                       node.Member,
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
            _structureService.VerifyType(node.Member.DeclaringType);
            _structureService.VerifyMember(node.Member, MemberVerificationAspect.MemberType);

            MemberInfo memberInfo = _structureService.TranslateMember(node.Member);
            if (memberInfo is FieldInfo fieldInfo)
            {
                _structureService.VerifyMember(
                    node.Member,
                    MemberVerificationAspect.FieldType,
                    MemberVerificationAspect.FieldIsStatic,
                    MemberVerificationAspect.FieldWriteability,
                    MemberVerificationAspect.FieldAccessLevel);
                return Expression.Bind(fieldInfo, node.Expression);
            }
            else if (memberInfo is PropertyInfo propertyInfo)
            {
                _structureService.VerifyMember(
                       node.Member,
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
    }
}
